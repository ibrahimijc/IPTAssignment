using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K152131_Q3
{
    class FileManager
    {
        String username;
        String[] filenames; // Filenames associated with this 
        int count;

        public FileManager(String name)
        {
            count = 0;
            username = name;
        }
        public string getUsername()
        {
            return username;
        }

        public void setUserName(string name)
        {
            username = name;
        }

        public void setFiles(string[] f)
        {
            filenames = new string[f.Length];

            for (int i = 0; i < f.Length; i++)
            {
                filenames[i] = f[i];
            }

        }

        public int getCount()
        {
            return count;
        }

        public void setCount(int arg)
        {
            this.count = arg;
        }

        public string[] getFileNames()
        {
            return filenames;
        }



    }


}
