using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace K152131_Q3
{
    public partial class Service3 : ServiceBase
    {
        Timer timer = new Timer();
        HandlePatient h;
        public Service3()
        {
            
            InitializeComponent();
            
        }

        protected override void OnStart(string[] args)
        {
            h = new HandlePatient();
            h.DeserializePatientsAndMerge();
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = int.Parse(ConfigurationManager.AppSettings["waitInms"]); //number in milisecinds  equal to 5 mins
            timer.Enabled = true;
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            try
            {
                if (h.anyNewDirectory())
                {
                    //   Console.WriteLine("New comes");
                    // Console.ReadKey(); // Just for break..
                    h.DeserializePatientsAndMerge();
                }

                if (h.anyNewFile())
                {
                    //anyNewfile function will merge the files
                }
            }
            catch(Exception a)
            {
                WriteToFile("Error is " + a.Message);
            }
            finally
            {
                OnStop();
            }

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


        protected override void OnStop()
        {

        }
    }
}
