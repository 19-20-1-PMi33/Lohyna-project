using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

using Microsoft.Extensions.Logging;

namespace View
{
    public class Logger : ILogger
    {
        /// <summary>
        /// Path to file with logs. May be used in derived classes.
        /// </summary>
        protected string FilePath { get; set; }

        private List<string> scopes = new List<string>();

        public const string DefaultFilePath = @"Lohyna.log";

        public Logger(string filePath = DefaultFilePath)
        {
            FilePath = filePath;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            scopes.Add(state.ToString());

            return new NoobDispose();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

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

            var logMessage = $"{DateTime.Now} | {completeScope} {data}{Environment.NewLine}";

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
