using AutoMachine.Application.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMachine.Application.Services
{
    public static class Logger
    {
        // =========================================================
        // CONFIG
        // =========================================================

        private static readonly string _logRoot =
            _logRoot =
            AppDomain.CurrentDomain.BaseDirectory;

        // Queue
        private static readonly BlockingCollection<LogItem>
            _queue =
            new BlockingCollection<LogItem>(5000);

        // Runtime UI Event
        public static event Action<LogItem> OnLogReceived;

        // File Lock
        private static readonly object _fileLock =
            new object();

        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        static Logger()
        {
            Task.Factory.StartNew(
                ProcessQueue,
                TaskCreationOptions.LongRunning);

            Log(
                LogCategory.System,
                "Logger Started");
        }

        // =========================================================
        // PUBLIC API
        // =========================================================

        public static void Log(
            LogCategory category,
            string msg)
        {
            try
            {
                LogItem item = new LogItem
                {
                    Time = DateTime.Now,
                    Category = category,
                    Message = msg
                };

                // Push Queue
                _queue.TryAdd(item);

                // Push Runtime UI
                OnLogReceived?.Invoke(item);
            }
            catch
            {
            }
        }

        // =========================================================
        // BACKGROUND THREAD
        // =========================================================

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

        // =========================================================
        // WRITE FILE
        // =========================================================

        private static void WriteToFile(LogItem item)
        {
            DateTime now = item.Time;

            // Folder
            string folder =
                Path.Combine(
                    _logRoot,
                    now.ToString("yyyy"),
                    now.ToString("MM"));

            Directory.CreateDirectory(folder);

            // File
            string filePath =
                Path.Combine(
                    folder,
                    now.ToString("dd") + ".log");

            // Log Line
            string line =
                $"{item.Time:yyyy-MM-dd HH:mm:ss.fff} " +
                $"[{item.Category}] " +
                $"{item.Message}";

            // Append File
            lock (_fileLock)
            {
                using (StreamWriter sw =
                    new StreamWriter(
                        filePath,
                        true,
                        Encoding.UTF8))
                {
                    sw.WriteLine(line);
                }
            }
        }

        // =========================================================
        // SHUTDOWN
        // =========================================================

        public static void Shutdown()
        {
            try
            {
                Log(
                    LogCategory.System,
                    "Logger Shutdown");

                _queue.CompleteAdding();
            }
            catch
            {
            }
        }
    }
}

