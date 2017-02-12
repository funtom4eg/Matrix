using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Martrix2
{
    class Matrix
    {
        //locker for start()
        static readonly object obj = new object();
        //initialize randomizer
        public static Random rand = new Random();
         
        //properties
        public int Length { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }

        //ctor
        public Matrix()
        {
            Length = rand.Next(5, 12);
            XPos = rand.Next(0, 79);
            YPos = 0;
        }

        static Matrix()
        {
            Console.CursorVisible = false;
        }

        public void Start()
        {
            //cursor invissible - too fast, not needed
            //Console.CursorVisible = false;

            while (true)
            {
                while (YPos < 25 + Length)
                {

                    int i = 0;
                    lock (obj) //critical section
                    {

                        for (; i < Length; i++)
                        {

                            //если выходим за экран сверху, опускаемся ниже на одну строку и прерываем цикл вывода символов
                            if (YPos - i < 0)
                            {
                                YPos++;
                                break;
                            }

                            //первый символ белым, второй символ - светло зеленым,третий и далее - темнозеленым
                            switch (i)
                            {
                                case 0: Console.ForegroundColor = ConsoleColor.White; break;
                                case 1: Console.ForegroundColor = ConsoleColor.Green; break;
                                default: Console.ForegroundColor = ConsoleColor.DarkGreen; break;

                            }
                   
                            //пока текущий символ в рамках экрана - печатаем символ
                            if (YPos - i < 25)
                            {
                                Console.SetCursorPosition(XPos, YPos - i);
                                //Console.Write(chars.ToCharArray()[rand.Next(0, 35)]);
                                Console.Write((char)rand.Next(0x0021, 0x007e));
                            }

                        }
                        if (YPos - Length >= 0)
                        {
                            Console.SetCursorPosition(XPos, YPos - i);
                            Console.Write(" ");
                        }
                    }//end critical section

                    Thread.Sleep(70);
                    YPos++;
                }
                YPos = 0;
                XPos = rand.Next(0, 79);
            }

        }
    }
}
