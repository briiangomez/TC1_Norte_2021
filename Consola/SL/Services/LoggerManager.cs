using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Services
{
    public sealed class LoggerManager
    {
        private string filePath;

        #region Singleton
        private readonly static LoggerManager _instance = new LoggerManager();

        public static LoggerManager Current
        {
            get
            {
                return _instance;
            }
        }

        private LoggerManager()
        {
            filePath = ConfigurationManager.AppSettings["filePathLogger"];
        }
        #endregion

        public void Write(string message, EventLevel eventLevel)
        {
            //REFACTORIZAR CON BLL + DAL
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine($"{DateTime.Now.ToString("dd-MM-yy hh:mm:ss")} [Severity {eventLevel.ToString()}] : {message}");
            }
        }
    }


    //public class LoggerManager
    //{
    //    private string filePath;

    //    private static LoggerManager loggerManager;

    //    private static object mutex = new object();

    //    private LoggerManager()
    //    {
    //        //PARAMETRIZACIÓN...
    //        filePath = ConfigurationManager.AppSettings["filePathLogger"];
    //    }

    //    public static LoggerManager GetInstance()
    //    {
    //        if (loggerManager == null)
    //        {
    //            lock (mutex)
    //            {
    //                if (loggerManager == null)
    //                {
    //                    loggerManager = new LoggerManager();
    //                }
    //            }
    //        }

    //        return loggerManager;
    //    }

    //    public void Write(string message, EventLevel eventLevel)
    //    {
    //        using (StreamWriter streamWriter = new StreamWriter(filePath, true))
    //        {
    //            streamWriter.WriteLine($"{DateTime.Now.ToString("dd-MM-yy hh:mm:ss")} [Severity {eventLevel.ToString()}] : {message}");
    //        }
    //    }
    //}
}
