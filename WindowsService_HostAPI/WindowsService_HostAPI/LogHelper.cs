using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService_HostAPI
{
    public enum LogTarget
    {
        File, Database, EventLog
    }

    public static class LogHelper
    {
        private static LogBase logger = null;

        public static void Log(string msg)
        {
            Log(LogTarget.File, msg);
        }

        public static void Log(LogTarget target, string message)
        {
            if (logger == null)
                switch (target)
                {
                    case LogTarget.File:
                        logger = new FileLogger();
                        break;
                    case LogTarget.Database:
                        logger = new DBLogger();
                        break;
                    case LogTarget.EventLog:
                        logger = new EventLogger();
                        break;
                }
            message = DateTime.Now.ToString("dd:MM:HH:mm:ss") + "\t" + message;
            logger?.Log(message);
        }
    }
}
