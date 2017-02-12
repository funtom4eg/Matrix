using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Martrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 32;
            Thread[] ms = new Thread[num];

            Matrix m;

            //передаем с делегатом th анонимный метод, в котором запускаются все дочерние потоки, через лямбда-выражение 
            ThreadStart th = () =>
            {

                for (int i = 2; i < num; i++)
                {
                    Thread.Sleep(200);
                    m = new Matrix();
                    ms[i] = new Thread(m.Start);
                    ms[i].IsBackground = true;    //main не будет ждать завершения этого потока
                    ms[i].Start();
                }
            };

            //нулевой дочерний поток оставляем за делегатом со строки 20
            ms[0] = new Thread(th);
            ms[0].IsBackground = true; //main не будет ждать завершения этого потока
            ms[0].Start();

            // в заголовке окна пишем посимвольно фразу из кинофильма =) (в отдельном потоке)
            ThreadStart titleTxt = () =>
            {
                string message1 = "Knock, knock Neo...";
                string message2 = "See You soon at C# Professional... =)";
                Console.Title = "";
                foreach (char c in message1)
                {

                    Console.Title += c;// temp;
                    Thread.Sleep(200);
                }
                Thread.Sleep(2000);
                Console.Title = "";
                foreach (char c in message2)
                {
                    Console.Title += c;
                    Thread.Sleep(200);
                }

            };
            ms[1] = new Thread(titleTxt);
            ms[1].IsBackground = true;
            ms[1].Start();

            //при нажатии любой клавиши останавливаем все фоновые потоки
            Console.ReadKey(true); //true для того, чтобы введенный символ не отображался в консоли

            //корректный вариант
            //foreach (Thread t in ms)
            //{
            //    if (t!=null) //&& t.IsAlive)  //к моменту нажатия на клавишу могут быть запущены не все фоновые потоки из цикла на 23 строке

            //        t.Abort(); //в случае, если поток заголовка завершился (исключение suspend) ничего не делать
            //}

            //прикольный, но устаревший вариант
            foreach (Thread t in ms)
            {
                if (t != null) //&& t.IsAlive)  //к моменту нажатия на клавишу могут быть запущены не все фоновые потоки из цикла на 23 строке
                    try { t.Suspend(); } catch { }  //в случае, если поток заголовка завершился (исключение suspend) ничего не делать
            }

            Console.ReadKey(true); //true для того, чтобы введенный символ не отображался в консоли


        }
    }
}
