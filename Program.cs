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
        static int height = 20;//Chiều cao border
        static int width = 80;// Chiều rộng border
        static int x=20;//Vị trí border theo cột
        static int y=6;//Vị trí border theo dòng
        static int xP1;//Vị trí của Player1 theo cột
        static int xP2;//Vị trí của Player1 theo cột
        static int yP1 = y +7;//Vị trí của Player1 theo dòng
        static int yP2 = y +7;//Vị trí của Player2 theo dòng
        static int lengthP = 6;
        static ConsoleKey consoleKey;
        
        //Ball's variable
        static int ballX = x + (width / 2);
        static int ballY = y + (height / 2);
        static int dx = 1, dy = 1; //hướng đi
        static int speed = 100;
        
        //Tính điểm
        static int p1Score = 0; 
        static int p2Score = 0;

        static void Main(string[] args)
        {
            int dem = 0;
            for(int i = 0; dem < 120; i++)
            {
                if (i == 10) i = 0;
                if (i == 9)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.Write(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.Write(i);
                dem++;
            }
            Console.CursorVisible= false;

            Whole();
            
        }
        #region Show
        static void Name()
        {
            Console.SetCursorPosition(39, 2);
            Console.Write(" ___  _  _  _  ___    ___  ___  _  _  ___");
            Console.SetCursorPosition(39, 3);
            Console.Write("| _ \\| || \\| |/ __|  | _ \\/ _ \\| \\| |/ __|");
            Console.SetCursorPosition(39, 4);
            Console.Write("| __/| || ,  | (_-┬  | __/ (_) | ,  | (_-┬");
            Console.SetCursorPosition(39, 5);
            Console.Write("|_|  |_||_|\\_|\\___|  |_|  \\___/|_|\\_|\\___|");
        }
        static void Border()
        {
            //Dòng trên
            for (int i = 0; i < width - 2; i++) 
            {
                Console.SetCursorPosition(x+1+i,y);
                Console.Write("─");
            }
            //Dòng dưới
            for (int i = 0; i < width - 2; i++)
            {
                Console.SetCursorPosition(x +1+i,y +height-1);
                Console.Write("─");
            }
            //Hàng trái
            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(x,y +1+i);
                Console.Write("│");
            }
            //Hàng phải
            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(x +width-1,y + 1 + i);
                Console.Write("│");
            }
            Console.SetCursorPosition(x, y);
            Console.Write("┌");
            Console.SetCursorPosition(x +width - 1, y);
            Console.Write("┐");
            Console.SetCursorPosition(x,y + height - 1);
            Console.Write("└");
            Console.SetCursorPosition(x +width - 1, y + height - 1);
            Console.Write("┘");
        }
        static void Player1()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < lengthP; i++)
            {
                Console.SetCursorPosition(x +1,yP1+i);
                Console.WriteLine(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Player2()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < lengthP; i++)
            {
                Console.SetCursorPosition(x +width - 2,yP2+i);
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
            yP1--;
            if (yP1 < y +1) yP1++;
            Player1();
            Console.SetCursorPosition(x +1, yP1 + lengthP);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
        static void DownP1()
        {
            Console.SetCursorPosition(x +1, yP1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            yP1++;
            if (yP1 + lengthP > y + height -1) 
                yP1--;
            Player1();
        }
        static void UpP2()
        {
            yP2--;
            if (yP2 < y +1) yP2++;
            Player2();
            Console.SetCursorPosition(x +width - 2,yP2 + lengthP);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
        static void DownP2()
        {
            Console.SetCursorPosition(x + width - 2, yP2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            yP2++;
            if (yP2 + lengthP > y + height -1) 
                yP2--;
            Player2();
        }
        #endregion
        static void Input()
        {
            do
            {
                consoleKey = Console.ReadKey(true).Key;
                switch (consoleKey)
                {
                    case ConsoleKey.W: UpP1(); break;
                    case ConsoleKey.S: DownP1(); break;
                    case ConsoleKey.UpArrow: UpP2(); break;
                    case ConsoleKey.DownArrow: DownP2(); break;
                }
            }
            while (true);
        }
        
        //Trái banh
        static void Ball()
        {
            while (true)
            {
                Console.SetCursorPosition(ballX, ballY);
                Console.WriteLine("O");
                Thread.Sleep(speed); //thay đổi tốc độ hiện banh mới

                Console.SetCursorPosition(ballX, ballY);
                Console.WriteLine(" ");

                ballX += 1 * dx;
                ballY += 1 * dy;
                
                //đụng trên, dưới quay đầu
                if (ballY == y + 1 || ballY >= y + height - 2)
                    dy *= -1;
                //đụng thanh chơi bên trái quay đầu
                else if (ballX == x + 2 && ballY >= yP1 && ballY <= yP1 + lengthP)
                    dx *= -1;
                //đụng thanh chơi bên phải quay đầu
                else if (ballX == x + width - 3 && ballY >= yP2 && ballY <= yP2 + lengthP)
                    dx *= -1;
                
                //bên trái thua
                else if (ballX == x + 1)
                {     
                    p2Score++;
                    //bắt đầu lại
                    ballX = x + (width / 2);
                    ballY = y + (height / 2);
                    Console.SetCursorPosition(ballX, ballY);
                    Console.WriteLine("O");
                    dx = dy = 1;
                }
                //bên phải thua
                else if (ballX == x + width - 2)
                {
                    p1Score++;
                    //bắt đầu lại
                    ballX = x + (width / 2);
                    ballY = y + (height / 2);
                    Console.SetCursorPosition(ballX, ballY);
                    Console.WriteLine("O");
                    dx = dy = 1;
                }
            }
        }
        
        static void Whole()
        {
            Thread show = new Thread(Show);
            show.Start();
            Thread input = new Thread(Input);
            input.Start();
            Thread ball = new Thread(Ball);
            ball.Start();
        }

    }
}
