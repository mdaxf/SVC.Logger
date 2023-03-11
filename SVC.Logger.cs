using System;
using System.IO;


namespace SVC.MessageReceiver
{
    public class SVCLogger
    {
        private string loggerfolder = "c:\\temp";
        private string loglevel = "";
        public SVCLogger()
        {
            string folder = SVCCommon.AppConfigValue("LogFolder");

            if (folder != "")
                loggerfolder = folder;
            loglevel = SVCCommon.AppConfigValue("Loglevel").Trim().ToLower();

        }
        public void InfoLoger(string logMessage)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "     " + logMessage);

            LogWriter(logMessage,"info");
            LogWriter(logMessage, "debug");

        }
        public void DebugLoger(string logMessage)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "     " + logMessage);
            
            if(loglevel == "debug")
                LogWriter(logMessage, "debug");

        }
        private void LogWriter(string logMessage, string loglevel)
        {
           
            try
            {
                using (StreamWriter w = File.AppendText(loggerfolder + "\\" +loglevel +"_log_" + DateTime.Now.ToString("yyyyMMdd") + ".log"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }


    }
}
