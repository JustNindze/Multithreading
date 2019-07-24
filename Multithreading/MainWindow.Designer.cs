namespace Multithreading
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.atsakuSarasas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mygtukasPradeti = new System.Windows.Forms.Button();
            this.atsakymuLentele = new System.Windows.Forms.ListView();
            this.threadId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sugeneruotaEilute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mygtukasStabdyti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // atsakuSarasas
            // 
            this.atsakuSarasas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.atsakuSarasas.FormattingEnabled = true;
            this.atsakuSarasas.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.atsakuSarasas.Location = new System.Drawing.Point(138, 25);
            this.atsakuSarasas.Name = "atsakuSarasas";
            this.atsakuSarasas.Size = new System.Drawing.Size(56, 24);
            this.atsakuSarasas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Atšakų skaičius:";
            // 
            // mygtukasPradeti
            // 
            this.mygtukasPradeti.Location = new System.Drawing.Point(253, 26);
            this.mygtukasPradeti.Name = "mygtukasPradeti";
            this.mygtukasPradeti.Size = new System.Drawing.Size(75, 23);
            this.mygtukasPradeti.TabIndex = 2;
            this.mygtukasPradeti.Text = "Pradėti";
            this.mygtukasPradeti.UseVisualStyleBackColor = true;
            this.mygtukasPradeti.Click += new System.EventHandler(this.MygtukasPradeti_Click);
            // 
            // atsakymuLentele
            // 
            this.atsakymuLentele.BackColor = System.Drawing.Color.Snow;
            this.atsakymuLentele.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.threadId,
            this.sugeneruotaEilute});
            this.atsakymuLentele.ForeColor = System.Drawing.Color.Black;
            this.atsakymuLentele.FullRowSelect = true;
            this.atsakymuLentele.GridLines = true;
            this.atsakymuLentele.Location = new System.Drawing.Point(12, 55);
            this.atsakymuLentele.Name = "atsakymuLentele";
            this.atsakymuLentele.Scrollable = false;
            this.atsakymuLentele.Size = new System.Drawing.Size(459, 452);
            this.atsakymuLentele.TabIndex = 3;
            this.atsakymuLentele.UseCompatibleStateImageBehavior = false;
            this.atsakymuLentele.View = System.Windows.Forms.View.Details;
            // 
            // threadId
            // 
            this.threadId.Text = "Thread Id";
            this.threadId.Width = 89;
            // 
            // sugeneruotaEilute
            // 
            this.sugeneruotaEilute.Text = "Sugeneruota eilutė";
            this.sugeneruotaEilute.Width = 369;
            // 
            // mygtukasStabdyti
            // 
            this.mygtukasStabdyti.Location = new System.Drawing.Point(367, 26);
            this.mygtukasStabdyti.Name = "mygtukasStabdyti";
            this.mygtukasStabdyti.Size = new System.Drawing.Size(75, 23);
            this.mygtukasStabdyti.TabIndex = 4;
            this.mygtukasStabdyti.Text = "Stabdyti";
            this.mygtukasStabdyti.UseVisualStyleBackColor = true;
            this.mygtukasStabdyti.Click += new System.EventHandler(this.MygtukasStabdyti_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 515);
            this.Controls.Add(this.mygtukasStabdyti);
            this.Controls.Add(this.atsakymuLentele);
            this.Controls.Add(this.mygtukasPradeti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.atsakuSarasas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Atsitiktinių skaičių generatorius";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox atsakuSarasas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mygtukasPradeti;
        private System.Windows.Forms.ListView atsakymuLentele;
        private System.Windows.Forms.ColumnHeader sugeneruotaEilute;
        private System.Windows.Forms.ColumnHeader threadId;
        private System.Windows.Forms.Button mygtukasStabdyti;
    }
}

