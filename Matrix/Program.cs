using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Knock, knock Neo...";
            char[] charStr = str.ToCharArray();

            foreach (char c in charStr)
            {
                Console.Write(c);
                Thread.Sleep(150);
            }

            Thread.Sleep(2000);
            Console.Clear();

            charStr = "I'll kill U...".ToCharArray();

            foreach (char c in charStr)
            {
                Console.Write(c);
                Thread.Sleep(150);
            }
            Thread.Sleep(2000);
            Console.Clear();
            Thread.Sleep(2000);
            //Console.ReadKey();
                
        }
    }
}
