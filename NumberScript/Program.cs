using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NumberScript
{
    class Program
    {
        //------------------------------------------------FULL SCREEN--------------------------------------------
        //const int STD_OUTPUT_HANDLE = -11;

        //[DllImport("kernel32.dll")]
        //static extern IntPtr GetStdHandle(int handle);

        //[DllImport("kernel32.dll", SetLastError = true)]
        //static extern bool SetConsoleDisplayMode(IntPtr ConsoleHandle, uint Flags, IntPtr NewScreenBufferDimensions);

        //static void Main()
        //{
        //    //var hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
        //    //SetConsoleDisplayMode(hConsole, 1, IntPtr.Zero);
        //    //Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);


        //--------------------------------------------------------------------------------------------------------------------------------------
        //    int[] mas = new int[] {5040 };

        //    Random rnd = new Random();
        //    for (int ctr = 0; ctr <= mas.Length; ctr++)
        //    {
        //       mas[ctr] = rnd.Next(1111111, 10000000); 
        //        Console.WriteLine("{0,3}    ", mas[ctr]);
        //        //if (ctr % 10 == 0)
        //            //Console.WriteLine();
        //    }






        //    Console.ReadLine();
        //}

        //----------------------------------------------------------------------------------------------------------------------------------------------------

        
        //----------------------------------------------------------Перестановка-------------------------------------------------------------------------------
        //public static void obmen(ref int a, ref int b) //поменять значения элементов
        //{
        //    int d = a;
        //    a = b;
        //    b = d;
        //}
        //public static void perestanovka(ref int t, ref int n, ref int[] a) //рекурсивная функция
        //{
        //    int i, j;
        //    if (t == n)
        //    {
        //        for (i = 1; i <= n; i++)                //вывод элементов
        //            Console.Write("{0}", a[i], ",");
        //        Console.WriteLine("   ");
        //    }
        //    else
        //    {
        //        for (i = t + 1; i <= n; i++)
        //        {
        //            obmen(ref a[i], ref a[t + 1]);
        //            t++;
        //            perestanovka(ref t, ref n, ref a);  //перестановка
        //            t--;
        //            obmen(ref a[i], ref a[t + 1]);
        //        }
        //    }
        //}
        //public static void Main(string[] args)
        //{
        //    int[] a = new int[100];
        //    int t = 0, n = 7; //длина массива

        //    for (int i = 1; i <= n; i++)
        //        a[i] = i;
        //    perestanovka(ref t, ref n, ref a);
        //    Console.ReadLine();
        //----------------------------------------------------------------------------------------------------------------------------------------------

        //}
        //-----------------------------------------------------------------Размещение-------------------------------------------------------------------
        public static void Main(string[] args)
        {
            char[] bunchOfNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // используемое множество 
            int n = 7; // количество мест в комбинации
            char[] buffer = new char[n];
            const string fileName = "ResultGenerate.txt";
            
            StreamWriter writer = File.CreateText(fileName);
            writer.Close();
           
            StringBuilder stringBuilder = new StringBuilder((int)Math.Pow(bunchOfNumbers.Length, n) * (n + 2));
            GenerateCombination(bunchOfNumbers, buffer, 0, stringBuilder);
            
            writer = File.AppendText(fileName);
            writer.Write(stringBuilder.ToString());
            writer.Close();

            Console.ReadLine();
        }

        private static void GenerateCombination(char[] arAlphabet, char[] arBuffer, int order,StringBuilder stringBuilder)                                                             
        {
            if (order < arBuffer.Length)
                for (int i = 0; i < arAlphabet.Length; i++)
                {
                    arBuffer[order] = arAlphabet[i];
                    GenerateCombination(arAlphabet, arBuffer, order + 1, stringBuilder);
                }
            else
            {
                for (int i = 0; i < arBuffer.Length; i++)
                    stringBuilder.Append(arBuffer[i]);
                stringBuilder.AppendLine();
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
