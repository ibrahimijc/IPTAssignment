using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace k152131_Q1
{
    class Program
    {
        static void Main(string[] args)
        {

            String line = "";
            try
            {   
                using (StreamReader sr = new StreamReader("Q1Input.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    int d = 0;
                    String s1 = "", s2 = "";

                   
                    byte b1 =0, b2=0; // 16 bits.. Data will be stored in it..
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (d < 8) {
                             s1 += line[line.Length - 1];  // string of 8 bits
                             
                        }
                        else
                        {
                            s2 += line[line.Length - 1]; // string of 8 bits
                        }
                        d++;
                    }
                 
                    b1 = (byte)Program.bitstoint(s1); //8 bit will only range from 0 to 255
                    b2 = (byte)Program.bitstoint(s2);

                    Console.WriteLine(b1 + "  " + b2); // Bits stored to number representing a state
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static int bitstoint(string s) // CONVERTS BIT TO INT
        {
            int number = 0;
            double power =0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                number = number + (int.Parse(s[i] +"") * (int)Math.Pow(2, power));
                power++;
            }
            return number;
        }


    }




}

