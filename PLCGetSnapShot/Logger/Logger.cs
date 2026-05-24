using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLCGetSnapShot
{
    public static class Logger
    {
        // =====================================================
        // CONFIG
        // =====================================================

        private static readonly string _logRoot =
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "MachineLog");

        // Queue
        private static readonly BlockingCollection<LogItem> _queue = new BlockingCollection<LogItem>(10000);

        // Runtime Event
        public static event Action<LogItem> OnLogReceived;

        // Background Thread
        private static Task _logTask;

        // Shutdown
        private static CancellationTokenSource _cts =
            new CancellationTokenSource();

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        static Logger()
        {
            Directory.CreateDirectory(_logRoot);

            _logTask = Task.Factory.StartNew(
                ProcessQueue,
                _cts.Token,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default);

            Log(
                LogCategory.System,
                "Logger Started");
        }

        // =====================================================
        // PUBLIC API
        // =====================================================

        public static void Log(
            LogCategory category,
            string message)
        {
            try
            {
                LogItem item = new LogItem
                {
                    Time = DateTime.Now,
                    Category = category,
                    Message = message
                };

                // Push Queue
                _queue.Add(item);

                // UI Event
                try
                {
                    OnLogReceived?.Invoke(item);
                }
                catch
                {
                }
            }
            catch
            {
            }
        }

        // =====================================================
        // PROCESS QUEUE
        // =====================================================

        private static void ProcessQueue()
        {
            foreach (var item in _queue.GetConsumingEnumerable())
            {
                try
                {
                    WriteToFile(item);
                }
                catch
                {
                    // Logger không được crash machine
                }
            }
        }

        // =====================================================
        // WRITE FILE
        // =====================================================

        private static void WriteToFile(LogItem item)
        {
            DateTime now = item.Time;

            // Folder:
            // MachineLog\2026\05\11
            string folder =
                Path.Combine(
                    _logRoot,
                    now.ToString("yyyy"),
                    now.ToString("MM"),
                    now.ToString("dd"));

            Directory.CreateDirectory(folder);

            // File:
            // Vision.log
            // Robot.log
            string fileName =
                item.Category.ToString() + ".log";

            string filePath =
                Path.Combine(folder, fileName);

            // Content
            string line =
                $"{item.Time:yyyy-MM-dd HH:mm:ss.fff} " +
                $"[{item.Category}] " +
                $"{item.Message}";

            // Append File
            using (FileStream fs = new FileStream(
                filePath,
                FileMode.Append,
                FileAccess.Write,
                FileShare.ReadWrite))
            using (StreamWriter sw =
                new StreamWriter(fs, Encoding.UTF8))
            {
                sw.WriteLine(line);
            }
        }

        // =====================================================
        // SHUTDOWN
        // =====================================================

        public static void Shutdown()
        {
            try
            {
                Log(
                    LogCategory.System,
                    "Logger Shutdown");

                _queue.CompleteAdding();

                _logTask.Wait(3000);

                _cts.Cancel();
            }
            catch
            {
            }
        }
    }

}
