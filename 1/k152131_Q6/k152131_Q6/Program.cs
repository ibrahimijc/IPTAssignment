using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using k152131_Q4;
namespace k152131_Q6
{
    class Program
    {
        static void Main(string[] args)
        {
            int oneMill = 1000000;
            Program p = new Program();

            DynamicIntArray<Decimal> Dyn = new DynamicIntArray<Decimal>();
            List<Decimal> lis = new List<decimal>();
            Decimal[] d = new Decimal[oneMill];


            DynamicIntArray<String> DynS = new DynamicIntArray<String>();
            List<String> lisS = new List<String>();
            String[] dS = new String[oneMill];



            DynamicIntArray<Boolean> DynB = new DynamicIntArray<Boolean>();
            List<Boolean> lisB = new List<Boolean>();
            Boolean[] dB = new Boolean[oneMill];


            for (int i=0; i<oneMill; i++)
            {
                //Decimal 
                Dyn.Add(i);
                lis.Add(i);
                d[i] = i;


                //String
                DynS.Add("String"+i);
                lisS.Add("String"+i);
                dS[i] = "String"+i;


                // Boolean
                bool addBool = true;
                if (i % 2 == 0)
                    addBool = false;

                DynB.Add(addBool);
                DynB.Add(addBool);
                dB[i] = addBool;

            }

            Console.WriteLine("*****************\n");
            Console.WriteLine(" Decimal \n");
            p.ComparePerformance(lis, d, Dyn);
            Console.WriteLine("\n*****************\n");



            Console.WriteLine("*****************\n");
            Console.WriteLine(" String ");
            p.ComparePerformance(lisS, dS, DynS);
            Console.WriteLine("\n*****************\n");


            Console.WriteLine("*****************\n");
            Console.WriteLine(" Boolean ");
            p.ComparePerformance(lisB, dB, DynB);
            Console.WriteLine("\n*****************\n");


        }


        public void ComparePerformance<E>(List<E> listArray, E [] csArr, DynamicIntArray<E> dynArr ) where E : IComparable
        {
            // Will Compare performance by searching element..
            // All the elements will have same data and size.. Fair to Compare.
            int index;
            Random rand = new Random();
            E find = csArr[rand.Next(900000,1000000)]; // picks one element on random but from almost end so that it takes time
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            index = Array.IndexOf(csArr, find);
         
            stopwatch.Stop();
            long ts = stopwatch.ElapsedMilliseconds ;
            Console.WriteLine("C# Array\nIndex "+index+ "\nTime : "+ts+ "Milliseconds\n");

            ts = 0; 
            stopwatch.Reset();
            stopwatch.Restart();
            index = listArray.IndexOf(find);
            stopwatch.Stop();
            ts = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("List\nIndex " + index + "\nTime : " + ts + " Milliseconds\n");


            ts = 0;
            stopwatch.Reset();
            stopwatch.Restart();
            index = dynArr.IndexOf(find);
            stopwatch.Stop();
            ts = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Dynamic Array\nIndex " + index + "\nTime : " + ts + " Milliseconds");


        }

    }
}

