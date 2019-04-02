using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace K152131_Q3
{
    class HandlePatient
    {
        String[] folders; // folder names of patients

        List<FileManager> FilesTracker = new List<FileManager>();


        public HandlePatient()
        {
            string path = ConfigurationManager.AppSettings["pathjson"];
            folders = Directory.GetDirectories(path);


        }
        public bool isPresent(string name)
        {
            for (int i = 0; i < FilesTracker.Count; i++)
            {
                if (FilesTracker[i].getUsername().Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(string name)
        {
            for (int i = 0; i < FilesTracker.Count; i++)
            {
                if (FilesTracker[i].getUsername().Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }

        public void DeserializeEach(string userpath, string name)
        {
            List<userDetail> records = new List<userDetail>();

            string email = "";
            using (StreamReader sr = File.OpenText(ConfigurationManager.AppSettings["pathjson"] + name + "\\user-profile\\User-Profile.json"))
            {
                string json = sr.ReadToEnd();
                JObject obj = JObject.Parse(json);
                email = (string)obj["email"];
                // Console.WriteLine(email);
            }




            String[] files;
            //     Console.WriteLine(userpath);
            //userpath += "\\user-detail\\";
            //files = Directory.GetFiles(userpath,"*.json");


            DirectoryInfo info = new DirectoryInfo(userpath);
            FileInfo[] myFiles = info.GetFiles("*.json").OrderBy(p => p.CreationTime).ToArray();
            int trace = 0;
            files = new String[myFiles.Length];
            foreach (FileInfo x in myFiles)
            {
                files[trace] = x.Directory + "\\" + x.Name;
                //  Console.WriteLine("FileName  " + x.Name + "  Creation Time " + x.LastWriteTime);
                trace++;
            }




            int index = -1;
            if (!isPresent(name)) // If this name does not exist on FileTracker List
            {
                FilesTracker.Add(new FileManager(name));
                index = IndexOf(name);
                FilesTracker[index].setFiles(files);

            }
            else
            {
                index = IndexOf(name);
                FilesTracker[index].setFiles(files);
                //Console.WriteLine("Deleted");

            }


            for (int i = FilesTracker[index].getCount(); i < files.Length; i++)
            {
                List<userDetail> Individualrecords = new List<userDetail>();
                string json;
                //Console.WriteLine("FileName : "+files[i]);
                using (StreamReader r = new StreamReader(files[i]))
                {
                    json = r.ReadToEnd();
                    Individualrecords = JsonConvert.DeserializeObject<List<userDetail>>(json);

                    foreach (userDetail user in Individualrecords)
                    {
                        records.Add(user);
                        records[records.IndexOf(user)].email = email;
                    }
                    r.Close();
                }
            }
            FilesTracker[index].setCount(files.Length);
            string consolidatedpath = ConfigurationManager.AppSettings["consolidatedpath"];
            for (int i = 0; i < records.Count; i++) // this 0 is ok
            {
                // JsonSerializer serializer = new JsonSerializer();
                string tempFilepath = consolidatedpath + name + ".json";
                if (!File.Exists(tempFilepath))
                {
                    //  Console.WriteLine(tempFilepath);
                    using (StreamWriter file = File.AppendText(tempFilepath))
                    {
                        var jsonToOutput = JsonConvert.SerializeObject(records, Formatting.Indented);
                        file.Write(jsonToOutput.ToString());
                        file.Close();
                    }

                }
                else
                {
                    var jsonToOutput = "";
                    using (StreamReader sr = File.OpenText(tempFilepath))
                    {
                        var InitialJson = "";
                        jsonToOutput = "";
                        InitialJson = sr.ReadToEnd();
                        var array = JArray.Parse(InitialJson);
                        JArray itemToAdd = new JArray();
                        JArray a = (JArray)JToken.FromObject(records);

                        for (int x = 0; x < a.Count; x++)
                        {
                            array.Add(a[x]);
                        }
                        jsonToOutput = JsonConvert.SerializeObject(array, Newtonsoft.Json.Formatting.Indented);
                        sr.Close();
                    }

                    using (StreamWriter sw = new StreamWriter(tempFilepath))
                    {


                        sw.Write(jsonToOutput.ToString());

                    }
                }

            }


        }

        public bool anyNewDirectory()
        {
            if (Directory.GetDirectories(ConfigurationManager.AppSettings["pathjson"]).Length > FilesTracker.Count)
            {
                folders = Directory.GetDirectories(ConfigurationManager.AppSettings["pathjson"]);
                //  foreach (string s in folders)
                //   Console.WriteLine(s);
                return true; // new files must have been added since larger size
            }
            else
                return false;
        }
        public void CallDeserializeForEach(string userpath, string name)
        {


        }
        public bool anyNewFile()
        {
            bool ret = false;
            for (int i = 0; i < FilesTracker.Count; i++)
            {
                string name = FilesTracker[i].getUsername();
                string path = ConfigurationManager.AppSettings["pathjson"] + name + "\\user-detail\\";

                if (Directory.GetFiles(path, "*.json").Length > FilesTracker[i].getFileNames().Length)
                {
                    //Console.WriteLine("Done");
                    DeserializeEach(path, name);
                    ret = true;
                }


            }

            return ret;
        }

        public void DeserializePatientsAndMerge()
        {

            for (int i = 0; i < folders.Length; i++)
            {

                string name = folders[i].Replace(ConfigurationManager.AppSettings["pathjson"], "");
                //Console.WriteLine(name);
                FilesTracker.Add(new FileManager(name)); // For Directories
                DeserializeEach(folders[i], name);
            }


        }

    }

}
