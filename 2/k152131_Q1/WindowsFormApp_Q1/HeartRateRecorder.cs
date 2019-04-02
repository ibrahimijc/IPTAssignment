using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using System.Xml.Linq;

namespace WindowsFormApp_Q1
{
    

    public class HeartRateRecorder
    {
        List<bpm> Patient_Record = new  List<bpm>() ;
        int resumeCount = 0;
        public HeartRateRecorder()
        {
            ConfidenceLevel = 0;
        }

        String name {  get; set;}
        public void setName(string nam)
        {
            this.name = nam;

        }

        public void addBPM(String s1, String s2)
        {
            Patient_Record.Add(new bpm(s1,s2));
        }

        DateTime DateofBirth {  get;set;}
        public void setDOB(DateTime date)
        {
            this.DateofBirth = date;

        }
        char gender{   get; set;}

        public void setGender(char gen)
        {
            this.gender = gen;
        }

       

        String Email {  get; set; }
        public void setEmail(string em)
        {
            this.Email = em;
        }


        int age { get; set; }

        public void setAge(DateTime age)
        {
            DateTime today = DateTime.Today;
            int res =  today.Year - age.Year ;
            this.age = res;

        }
        

        int ConfidenceLevel {  get;set; }

        public void printToXML()
        {


            DateTime today = DateTime.Today;
            String filename = ConfigurationManager.AppSettings["path"].ToString() + "PatientDetails_" + today.Day + "_" + today.Month + "_" + today.Year;
            filename += ".xml";


            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            //xmlWriterSettings.NewLineOnAttributes = true;

            using (XmlWriter writer = XmlWriter.Create(filename,xmlWriterSettings))
            {
               

                writer.WriteStartElement("Patients");

                int i = 0;
                for ( i = 0; i < Patient_Record.Count; i++)
                {
                    writer.WriteStartElement("Patient");
                    writer.WriteAttributeString("name", name);
                    writer.WriteAttributeString("age", age + "");
                    writer.WriteAttributeString("email", Email);
                    writer.WriteAttributeString("gender", gender + "");
                    writer.WriteElementString("bpm", Patient_Record[i].getbpm() +"");
                    writer.WriteElementString("time", Patient_Record[i].getTime()+"");
                    writer.WriteElementString("Confidence", ConfidenceLevel + "");
                    writer.WriteEndElement();

                }
                resumeCount = i;
                writer.WriteEndElement();
            }
        }


        public void appendToXML()
        {
            DateTime today = DateTime.Today;

            // String filename = "PatientDetails_" + today.Day + "_" + today.Month + "_" + today.Year;
            String filename = ConfigurationManager.AppSettings["path"].ToString() + "PatientDetails_" + today.Day + "_" + today.Month + "_" + today.Year;
            filename += ".xml";

            XDocument xDocument = XDocument.Load(filename);
            XElement root = xDocument.Element("Patients");
            IEnumerable<XElement> rows = root.Descendants("Patient");
            XElement firstRow = rows.Last();
            for (int i = resumeCount; i < Patient_Record.Count; i++)
            {
                firstRow.AddAfterSelf(
                   new XElement("Patient",
                   new XAttribute("name", name),
                   new XAttribute("age", age),
                   new XAttribute("email", Email),
                   new XAttribute("gender", gender+""),
                   new XElement("bpm", Patient_Record[i].getbpm()),
                   new XElement("time", Patient_Record[i].getTime()),
                   new XElement("Confidence", ConfidenceLevel)));
            }
            xDocument.Save(filename);
        }


        public bool checkIfTodayFileExist()
        {
            DateTime today = DateTime.Today;
            String filename = ConfigurationManager.AppSettings["path"].ToString() + "PatientDetails_" + today.Day + "_" + today.Month + "_" + today.Year;
            //String filename = "PatientDetails_" + today.Day + "_" + today.Month + "_" + today.Year;
            filename += ".xml";

            if (File.Exists(filename))
            {
                return true;
            }

            return false; // file not exist
        }

        

    }


    public class bpm
    {
        String time { get; set; }
        String bpm_rate { get; set; }

        public bpm (string rate,string time)
        {   
            this.time = time;
            this.bpm_rate = rate;
        }
        
        public string getbpm()
        {
            return bpm_rate;
        }

       
        public string getTime()
        {
            return time; 
        }


    }

}
