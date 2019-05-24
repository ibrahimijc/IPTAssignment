using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;
using System.Xml;

namespace k152131_Q4a
{
    class HandlePatients
    {
        List<userDetail> records = new List<userDetail>();
        List<userChart> UsersChart = new List<userChart>();
        GroupReport[] gR = new GroupReport[10];

        int FileCount;

        public HandlePatients()
        {
            FileCount = 0;

            for (int i = 0; i < 10; i++)
                gR[i] = new GroupReport();

        }
        public void ReadJson()
        {
            List<userChart> user = new List<userChart>();

            string json = "";
            string path = ConfigurationManager.AppSettings["consolidatedpath"];
            try
            {

                String[] files = Directory.GetFiles(path, "*.json");


                for (int i = FileCount; i < files.Length; i++)
                {
                    List<userDetail> IndividualUserDetail = new List<userDetail>();

                    using (StreamReader r = new StreamReader(files[i]))
                    {
                        json = r.ReadToEnd();
                        IndividualUserDetail = JsonConvert.DeserializeObject<List<userDetail>>(json);


                        int Highest = -1, lowest = -1;
                        Double Range1, Range2;
                        int sum = 0; float avg = 0;
                        string email = IndividualUserDetail[1].email;
                        //Console.WriteLine(email + "email");
                        for (int x = 0; x < IndividualUserDetail.Count; x++)
                        {
                            //extract the highest beat
                            if (x == 0)
                            {
                                Highest = 220 - IndividualUserDetail[x].age;
                                lowest = IndividualUserDetail[x].val.bpm;


                            }
                            else
                            {
                               

                                if (IndividualUserDetail[x].val.bpm < lowest)
                                    lowest = IndividualUserDetail[x].val.bpm;
                            }

                            sum += IndividualUserDetail[x].val.bpm;
                            UpdateAgeGroup(IndividualUserDetail[x].age, IndividualUserDetail[x].val.bpm);

                        }

                        Range1 = Highest * 0.50;
                        Range2 = Highest * 0.85;
                        string name = files[i];
                        name = name.Replace(".json", "");
                        name = name.Replace(path, "");
                        avg = sum / IndividualUserDetail.Count;

                        UsersChart.Add(new userChart(name, email, Highest, lowest, avg, Range1, Range2));
                    }
                }

                finalizeAgeGroup();

                FileCount = files.Length;

                PrintToXML();
                WriteGroupReport();
            }
            catch (Exception exc)
            {
               
              //  Console.WriteLine("Exception {0}  Data {1}  ", exc.Message, exc.Data);
            }


        }


        public void WriteGroupReport()
        {

            String filename = ConfigurationManager.AppSettings["UserSummaryXML"] + "ConsolidatedChart";
            filename += ".xml";


            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;


            using (XmlWriter writer = XmlWriter.Create(filename, xmlWriterSettings))
            {


                writer.WriteStartElement("Patients");

                int i = 0;
                for (i = 0; i < gR.Length; i++)
                {
                    if (gR[i].GetUpdate() != -1)
                    {
                        writer.WriteStartElement("AgeGroup");
                        writer.WriteAttributeString("value", "" + gR[i].GetAgeValue());
                        writer.WriteElementString("High", gR[i].GetHigh() + "");
                        writer.WriteElementString("Average", gR[i].getAverage() + "");
                        writer.WriteElementString("Low", gR[i].GetLow() + "");
                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();
            }


        }


        public void finalizeAgeGroup()
        {
            for (int i = 0; i < gR.Length; i++)
            {
                if (gR[i].GetUpdate() != -1)
                {
                    gR[i].Summarize();

                }
            }
        }


        void UpdateAgeGroup(int age, int bpm)
        {
            int index = -1; // decide the index to work on i.e each group have their own index
            // 0 -> 0 to 10
            //1 -> 1 to 20
            switch (age)
            {
                case int n when (n <= 10):
                    index = 0;
                    break;
                case int n when (n > 10 && n <= 20):
                    index = 1;
                    break;
                case int n when (n > 20 && n <= 30):
                    index = 2;
                    break;
                case int n when (n > 30 && n <= 40):
                    index = 3;
                    break;
                case int n when (n > 40 && n <= 50):
                    index = 4;
                    break;
                case int n when (n > 50 && n <= 60):
                    index = 5;
                    break;
                case int n when (n > 60 && n <= 70):
                    index = 6;
                    break;
                case int n when (n > 70 && n <= 80):
                    index = 7;
                    break;
                case int n when (n > 80):
                    index = 8; // For every age group above 80
                    break;

            }
            if (gR[index].GetUpdate() == -1)
                gR[index].SetUpdate(1); // updated

            gR[index].Addbpm(bpm);


        }
        void PrintToXML()
        {
            DateTime today = DateTime.Today;
            String filename = ConfigurationManager.AppSettings["UserSummaryXML"] + "UserChart";
            filename += ".xml";


            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;


            using (XmlWriter writer = XmlWriter.Create(filename, xmlWriterSettings))
            {


                writer.WriteStartElement("Users");

                int i = 0;
                for (i = 0; i < UsersChart.Count; i++)
                {
                    writer.WriteStartElement("User");
                    writer.WriteAttributeString("Name", UsersChart[i].Name);
                    writer.WriteAttributeString("Email", UsersChart[i].Email);
                    writer.WriteElementString("High", UsersChart[i].HighestHeartRate + "");
                    writer.WriteElementString("Average", UsersChart[i].AvgHeartRate + "");
                    writer.WriteElementString("Low", UsersChart[i].LowestHeartRate + "");
                    writer.WriteElementString("TargetHeartRange", "" + UsersChart[i].Range1 + " " + UsersChart[i].Range1);

                    writer.WriteEndElement();

                }

                writer.WriteEndElement();
            }
        }
    }
}
