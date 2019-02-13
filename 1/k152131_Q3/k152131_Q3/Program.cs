using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using k152131_Q2;

namespace k152131_Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            int oneMill = 1000000;
            DynamicIntArray Darr = new DynamicIntArray(oneMill);
            int [] Carray = new int [oneMill];
            ArrayList  Aarray  = new ArrayList(oneMill);
            List<int> Larray = new List<int>(oneMill);
            Random rand = new Random();
            for (int i=0; i<oneMill; i++)
            {
                int r = rand.Next(10000);

                Carray[i] = r;
                Aarray.Add(r);
                Larray.Add(r);
                Darr.Add(r);
            }

            // Traversal 
            int sum = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (int i in Carray)
            {
                sum = sum + i;
            }
            stopWatch.Stop();

            long ts = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("C# Array        :  Sum " + sum + " Time " + ts +" MilliSeconds");
            //   Console.WriteLine(sum + " " + seconds  *1000000 + "   " );
            //   Console.WriteLine(date2.Subtract(date1).TotalMilliseconds.ToString());

            stopWatch.Reset();

            ts = 0;
            sum = 0;
            stopWatch.Start();
            foreach (int i in Aarray)
            {
                sum = sum + i;
            }
            stopWatch.Stop();
            ts = stopWatch.ElapsedMilliseconds; 
            Console.WriteLine("ArrayList       :  Sum "+sum + " Time " + ts + " MilliSeconds");


            stopWatch.Reset();

            sum = 0;
            ts = 0;
            stopWatch.Start();
            foreach (int i in Larray)
            {
                sum = sum + i;
            }
            stopWatch.Stop();
            ts = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("LIST            :  Sum " + sum + " Time " + ts + " MilliSeconds");



            stopWatch.Reset();

            sum = 0;
            ts = 0;
            stopWatch.Start();
            for (int i=0; i<oneMill;i++)
            {
                sum = sum + Darr.Get(i);
            }
            stopWatch.Stop();
            ts = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("DynamicIntArray :  Sum " + sum + " Time " + ts + " MilliSeconds");

            int[] fiveRand = new int[5];
            for (int i=0; i<5;i++)
            {
                Console.WriteLine(rand.Next(995082, oneMill));
                fiveRand[i] = Darr.Get(rand.Next(999175, oneMill)); // indexes random number between 0 and 1 million adds value at that position to array
            }

            for (int i=0;i<5;i++)
            {
                // For C# Array
                ts = 0;
                stopWatch.Reset();
                stopWatch.Start();
                Array.IndexOf(Carray, fiveRand[i]);
                stopWatch.Stop();
                ts = stopWatch.ElapsedMilliseconds;
                Console.WriteLine("Time taken to Search "+fiveRand[i] +" in C# Array  : " + ts);


                // For ArrayList
                ts = 0;
                stopWatch.Reset();
                stopWatch.Start();
                Aarray.IndexOf(fiveRand[i]); 
                stopWatch.Stop();
                ts = stopWatch.ElapsedMilliseconds;
                Console.WriteLine("Time taken to Search " + fiveRand[i] + " in Linked List  : " + ts);



                // For List
                ts = 0;
                stopWatch.Reset();
                stopWatch.Start();
                Larray.IndexOf(fiveRand[i]);
                stopWatch.Stop();
                ts = stopWatch.ElapsedMilliseconds;
                Console.WriteLine("Time taken to Search " + fiveRand[i] + " in Linked List  : " + ts);



                // For List
                ts = 0;
                stopWatch.Reset();
                stopWatch.Start();
                Darr.IndexOf(fiveRand[i]);
                stopWatch.Stop();
                ts = stopWatch.ElapsedMilliseconds;
                Console.WriteLine("Time taken to Search " + fiveRand[i] + " in Linked List  : " + ts);


                Console.WriteLine("\n\n\n");
            }


        }
    }
}
