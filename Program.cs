using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong3
{
    internal class Program
    {
        static int Tiendeptraicute;
        static int height = 20;//Chiều cao border
        static int width = 80;// Chiều rộng border
        static int X=20;//Vị trí border theo cột
        static int Y=6;//Vị trí border theo dòng
        static int positionP1 = Y+7;//Vị trí của Player1
        static int positionP2 = Y+7;//Vị trí của Player2
        static int lengthP = 6;
        static ConsoleKey consoleKey;
        private static ConsoleKey consolekey;

        static void Main(string[] args)
        {
            int dem = 0;
            for(int i = 0; dem < 120; i++)
            {
                if (i == 9)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (i == 10) { i = 0;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(i); Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.Write(i);
                dem++;
            }
            

            Console.WriteLine("  ___  _  _  _  ___   ___  ___ __  ___ ");
            Console.WriteLine(" | _ \\| || \\| |/ __| | _ \\/ _ \\  | \\| |/ __|");
            Console.WriteLine(" | __/| || ,  | (_-┬ | __/ (_) | ,  | (_-┬");
            Console.WriteLine(" |_|  |_||_|\\_|\\___| |_|  \\___/   |_|\\_|\\___|");
            Whole();
            
        }
        #region Show
        static void Border()
        {
            //Dòng trên
            for (int i = 0; i < width - 2; i++) 
            {
                Console.SetCursorPosition(X+1+i,Y);
                Console.Write("─");
            }
            //Dòng dưới
            for (int i = 0; i < width - 2; i++)
            {
                Console.SetCursorPosition(X+1+i,Y+height-1);
                Console.Write("─");
            }
            //Hàng trái
            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(X,Y+1+i);
                Console.Write("│");
            }
            //Hàng phải
            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(X+width-1,Y + 1 + i);
                Console.Write("│");
            }
            Console.SetCursorPosition(X, Y);
            Console.Write("┌");
            Console.SetCursorPosition(X+width - 1, Y);
            Console.Write("┐");
            Console.SetCursorPosition(X,Y+ height - 1);
            Console.Write("└");
            Console.SetCursorPosition(X+width - 1, Y + height - 1);
            Console.Write("┘");
        }
        static void Player1()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < lengthP; i++)
            {
                Console.SetCursorPosition(X+1,positionP1+i);
                Console.WriteLine(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Player2()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < lengthP; i++)
            {
                Console.SetCursorPosition(X+width - 2,positionP2+i);
                Console.WriteLine(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Show()
        {
            
            Border();
            Player1();
            Player2();
        }
        #endregion
        #region Move
        static void UpP1()
        {
            positionP1--;
            if (positionP1 < Y+1) positionP1++;
            Player1();
            Console.SetCursorPosition(X+1, positionP1 + lengthP);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
        static void DownP1()
        {
            Console.SetCursorPosition(X+1, positionP1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            positionP1++;
            if (positionP1 + lengthP > Y + height -1) 
                positionP1--;
            Player1();
        }
        static void UpP2()
        {
            positionP2--;
            if (positionP2 < Y+1) positionP2++;
            Player2();
            Console.SetCursorPosition(X+width - 2,positionP2 + lengthP);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
        static void DownP2()
        {
            Console.SetCursorPosition(X + width - 2, positionP2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            positionP2++;
            if (positionP2 + lengthP > Y+ height -1) 
                positionP2--;
            Player2();
        }
        #endregion
        static void Input()
        {
            do
            {
                consolekey = Console.ReadKey(true).Key;
                switch (consolekey)
                {
                    case ConsoleKey.W: UpP1(); break;
                    case ConsoleKey.S: DownP1(); break;
                    case ConsoleKey.UpArrow: UpP2(); break;
                    case ConsoleKey.DownArrow: DownP2(); break;
                }
            }
            while (true);
        }
        static void Whole()
        {
            Thread show = new Thread(Show);
            show.Start();
            Thread input = new Thread(Input);
            input.Start();
            
        }

    }
}
