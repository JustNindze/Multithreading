using System;
using System.Collections.Concurrent;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multithreading
{
    public partial class MainWindow : Form
    {
        RandomGenerator obj = new RandomGenerator();

        bool toRun = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        // kai paspaudziamas mygtukas "Pradėti"
        private async void MygtukasPradeti_Click(object sender, EventArgs e)
        {
            toRun = true;

            int atsakuSkaicius = int.Parse(atsakuSarasas.SelectedItem.ToString());

            mygtukasPradeti.Enabled = false;
            atsakuSarasas.Enabled = false;
            mygtukasStabdyti.Enabled = true;
            CloseButton.EnableDisable(this, false);

            Task[] ts = new Task[atsakuSkaicius];

            while (toRun)
            {
                ConcurrentBag<DatabaseTable> generatedSequences = new ConcurrentBag<DatabaseTable>();

                await Task.Run(() =>
                    {
                        for (int i = 0; i < atsakuSkaicius; i++)
                        {
                            ts[i] = Task.Factory.StartNew(() => generatedSequences.Add(obj.GenerateSequence()));
                        }
                        Task.WaitAll(ts);
                    }
                );

                try
                {
                    OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
                    string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
                    string fileName = Path.Combine(path, "Database.mdb");
                    builder.ConnectionString = @"Data Source=" + fileName;

                    builder.Add("Provider", "Microsoft.Jet.Oledb.4.0");
                    builder.Add("Jet OLEDB:Database Password", "12345");

                    foreach (DatabaseTable element in generatedSequences)
                    {
                        string[] data = { element.threadId.ToString(), element.data };
                        ListViewItem listViewItem = new ListViewItem(data);
                        atsakymuLentele.Items.Insert(0, listViewItem);

                        if (atsakymuLentele.Items.Count > 20)
                        {
                            atsakymuLentele.Items.RemoveAt(atsakymuLentele.Items.Count - 1);
                        }

                        InsertData(builder.ConnectionString, element.threadId, element.generatedTime, element.data);
                    }
                }
                catch (Exception ex)
                {
                    LogWriter logger = new LogWriter(ex.ToString());
                    logger.LogWrite(ex.ToString());
                }
            }
        }

        // kai uzkraunamas pagrindinis langas
        private void MainWindow_Load(object sender, EventArgs e)
        {
            atsakuSarasas.SelectedIndex = 0;

            mygtukasStabdyti.Enabled = false;
        }

        // kai paspaudziamas mygtukas "Stabdyti"
        private void MygtukasStabdyti_Click(object sender, EventArgs e)
        {
            toRun = false;

            mygtukasPradeti.Enabled = true;
            atsakuSarasas.Enabled = true;
            mygtukasStabdyti.Enabled = false;
            CloseButton.EnableDisable(this, true);
        }

        // iterpiami duomenys i mdb faila
        private void InsertData(string connectionString, int threadId, DateTime generatedTime, string data)
        {
            string query = "INSERT INTO generatedSequence (ThreadID, GeneratedTime, Data) " +
                           "VALUES (@ThreadID, @GeneratedTime, @Data) ";

            try
            {
                using (OleDbConnection cn = new OleDbConnection(connectionString))
                using (OleDbCommand cmd = new OleDbCommand(query, cn))
                {
                    cmd.Parameters.Add("@ThreadID", OleDbType.Integer).Value = threadId;
                    cmd.Parameters.Add("@GeneratedTime", OleDbType.Date, 10).Value = generatedTime;
                    cmd.Parameters.Add("@Data", OleDbType.VarChar, 10).Value = data;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (OleDbException ex)
            {
                LogWriter logger = new LogWriter(ex.ToString());
                logger.LogWrite(ex.ToString());
            }
        }
    }
}
