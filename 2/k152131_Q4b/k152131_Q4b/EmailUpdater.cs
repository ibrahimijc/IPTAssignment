using System;
using System.Collections.Generic;
using System.Xml;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace k152131_Q4b
{
    class EmailUpdater
    {
        List<string> emails = new List<string>();
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        string userChartpath = ConfigurationManager.AppSettings["UserChartPath"];
        DateTime lastmodification;


        public EmailUpdater()
        {
            string path = userChartpath + "UserChart.xml";
            lastmodification = File.GetLastWriteTime(path); // record modification time on first time
        }

        public bool FileModified()
        {
            string path = userChartpath + "UserChart.xml";
            DateTime tempmodification = File.GetLastWriteTime(path); // record on first time

            if(tempmodification.Equals(lastmodification))
            return false; // File not modified
            else
            {
                lastmodification = tempmodification;
                return true;
            }


        }
        public void ReadEmails()
        {
            string path = ConfigurationManager.AppSettings["UserChartPath"];
            path += "UserChart.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList elemList = doc.GetElementsByTagName("User");

            for (int i = 0; i < elemList.Count; i++)
            {

                if (elemList[i].Attributes["Email"] != null)
                {
                    string email = elemList[i].Attributes["Email"].Value;
                    if (!emails.Contains(email))
                    {
                        emails.Add(email);
                    }
                }
            }

        }

        public void sendMails()
        {
            string subject = "Update UserChart.xml has been updated";
            string body = "Dear Patient \n\n\n\n UserChart.xml has been updated";
            for (int i = 0; i < emails.Count; i++)
            {
                    sendMail(emails[i], subject, body);
            }
        }



        public bool sendMail(string To, String subject, String body)
        {
            //Console.WriteLine(To);
            try
            {
               

                mail.From = new MailAddress(ConfigurationManager.AppSettings["emailId"]);
                mail.To.Add(new MailAddress(To));
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;

                SmtpServer.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailId"], ConfigurationManager.AppSettings["password"]);

                SmtpServer.EnableSsl = true;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Send(mail);
                WriteToFile("Message Was Sent");
                return true;
            }
            catch (Exception ex)
            {
                WriteToFile(ex.ToString());
                WriteToFile("Message Not Sent");
                // MessageBox.Show(ex.ToString());
                //Console.WriteLine("Message Not sent ofcourse" + ex.ToString());
            }



            return false;
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
