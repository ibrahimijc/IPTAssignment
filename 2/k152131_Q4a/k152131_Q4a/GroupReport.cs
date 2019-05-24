using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k152131_Q4a
{
    class GroupReport
    {
        int AgeGroupVal;
        float avg;
        float high;
        float low;
        List<int> bpm;
        int updated; // to keep track wether this age group is present or not.
        static int count = 0;
        public GroupReport()
        {
            bpm = new List<int>(10);
            AgeGroupVal += count + 1;
            count++;
            updated = -1;
        }

        public void Summarize()
        {
            SetAll();
        }





        public void Addbpm(int bp)
        {
            bpm.Add(bp);
        }

        public float getAverage()
        {
            return avg;
        }

        public int GetAgeValue()
        {
            return this.AgeGroupVal;
        }

        public float GetHigh()
        {
            return this.high;
        }

        public float GetLow()
        {
            return this.low;
        }

        public float SetAll()
        {
            high = bpm[0];
            low = bpm[0];
            float sum = 0;
            for (int i = 1; i < bpm.Count; i++)
            {
                /*
                 * It is confusing that what must be a high of age group
                 * that is how will you subtract a range from 220 ? What will be High?
                 * So keeping maximum as high now.. Just for the Group file.
                 * Patch not expected in future release :P 
                */
                if (bpm[i] > high)
                    high = bpm[i];
                if (bpm[i] < low)
                    low = bpm[i];


                sum += bpm[i];
            }

            sum = sum / bpm.Count;
            avg = sum;
            return sum;
        }


        public int GetUpdate()
        {
            return updated;
        }

        public void SetUpdate(int s)
        {
            updated = s;
        }


    }
}
