using System.Numerics;
using System.Runtime.InteropServices;
using System;

namespace CryptoGraphy
{
    internal class Program
    {

        public static void Crypto(string message, string key)
        {


            char[] keyArr = key.ToCharArray();
            Array.Sort(keyArr);
            int[] keyIndArr = new int[key.Length];

            int i = 0;
            foreach (char c in key)
            {
                keyIndArr[i] = Array.IndexOf(keyArr, c);
                i++;
            }
            char[] resArr = new char[message.Length];


            int n = keyIndArr.Length;


            for (int m = 0; m < message.Length; m++)
            {
                int g = keyIndArr[m % keyIndArr.Length];
                int h = m - m % n;

                Console.WriteLine(h + g);


                if (h + g >= resArr.Length)
                {
                    Console.WriteLine(message[m]);
                    resArr[resArr.Length - 1] = message[m];
                }
                else
                {
                    resArr[h + g] = message[m];
                }




            }

            foreach (char c in resArr)
            {
                Console.Write(c);

            }

        }
        public static string optimisedFuncNicoCipher(string message,string key)
        {
            string res = "";
            char[] keyArr = key.ToCharArray();
            Array.Sort(keyArr);
            int[] keyIndArr = new int[key.Length];

            int i = 0;
            foreach (char c in key)
            {
                keyIndArr[i] = Array.IndexOf(keyArr, c);
                keyArr[Array.IndexOf(keyArr, c)] = '.';
                i++;
            }
            


            int n = keyIndArr.Length;
            //Console.WriteLine(n);
            int numRows = (int)Math.Ceiling((double)message.Length / key.Length);
            char[,] mat = new char[numRows, n];
            int m = 0;
            for(int r = 0; r < numRows; r++)
            {
                for(int c=0;c < n; c++)
                {
                    if(m < message.Length)
                    {
                        mat[r, c] = message[m];
                        m++;
                    }
                    else
                    {
                        mat[r, c] = ' ';
                    }
                    
                   
                }
            }



           
            for (int r = 0; r < numRows; r++)
            {
                char[] teemp = new char[n];
                for (int c = 0; c < n; c++)
                {
                    //tmpRes[r, c] = mat[r, keyIndArr[c]];
                    if (mat[r,c] != ' ')
                    {
                        teemp[keyIndArr[c]] = mat[r, c];
                    }
                    
                    
                   

                }
                res += new string(teemp);
                //Console.WriteLine(new string(teemp));
            }


            //for (int r = 0; r < numRows; r++)
            //{
            //    for (int c = 0; c < n; c++)
            //    {

            //        Console.Write(mat[r, c]);

            //    }
            //    Console.WriteLine();
            //}

            //for (int r = 0; r < numRows; r++)
            //{
            //    for (int c = 0; c < n; c++)
            //    {
            //        Console.Write(tmpRes[r, c]);

            //    }
            //    Console.WriteLine();
            //}




            return res;

        }

    




        static void Main(string[] args)
        {
            string message1 = "edabitisamazing";
            string key1 = "matt";
            string message = "mubashirhassan";
            string key = "crazy";

            Console.WriteLine(optimisedFuncNicoCipher("iloveher", "612345"));
            Console.WriteLine(optimisedFuncNicoCipher(message, key));
            Console.WriteLine(optimisedFuncNicoCipher(message1, key1));



        }
    }
}