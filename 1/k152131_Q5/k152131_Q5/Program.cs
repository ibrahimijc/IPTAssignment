using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k152131_Q5
{
    class Program
    {
        sealed public class DynamicIntArray<T> : IList<T>
        {
            int Csize;
            int capacity;
            private List<T> myList
            {
                get;
                set;
            }

            public List<T>.Enumerator GetEnumerator()
            {
                return myList.GetEnumerator();
            }

            int[] arr;

            // IEnumerable Members

            public Array<T>.Enumerator GetEnumerator()
            {
                return arr.GetEnumerator();
            }


            public DynamicIntArray()
            {
                Csize = 0;
                capacity = 10;
                arr = new int[capacity];
            }
            public DynamicIntArray(int initcap)
            {
                Csize = 0;
                capacity = initcap;
                arr = new int[capacity];

            }
            public void Add(int s)
            {
                arr[Csize] = s;
                Csize++;

                if (Csize == capacity - 1)
                {
                    //extend size of array
                    Resize();

                }
            }




            void Resize()
            {
                int[] tempArr = new int[capacity];
                for (int i = 0; i < capacity; i++)
                {
                    tempArr[i] = arr[i];
                }

                capacity = capacity * 2;
                arr = new int[capacity];

                for (int i = 0; i < capacity / 2; i++)
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
                for (int i = 0; i < Csize; i++)
                {
                    if (arr[i] == value)
                        return i; // index
                }

                return -1;
            }

        }
        static void Main(string[] args)
        {
        }
    }
}
