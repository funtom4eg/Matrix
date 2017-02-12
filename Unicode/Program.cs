using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Unicode

{
    using ListInt = List<int>;
    using C = Console;
    public delegate void MyDelegate(dynamic str);

    class Program
    {
        
        /// <summary>
        /// This is my method bitch
        /// </summary>
        public static void Method()
        {
            int[] arr = new int[100000000];//TODO: hack it bitch
            Console.WriteLine(arr);
            Method();
            
        }
        static void Main(string[] args)
        {
            
            MyDelegate CW = Console.WriteLine;//HACK: 
            try
            {
                Method();
            }
            catch (Exception e)
            {
                CW(e.Message);
            }
            finally
            {
                CW("Finally...");
            }


            var z = Enumerable.Range(0, 6);
            foreach (var item in z)
            {
                C.WriteLine(item);
            }

            //int i = 0;
            //while (true)
            //{
            //    Console.Write((char)i);
            //    i++;
            //    if(i%20 == 0)
            //        Console.ReadKey();
            //}

            Console.ReadKey();
        }
    }
}
