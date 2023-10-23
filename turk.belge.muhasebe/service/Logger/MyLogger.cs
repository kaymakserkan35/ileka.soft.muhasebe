using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace service.Logger
{


    public interface IMyLogger<T> : ILogger<T>
    {

        Action<string> errorAction { get; set; }

    }

    public class MyLogger<T> : IMyLogger<T>

    {

        public string rootDir = Directory.GetCurrentDirectory();
        string logFilePath;

        ILogger<T> logger;
        public MyLogger(ILogger<T> logger)
        {

            this.logger = logger;
            logFilePath = $"{this.rootDir}_logs.txt";

        }

        public Action<string> errorAction { get; set; }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return this.logger.BeginScope<TState>(state);

        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // logger.LogDebug
            return logger.IsEnabled(logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {

            var writeThisObj = $"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss.fff}] \t [{logLevel.ToString()}] \t [{state.ToString()}]";

            if (File.Exists(logFilePath)) { using (var writer = File.AppendText(logFilePath)) { writer.WriteLine(writeThisObj); } }
            else { using (var writer = new StreamWriter(logFilePath)) writer.WriteLine(writeThisObj); }
            if (errorAction != null) errorAction.Invoke(writeThisObj);
        }

    }


}
