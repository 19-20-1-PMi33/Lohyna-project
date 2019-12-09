using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Extensions.Logging;

namespace ViewModel
{
    public class Logger : ILogger
    {
        /// <summary>
        /// Class for logging
        /// </summary>
        protected string FilePath { get; set; }

        private List<string> scopes = new List<string>();

        public const string DefaultFilePath = @"Lohyna.log";

        public Logger(string filePath = DefaultFilePath)
        {
            FilePath = filePath;
        }
        /// <summary>
        /// Creates local scope for logging
        /// </summary>
        /// <typeparam name="TState">State of logger</typeparam>
        /// <param name="state">State of events to log</param>
        /// <returns></returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            scopes.Add(state.ToString());

            return new NoobDispose();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        /// <summary>
        /// Mthod for writing logs in file
        /// </summary>
        /// <typeparam name="TState">State of logger</typeparam>
        /// <param name="logLevel">Level if logging</param>
        /// <param name="eventId">Reference on event to log</param>
        /// <param name="state">State of logging event</param>
        /// <param name="exception">Exception of event</param>
        /// <param name="formatter">Format type for logging</param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            var data = formatter(state, exception);
            string completeScope = "";
           if (scopes.Count > 0)
           {
               completeScope = scopes.Aggregate("", (res, item) => res + $"[{item}]::");
           }

            var logMessage = $"{DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy")} | {completeScope} {data}{Environment.NewLine}";

            var encodedMessage = Encoding.Unicode.GetBytes(logMessage);

            using (var sourceStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.Read, 4096, true))
            {
                sourceStream.WriteAsync(encodedMessage, 0, encodedMessage.Length);
            }
        }

        private class NoobDispose : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}
