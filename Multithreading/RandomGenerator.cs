using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multithreading
{
    class RandomGenerator
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const int minLengthValue = 5;
        private const int maxLengthValue = 10;
        private const int minTimeValue = 500; //in miliseconds
        private const int maxTimeValue = 2000; //in miliseconds

        private static readonly Random _global = new Random();
        [ThreadStatic] private static Random _local;

        // perrasomas random Next metodas, kad jis tiktu multithreading'ui
        public int Next(int minLengthValue, int maxLengthValue)
        {
            if (_local == null)
            {
                lock (_global)
                {
                    if (_local == null)
                    {
                        int seed = _global.Next();
                        _local = new Random(seed);
                    }
                }
            }

            int newMinLenghtValue = minLengthValue;
            int newMaxLengthValue = maxLengthValue;

            if (minLengthValue < 0)
            {
                newMinLenghtValue = 1;
            }

            if (maxLengthValue > 100000)
            {
                newMaxLengthValue = 100000;
            }

            return _local.Next(newMinLenghtValue, newMaxLengthValue);
        }

        // atsitiktinai generuojama simboliu eilute
        public DatabaseTable GenerateSequence()
        {
            int length = Next(minLengthValue, maxLengthValue);
            string generatedSequence = "";
            DateTime time;

            for (int i = 0; i < length; i++)
            {
                int pointer = Next(0, chars.Length);
                generatedSequence += chars[pointer];
            }

            time = DateTime.Now;

            Thread.Sleep(Next(minTimeValue, maxTimeValue));

            return new DatabaseTable()
            {
                threadId = Thread.CurrentThread.ManagedThreadId,
                generatedTime = time,
                data = generatedSequence
            };
        }
    }

    // reikalingu duomenu struktura
    struct DatabaseTable
    {
        public int threadId { get; set; }
        public DateTime generatedTime { get; set; }
        public string data { get; set; }
    }
}
