using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Logging;
using log4net.Config;
using System.IO;
using log4net;

namespace Common
{
    public class LogHelper:ILoggerFacade
    {

        void Debug(string message) { s_ILogger.Debug(message); }

        void Info(string message) { s_ILogger.Info(message); }

        void Error(string message) { s_ILogger.Error(message); }

        void Fatal(string message) { s_ILogger.Fatal(message); }

        private ILog s_ILogger=null;
        public LogHelper()
        {
            if(s_ILogger==null)
            {
                XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
                s_ILogger = LogManager.GetLogger(typeof(LogHelper));
            }
           
        }

        public void Log(string message, Category category, Priority priority)
        {
            if(string.IsNullOrEmpty(message))
            {
                return;
            }
            switch(category)
            {
                case Category.Debug:
                    Debug(message);
                    break;
                case Category.Exception:
                    Error(message);
                    break;
                case Category.Info:
                    Info(message);
                    break;
                case Category.Warn:
                    Fatal(message);
                    break;
            }
        }
    }
}
