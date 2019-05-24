using System;
using System.Configuration;
using System.IO;

using System.ServiceProcess;

using System.Timers;

namespace k152131_Q4a
{
    public partial class service4a : ServiceBase
    {
        Timer timer = new Timer(); // name space(using System.Timers;)  
        HandlePatients h;
        public service4a()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            h = new HandlePatients();
            try {
                
                h.ReadJson();
            }
            catch (Exception e)
            {
                WriteToFile(e.ToString());
            }
            
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = double.Parse(ConfigurationManager.AppSettings["timeInterval"]); //number in milisecinds  
            timer.Enabled = true;


        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);
            try
            {

                h.ReadJson();
            }
            catch (Exception ex)
            {
                WriteToFile(ex.ToString());
            }
        }
        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
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
