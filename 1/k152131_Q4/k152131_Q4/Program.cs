using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k152131_Q4
{
    sealed public class DynamicIntArray<T> where T : IComparable
    {
        int Csize;
        int capacity;
        T[] arr;


        public DynamicIntArray()
        {
            Csize = 0;
            capacity = 10;
            arr = new T[capacity];
        }
        public DynamicIntArray(int initcap)
        {
            Csize = 0;
            capacity = initcap;
            arr = new T[capacity];

        }
        public void Add(T s)
        {
            arr[Csize] = s;
            Csize++;

            if (Csize == capacity - 1)
            {
                //extend size of array
                //Resize();
                Resize();
            }
        }


        void Resize()
        {
            T[] tempArr = new T[capacity];
            for (int i = 0; i < capacity; i++)
            {
                tempArr[i] = arr[i];
            }

            capacity = capacity * 2;
            arr = new T[capacity];

            for (int i = 0; i < capacity / 2; i++)
            {
                arr[i] = tempArr[i];
            }
        }



        public T Get(int index)
        {
            if (index < Csize)
                return arr[index];

            return (T) Convert.ChangeType(1,typeof(T));

        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < Csize; i++)
            {
                if (arr[i].CompareTo(value) == 0)
                    return i; // index
            }

            return -1;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            DynamicIntArray <String> darr = new DynamicIntArray<String>();
            
            for (int i = 0; i < 100000; i++)
                darr.Add("No " +i);
            
            for (int i=0;i<10;i++)
            {
                Console.WriteLine(darr.Get(i));
            }


            Console.WriteLine(darr.IndexOf("No 9"));
        }
    }
}
