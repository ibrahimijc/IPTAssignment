using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k152131_Q2
{

        sealed public class DynamicIntArray {
        int Csize;
        int capacity;
        int [] arr ;

        
        public  DynamicIntArray()
        {
            Csize = 0;
            capacity = 10;
            arr = new int[capacity];
        }
        public  DynamicIntArray(int initcap)
        {
            Csize = 0;
            capacity = initcap;
            arr = new int[capacity];

        }
        public void Add(int s)
        {
            arr[Csize] = s;
            Csize++;

            if (Csize == capacity -1 )
            {
                //extend size of array
                Resize();

            }
        }


        

        void Resize()
        {
            int[] tempArr = new int [capacity];
            for (int i=0; i<capacity;i++)
            {
                tempArr[i] = arr[i];
            }

            capacity = capacity * 2;
            arr = new int[capacity];

            for (int i = 0; i < capacity/2; i++)
            {
                arr[i] = tempArr[i];
            }


        }

        public int Get(int index)
        {
            if (index < Csize)
                return arr[index];
            
                return -1;
                
        }

        public int IndexOf(int value)
        {
            for (int i =0; i < Csize; i++)
            {
                if (arr[i] == value)
                    return i; // index
            }

            return -1;
        }

    }

    class Program
    {
        //testing
        static void Main(string[] args)
        {
            DynamicIntArray b = new DynamicIntArray();
            for (int i=0;i<1000;i++)
            b.Add(i);

            for (int i = 0; i < 1000; i++)
               Console.WriteLine (b.IndexOf(1));

        }
    }
}
