using System;
using System.IO;
using System.ServiceProcess;
using System.Configuration;
using System.Timers;

namespace k152131_Q4b
{
    public partial class Serviceb : ServiceBase
    {
        Timer timer = new Timer();
        EmailUpdater eu = new EmailUpdater();
        public Serviceb()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            eu.ReadEmails();
            eu.sendMails(); // On initial
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = double.Parse(ConfigurationManager.AppSettings["timeInterval"]); //number in milisecinds  
            timer.Enabled = true;
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
           if (eu.FileModified())
            {
                try
                {
                    eu.ReadEmails();
                    eu.sendMails();
                }
                catch (Exception es)
                {
                    WriteToFile(es.ToString());
                }
            }
        }



        protected override void OnStop()
        {
            WriteToFile("Service is stopped  at " + DateTime.Now);

        }


        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }


    }
}
