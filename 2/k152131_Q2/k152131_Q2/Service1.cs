using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Timers;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Xml;
using Newtonsoft.Json;



namespace k152131_Q2
{

    class Patient
    {
        String name;
        String Recordname;
        int age;
        string gender;
        string email;
        string time;
        int bpm;
        int confidencelevel;

        public Patient(string name, int age, string gender, string email, string time, int bpm, int confidencelevel)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.email = email;
            this.time = time;
            this.bpm = bpm;
            this.confidencelevel = confidencelevel;
        }

        public Patient(string name, int age, string gender, string email, string time, int bpm, int confidencelevel, string rec)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.email = email;
            this.time = time;
            this.bpm = bpm;
            this.confidencelevel = confidencelevel;
            this.Recordname = rec;
        }

        public void setRecordName(String rec)
        {
            this.Recordname = rec;
        }

        public String getRecordName()
        {
            return Recordname;
        }

        public override String ToString()
        {
           // Console.WriteLine("Name :" + name);
           // Console.WriteLine("Age :" + age);
           // Console.WriteLine("Email :" + email);
           // Console.WriteLine("Gender :" + gender);
           // Console.WriteLine("Time :" + time);
          //  Console.WriteLine("BPM :" + bpm);
          //  Console.WriteLine("Confidence :" + confidencelevel);

            return "";

        }


        public string getname()
        {
            return name;
        }

        public int getage()
        {
            return age;
        }

        public string getgender()
        {
            return gender;
        }

        public string getemail()
        {
            return email;
        }

        public string gettime()
        {
            return time;
        }

        public int getbmp()
        {
            return bpm;
        }
        public int getconfidence()
        {
            return confidencelevel;
        }


        public void setname(string name)
        {
            this.name = name;
        }

        public void setage(int age)
        {
            this.age = age;
        }

        public void setgender(string gender)
        {
            this.gender = gender;
        }

        public void setemail(string email)
        {
            this.email = email;
        }

        public void settime(string time)
        {
            this.time = time;
        }

        public void setbpm(int bpm)
        {
            this.bpm = bpm;
        }
        public void setconfidence(int confidencelevel)
        {
            this.confidencelevel = confidencelevel;
        }






    }

    /*
     Handle Patient class to handle patients reading from XML and writing to JSON
         
         */

    class HandlePatient
    {
        List<Patient> record = new List<Patient>();
        int readFiles = 0;
        int writeFiles = 0; // For WriteJSON Function
        DateTime[] modifiedDate;
        string[] fileArray;

        public HandlePatient()
        {
            //  DateTime lastModified = System.IO.File.GetLastWriteTime("C:\foo.bar");
        }

        public void WriteJSON()
        {
            JArray userProfileArray = new JArray();
            JArray heartratearray = new JArray();



            for (int i = writeFiles; i < record.Count; i++)
            {

               // Console.WriteLine(record[i]);
                dynamic userProfile = new JObject();
                userProfile.Name = record[i].getname();
                userProfile.gender = record[i].getgender();
                userProfile.age = record[i].getage();
                userProfile.email = record[i].getemail();
              //  Console.WriteLine(userProfile);

                dynamic heart_rate = new JObject();
                heart_rate.dateTime = record[i].getRecordName() + record[i].gettime();

                heart_rate.Add(new JProperty("value", new JObject()));
                heart_rate.value.Add(new JProperty("bpm", new JValue(record[i].getbmp())));
                heart_rate.value.Add(new JProperty("confidence", new JValue(record[i].getconfidence())));


                heartratearray.Add(heart_rate);
                userProfileArray.Add(userProfile);
                string userProfilepath = ConfigurationManager.AppSettings["pathjson"] + record[i].getname() + "\\user-profile\\User-Profile.json";
                string[] dates = record[i].getRecordName().Split('_');
                string heartRecordpath = ConfigurationManager.AppSettings["pathjson"] + record[i].getname() + "\\user-detail\\heart_rate-" + dates[2] + "-" + dates[1] + "-" + dates[0] + ".json";

                //File.WriteAllText(ConfigurationManager.AppSettings["pathjson"] + record[i].getname() + "\\user-detail\\test.json", userProfile.ToString());
                if (!File.Exists(userProfilepath))
                {
                    File.WriteAllText(userProfilepath, userProfile.ToString());
                }

                if (!File.Exists(heartRecordpath))
                {
                    // File.WriteAllText(heartRecordpath, heart_rate.ToString());

                    using (StreamWriter sw = File.AppendText(heartRecordpath))
                    {

                        sw.Write("[");
                        sw.Write(heart_rate.ToString());
                        sw.Write("]");
                    }



                }
                else // append
                {

                    //    FileStream fileStream = new FileStream(heartRecordpath, FileMode.OpenOrCreate,FileAccess.ReadWrite, FileShare.None);

                    var jsonToOutput = "";
                    using (StreamReader sr = File.OpenText(heartRecordpath))
                    {
                        var InitialJson = "";
                        jsonToOutput = "";
                        InitialJson = sr.ReadToEnd();
                        var array = JArray.Parse(InitialJson);
                        // Console.WriteLine(array.ToString());
                        var itemToAdd = new JObject();
                        itemToAdd = heart_rate;
                        array.Add(itemToAdd);
                        jsonToOutput = JsonConvert.SerializeObject(array, Newtonsoft.Json.Formatting.Indented);
                        sr.Close();

                    }

                    using (StreamWriter sw = new StreamWriter(heartRecordpath))
                    {


                        sw.Write(jsonToOutput.ToString());

                    }


                }



            }
            writeFiles = record.Count;
            // Console.WriteLine(heartratearray);
            // Console.WriteLine(userProfileArray);
            File.WriteAllText(ConfigurationManager.AppSettings["pathjson"] + "b.json", heartratearray.ToString());
            //  Console.WriteLine("Written");
        }

        public void checkAndCreateDirectories(String name)
        {

            if (!Directory.Exists(ConfigurationManager.AppSettings["pathjson"] + name))
            {
                Directory.CreateDirectory(ConfigurationManager.AppSettings["pathjson"] + name);
            }

            if (!Directory.Exists((ConfigurationManager.AppSettings["pathjson"] + name + "\\User-Profile")))
            {
                Directory.CreateDirectory((ConfigurationManager.AppSettings["pathjson"] + name + "\\user-profile"));
                Directory.CreateDirectory((ConfigurationManager.AppSettings["pathjson"] + name + "\\user-detail"));

            }


        }

        public void loadFiles()
        {
            string filename = "";
            filename += ConfigurationManager.AppSettings["pathxml"].ToString() + "";
            fileArray = Directory.GetFiles(filename, "*.xml");
        }




        public void ReadXML()
        {


            loadFiles(); // Files are loaded in fileArray

            // If files Increases FileArrayLenght will automatically increase. Start reading files after the lastone
            for (int i = readFiles; i < fileArray.Length; i++)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileArray[i]);

                XmlNodeList userNodes = xmlDoc.SelectNodes("//Patients/Patient");
                foreach (XmlNode userNode in userNodes)
                {
                    string rec = fileArray[i];
                    rec = rec.Replace("PatientDetails_", "");
                    rec = rec.Replace(".xml", "");
                    rec = rec.Replace(ConfigurationManager.AppSettings["pathxml"], ""); // File date
                    //Console.WriteLine(rec);

                    string name = (userNode.Attributes["name"].InnerXml);
                    checkAndCreateDirectories(name);
                    int bpm = ((int.Parse(userNode["bpm"].InnerXml)));
                    int age = ((int.Parse(userNode.Attributes["age"].InnerXml)));
                    string time = (userNode["time"].InnerXml);
                    int confidence = ((int.Parse(userNode["Confidence"].InnerXml)));
                    string gender = (userNode.Attributes["gender"].InnerXml);
                    string email = (userNode.Attributes["email"].InnerXml);
                    record.Add(new Patient(name, age, gender, email, time, bpm, 0, rec));

                }



            }
            readFiles = fileArray.Length; // So that it doesn't read file again.. For Windows Service


        }

    }
    /* Class Handle Patient Ends here*/

    






    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = int.Parse(ConfigurationManager.AppSettings["waitInms"]); //number in milisecinds  equal to 5 mins
            timer.Enabled = true;
            
        }


        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            
            HandlePatient p = new HandlePatient();
            p.ReadXML();
            p.WriteJSON();

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
            WriteToFile("Service Stopped at " + DateTime.Now);
        }
    }
}
