using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace _2FAuthAndroidLibrary
{
    public static class Logging
    {
        private const string logPath = "log.txt";
        public enum LogType  {
            Error,
            Warning,
            Info,
            Debug
        };

        public static void LogDebug(string message, [CallerMemberName] string functionName = "")
        {
            LogToFile(message, LogType.Debug, functionName);
        }
        public static void LogInfo(string message, [CallerMemberName] string functionName = "")
        {
            LogToFile(message, LogType.Info, functionName);
        }
        public static void LogWarning(string message, [CallerMemberName] string functionName = "")
        {
            LogToFile(message, LogType.Warning, functionName);
        }
        public static void LogError(string message, [CallerMemberName] string functionName = "")
        {
            LogToFile(message, LogType.Error, functionName);
        }
        public static void LogToFile(string message, LogType type, [CallerMemberName] string functionName = "")
        {
#if !DEBUG
            if (type == LogType.Debug) // Dont log debug data, if its release build
                return;
#endif

            if (!File.Exists(logPath))
            {
                var stream = File.Create(logPath);
                stream.Close();
            }

            string Text = "[" + DateTime.Now + "]" + " *" + type + "* " + " "+functionName+" " + message + System.Environment.NewLine;
            try {                
            File.AppendAllText(logPath, Text);
            }
            catch(Exception e) {
#if DEBUG
                throw new NotImplementedException(e.Message);
#endif
            }
        }
    }
}