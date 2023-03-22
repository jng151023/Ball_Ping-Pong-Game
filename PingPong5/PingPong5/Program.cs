using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong5
{
    internal class Program
    {
        #region GlobalVariables

        //Border
        static int x = 20;//Vị trí border theo cột
        static int y = 6;//Vị trí border theo dòng
        static int height = 20;//Chiều cao border
        static int width = 80;// Chiều rộng border

        //Player
        static int yP1;//Vị trí của Player1
        static int yP2;//Vị trí của Player2
        static int lengthP = 6;//Chiều dài Player

        //Ball
        static int ballX = x + (width / 2);//Vị trí bắt đầu của Ball theo cột
        static int ballY = y + (height / 2);//Vị trí bắt đầu của Ball theo dòng
        static int dx = 1, dy = 1; //Biến điều chỉnh hướng đi của Ball
        static int speed = 100;//Tốc độc của Ball
        //Tính điểm
        static int p1Score = 0;
        static int p2Score = 0;

        //Menu
        static int xMenu = x + 10;//Vị trí theo cột các thành phần trong menu
        static int yMenu = y + 5;//Vị trí theo dòng các thành phần trong menu

        //Music
        static int idxMusic = 0;//Biến để bật tắt music

        //Color
        static int idxColorP1 = 1;//Màu của Player1
        static int idxColorP2 = 1;//Màu của Player2
        static int idxColorBall = 1;//Màu của Ball

        //Menu Costumes
        static bool costumesMenu = false;//Biến để bật tắt menu costumes
        static bool costumeP1 = true;//Chọn màu cho Player1
        static bool costumeP2 = false;//Chọn màu cho Player2
        static bool costumeBall = false;//Chọn màu cho Ball

        static bool gameOn = false;//Biến bắt đầu trò chơi
        static bool pauseMenuOn = false;//Biến để bật menu pause game

        static ConsoleKey consoleKey;//Biến để nhập từ bàn phím

        #endregion
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int dem = 0;
            for (int i = 0; dem < 120; i++)
            {
                if (i == 10)
                { i = 0;}
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write(i); Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.Write(i);
                dem++;
            }
            int dem2 = 0;
            for (int i = 1; dem2 < 30; i++)
            {
                if (i == 10)
                { i = 0; }
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(i); Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.WriteLine(i);
                dem2++;
            }
            Whole();


        }
        #region Menu
        static void MainMenu()
        {
            Console.SetCursorPosition(x + width / 2 - 5, y + 2);
            Console.Write("MAIN MENU");
            Console.SetCursorPosition(x + width / 5, y + height - 2);
            Console.Write("Press ESC to quit :<");
            Console.SetCursorPosition(x + width / 2 + 5, y + height - 2);
            Console.Write("Press ENTER to start <3");
            //Các thành phần của menu
            Difficulty();
            Costumes();
            Music();
        }
        #region Difficulty
        static void Difficulty()
        {
            Console.SetCursorPosition(xMenu, yMenu);
            Console.Write("Difficulty:      (Press A)        (Press B)      (Press C)");
            //Mặc định chọn mức độ dễ
            Console.ForegroundColor = ConsoleColor.Yellow;
            Easy();
            Console.ForegroundColor = ConsoleColor.White;
            Normal();
            Hard();
        }
        static void Easy()
        {
            Console.SetCursorPosition(xMenu + 13, yMenu);
            Console.Write("Easy");
        }
        static void Normal()
        {
            Console.SetCursorPosition(xMenu + 28, yMenu);
            Console.Write("Normal");

        }
        static void Hard()
        {
            Console.SetCursorPosition(xMenu + 45, yMenu);
            Console.Write("Hard");
        }
        static void ChooseEasy()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Normal(); Hard();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Easy();
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void ChooseNormal()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Easy(); Hard();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Normal();
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void ChooseHard()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Easy(); Normal();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Hard();
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion
        #region Costumes
        static void Costumes()
        {
            Console.SetCursorPosition(xMenu, yMenu + 2);
            Console.Write("Costumes: Press D");
        }
        static void CostumesMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(x + width / 2 - 7, y + 2);
            Console.Write("COSTUMES MENU");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x + width / 6, y + 4);
            Console.Write("Player1(Press A)  Player2(Press B)  Player3(Press C)");
            Console.ForegroundColor = ConsoleColor.White;
            SamplePlayer1();
            Console.SetCursorPosition(x + 2, y + height - 2);
            Console.Write("Press ECS to back to Main Menu");
        }
        
        #region Color
        static void Color()
        {
            White();
            Red();
            Yellow();
            Green();
            Blue();
            Magenta();
            Gray();
            DarkGreen();
            Cyan();
        }
        static void White()
        {
            Console.SetCursorPosition(48, 14);
            Console.Write("Press 1: ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(57, 14);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Red()
        {
            Console.SetCursorPosition(60, 14);
            Console.Write("Press 2: ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(69, 14);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Green()
        {
            Console.SetCursorPosition(72, 14);
            Console.Write("Press 3: ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(81, 14);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Blue()
        {
            Console.SetCursorPosition(48, 16);
            Console.Write("Press 4: ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(57, 16);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Yellow()
        {
            Console.SetCursorPosition(60, 16);
            Console.Write("Press 5: ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(69, 16);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Magenta()
        {
            Console.SetCursorPosition(72, 16);
            Console.Write("Press 6: ");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(81, 16);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Gray()
        {
            Console.SetCursorPosition(48, 18);
            Console.Write("Press 7: ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(57, 18);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void DarkGreen()
        {
            Console.SetCursorPosition(60, 18);
            Console.Write("Press 8: ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(69, 18);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Cyan()
        {
            Console.SetCursorPosition(72, 18);
            Console.Write("Press 9: ");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(81, 18);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
        }
        #endregion
        #region Sample
        static void IdxColor(int a)
        {
            switch (a)
            {
                case 1: Console.BackgroundColor = ConsoleColor.White; break;
                case 2: Console.BackgroundColor = ConsoleColor.Red; break;
                case 3: Console.BackgroundColor = ConsoleColor.Green; break;
                case 4: Console.BackgroundColor = ConsoleColor.Blue; break;
                case 5: Console.BackgroundColor = ConsoleColor.Yellow; break;
                case 6: Console.BackgroundColor = ConsoleColor.Magenta; break;
                case 7: Console.BackgroundColor = ConsoleColor.DarkGray; break;
                case 8: Console.BackgroundColor = ConsoleColor.DarkGreen; break;
                case 9: Console.BackgroundColor = ConsoleColor.Cyan; break;
            }
        }
        static void SamplePlayer1()
        {
            Console.SetCursorPosition(x + 11, y + 6);
            Console.Write("Player1");
            Console.SetCursorPosition(x + 14, y + 7);
            Console.Write("v");
            //In ra Player1
            IdxColor(idxColorP1);
            for (int i = 0; i < lengthP; i++)
            {
                Console.SetCursorPosition(x + 14, y + 8 + i);
                Console.WriteLine(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Color();
        }
        static void SamplePlayer2()
        {

            Console.SetCursorPosition(x + 11, y + 6);
            Console.Write("Player2");
            Console.SetCursorPosition(x + 14, y + 7);
            Console.Write("v");
            //In ra Player2
            IdxColor(idxColorP2);
            for (int i = 0; i < lengthP; i++)
            {
                Console.SetCursorPosition(x + 14, y + 8 + i);
                Console.WriteLine(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Color();
        }
        static void SampleBall()
        {
            Console.SetCursorPosition(x + 11, y + 6);
            Console.Write("  Ball ");
            Console.SetCursorPosition(x + 14, y + 7);
            Console.Write("v");
            //In ra Ball
            IdxColor(idxColorBall);
            Console.SetCursorPosition(x + 14, y + 8);
            for (int i = 0; i < 1; i++) 
            {
                Console.SetCursorPosition(x + 14, y + 8 + i);
                Console.WriteLine(" ");
            }
            //Xóa các phần dư thừa của Player
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 1; i < lengthP; i++)
            {
                Console.SetCursorPosition(x + 14, y + 8 + i);
                Console.WriteLine(" ");
            }


            Color();
        }
        #endregion
        #endregion
        #region Music
        static void Music()
        {
            Console.SetCursorPosition(xMenu, yMenu + 4);
            Console.Write("Music:     (Press O)");
            ChooseMusic();
            Console.ForegroundColor = ConsoleColor.White;

        }
        static void ChooseMusic()
        {
            Console.SetCursorPosition(xMenu + 7, yMenu + 4);
            if (idxMusic % 2 == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("OFF");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("ON ");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        #endregion
        #endregion
        #region InGame 
        static void Player1()
        {
            IdxColor(idxColorP1);
            for (int i = 0; i < lengthP; i++)
            {
                Console.SetCursorPosition(x + 1, yP1 + i);
                Console.WriteLine(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Player2()
        {
            IdxColor(idxColorP2);
            for (int i = 0; i < lengthP; i++)
            {
                Console.SetCursorPosition(x + width - 2, yP2 + i);
                Console.WriteLine("0");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Ball()
        {
            
            Console.SetCursorPosition(ballX, ballY);
            Console.WriteLine("0");
            ;
        }
        #endregion
        static void Name()
        {
            Console.SetCursorPosition(39, 2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ___  _  _  _  ___    ___  ___  _  _  ___");
            Console.SetCursorPosition(39, 3);
            
            Console.Write("| _ \\| || \\| |/ __|  | _ \\/ _ \\| \\| |/ __|");
            Console.SetCursorPosition(39, 4);
            
            Console.Write("| __/| || ,  | (_-┬  | __/ (_) | ,  | (_-┬");
            
            Console.SetCursorPosition(39, 5);
            Console.Write("|_|  |_||_|\\_|\\___|  |_|  \\___/|_|\\_|\\___|");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Border()
        {
            //Dòng trên
            for (int i = 0; i < width - 2; i++)
            {
                Console.SetCursorPosition(x + 1 + i, y);
                Console.Write("─");
            }
            //Dòng dưới
            for (int i = 0; i < width - 2; i++)
            {
                Console.SetCursorPosition(x + 1 + i, y + height - 1);
                Console.Write("─");
            }
            //Hàng trái
            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);
                Console.Write("│");
            }
            //Hàng phải
            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(x + width - 1, y + 1 + i);
                Console.Write("│");
            }
            Console.SetCursorPosition(x, y);
            Console.Write("┌");
            Console.SetCursorPosition(x + width - 1, y);
            Console.Write("┐");
            Console.SetCursorPosition(x, y + height - 1);
            Console.Write("└");
            Console.SetCursorPosition(x + width - 1, y + height - 1);
            Console.Write("┘");
        }
        static void ClearScreen()
        {
            for (int i = 0; i < height - 2; i++)
            {

                for (int j = 0; j < width - 2; j++)
                {
                    Console.SetCursorPosition(x + 1 + j, y + 1 + i);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        static void ShowMenu()
        {
            ClearScreen();
            Name();
            Border();
            MainMenu();
        }
        static void ShowInGame()
        {
            ClearScreen();
            Player1();
            Player2();
        }
        #region Move
        static void UpP1()
        {
            yP1--;
            if (yP1 < y + 1) yP1++;
            Player1();
            Console.SetCursorPosition(x + 1, yP1 + lengthP);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
        static void DownP1()
        {
            Console.SetCursorPosition(x + 1, yP1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            yP1++;
            if (yP1 + lengthP > y + height - 1)
                yP1--;
            Player1();
        }
        static void UpP2()
        {
            yP2--;
            if (yP2 < y + 1) yP2++;
            Player2();
            Console.SetCursorPosition(x + width - 2, yP2 + lengthP);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
        static void DownP2()
        {
            Console.SetCursorPosition(x + width - 2, yP2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            yP2++;
            if (yP2 + lengthP > y + height - 1)
                yP2--;
            Player2();
        }
        static void ResetYPlayer()
        {
            yP1 = y + 7;
            yP2 = y + 7;
        }
        
        #endregion
        static void Input()
        {
            do
            {
                //Khi ở Main Menu
                while (costumesMenu == false && gameOn == false)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.A: ChooseEasy(); break;//Chọn mức dễ
                        case ConsoleKey.B: ChooseNormal(); break;//Chọn mức trung bình
                        case ConsoleKey.C: ChooseHard(); break;//Chọn mức khó
                        case ConsoleKey.D: { costumesMenu = true; ClearScreen(); CostumesMenu(); break; }//Mở Costumes Menu
                        case ConsoleKey.O: { ++idxMusic; ChooseMusic(); break; }//Bật tắt Music
                        case ConsoleKey.Escape: Exit(); break;//Mở màn hình Exit
                        case ConsoleKey.Enter: { ResetYPlayer(); ClearScreen(); ShowInGame(); gameOn = true; break; }//Vào game
                    }
                }
                //Khi ở Costumes Menu
                #region CostumesMenu
                //Mở menu để chỉnh màu cho Player1
                while (costumeP1 == true && costumesMenu == true)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.B: { costumeP1 = false; costumeP2 = true; costumeBall = false; SamplePlayer2(); break; }//Mở màn hình P2
                        case ConsoleKey.C: { costumeP1 = false; costumeP2 = false; costumeBall = true; SampleBall(); break; }//Mở màn hình Ball
                        case ConsoleKey.Escape: { costumesMenu = false; ClearScreen(); MainMenu(); break; }
                        //Chọn màu cho Player1
                        case ConsoleKey.D1: { idxColorP1 = 1; SamplePlayer1(); break; }
                        case ConsoleKey.D2: { idxColorP1 = 2; SamplePlayer1(); break; }
                        case ConsoleKey.D3: { idxColorP1 = 3; SamplePlayer1(); break; }
                        case ConsoleKey.D4: { idxColorP1 = 4; SamplePlayer1(); break; }
                        case ConsoleKey.D5: { idxColorP1 = 5; SamplePlayer1(); break; }
                        case ConsoleKey.D6: { idxColorP1 = 6; SamplePlayer1(); break; }
                        case ConsoleKey.D7: { idxColorP1 = 7; SamplePlayer1(); break; }
                        case ConsoleKey.D8: { idxColorP1 = 8; SamplePlayer1(); break; }
                        case ConsoleKey.D9: { idxColorP1 = 9; SamplePlayer1(); break; }
                    }
                }
                //Mở menu để chỉnh màu cho Player2
                while (costumeP2 == true && costumesMenu == true)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.A: { costumeP1 = true; costumeP2 = false; costumeBall = false; SamplePlayer1(); break; }//Mở màn hình P1
                        case ConsoleKey.C: { costumeP1 = false; costumeP2 = false; costumeBall = true; SampleBall(); break; }// Mở màn hình Ball
                        case ConsoleKey.Escape: { costumesMenu = false; ClearScreen(); MainMenu(); break; }
                        case ConsoleKey.D1: { idxColorP2 = 1; SamplePlayer2(); break; }
                        case ConsoleKey.D2: { idxColorP2 = 2; SamplePlayer2(); break; }
                        case ConsoleKey.D3: { idxColorP2 = 3; SamplePlayer2(); break; }
                        case ConsoleKey.D4: { idxColorP2 = 4; SamplePlayer2(); break; }
                        case ConsoleKey.D5: { idxColorP2 = 5; SamplePlayer2(); break; }
                        case ConsoleKey.D6: { idxColorP2 = 6; SamplePlayer2(); break; }
                        case ConsoleKey.D7: { idxColorP2 = 7; SamplePlayer2(); break; }
                        case ConsoleKey.D8: { idxColorP2 = 8; SamplePlayer2(); break; }
                        case ConsoleKey.D9: { idxColorP2 = 9; SamplePlayer2(); break; }
                    }
                }
                //Mở menu để chỉnh màu cho Ball
                while (costumeBall == true && costumesMenu == true)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.A: { costumeP1 = true; costumeP2 = false; costumeBall = false; SamplePlayer1(); break; }
                        case ConsoleKey.B: { costumeP1 = false; costumeP2 = true; costumeBall = false; SamplePlayer2(); break; }
                        case ConsoleKey.Escape: { costumesMenu = false; ClearScreen(); MainMenu(); break; }
                        case ConsoleKey.D1: { idxColorBall = 1; SampleBall(); break; }
                        case ConsoleKey.D2: { idxColorBall = 2; SampleBall(); break; }
                        case ConsoleKey.D3: { idxColorBall = 3; SampleBall(); break; }
                        case ConsoleKey.D4: { idxColorBall = 4; SampleBall(); break; }
                        case ConsoleKey.D5: { idxColorBall = 5; SampleBall(); break; }
                        case ConsoleKey.D6: { idxColorBall = 6; SampleBall(); break; }
                        case ConsoleKey.D7: { idxColorBall = 7; SampleBall(); break; }
                        case ConsoleKey.D8: { idxColorBall = 8; SampleBall(); break; }
                        case ConsoleKey.D9: { idxColorBall = 9; SampleBall(); break; }
                    }
                }
                #endregion

                //Khi vào game
                while (gameOn == true)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.W: UpP1(); break;
                        case ConsoleKey.S: DownP1(); break;
                        case ConsoleKey.UpArrow: UpP2(); break;
                        case ConsoleKey.DownArrow: DownP2(); break;
                        case ConsoleKey.Escape: { pauseMenuOn = true; gameOn = false; ClearScreen(); Pause(); break; }
                    }
                }
                //Pause game
                while (pauseMenuOn == true)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.A: { ClearScreen(); ShowInGame(); Thread.Sleep(200); gameOn = true; pauseMenuOn = false;  break; }
                        case ConsoleKey.B: { ClearScreen();ResetYPlayer(); ShowInGame(); Thread.Sleep(200); gameOn = true; pauseMenuOn = false; break; }
                        //case ConsoleKey.B: DownP1(); break; Music
                        case ConsoleKey.D: {ShowMenu(); pauseMenuOn = false; break; }
                    }
                }
            }
            while (true);
        }
        static void BallMove()
        {
            do
            {
                while (gameOn == true)
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
                    {
                        dx *= -1;
                        dy = new Random().Next(-1, 2);
                        if (dy == 0) dy = 1;
                    }
                    //đụng thanh chơi bên phải quay đầu
                    else if (ballX == x + width - 3 && ballY >= yP2 && ballY <= yP2 + lengthP)
                    {
                        dx *= -1;
                        dy = new Random().Next(-1, 2);
                        if (dy == 0) dy = 1;
                    }

                    //bên trái thua
                    else if (ballX == x + 1)
                    {
                        p2Score++;
                        //bắt đầu lại
                        ballX = x + (width / 2);
                        ballY = y + (height / 2);
                        Console.SetCursorPosition(ballX, ballY);
                        Console.WriteLine("O");
                        dx = 1;
                        dy = new Random().Next(-1, 2);
                        if (dy == 0) dy = 1;
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
                        dx = 1;
                        dy = new Random().Next(-1, 2);
                        if (dy == 0) dy = 1;
                    }
                Console.SetCursorPosition(50,27);
                Console.Write($" Play1:{p1Score}: Play2: {p2Score}");
                }
            }
            while(true);
        }
        static void Pause()
        {
            Console.SetCursorPosition(x + width / 3+1, y + height / 3+1);
            Console.Write("Continue - Press A");
            Console.SetCursorPosition(x + width / 3 + 1, y + height / 3 + 2);
            Console.Write("Restart - Press B");
            Console.SetCursorPosition(x + width / 3 + 1, y + height / 3 + 3);
            Console.Write("Music - Press C");
            Console.SetCursorPosition(x + width / 3 + 1, y + height / 3 + 4);
            Console.Write("Back to MainMenu - Press D");
        }
        static void Exit()
        {
            ClearScreen();
            Console.SetCursorPosition(x + width / 3 - 3, y + height / 3+ 1 );
            Console.Write("Do you want to quit?\n");
            Console.SetCursorPosition(x + width / 3 - 3, y + height / 3 + 2);
            Console.Write("If yes type 'y', else type 'n': ");

            for (int i = 0; i < width / 2; i++)
            {

                Console.SetCursorPosition(x + width / 3 - 3 +i, y + height / 3 );
                Console.Write("─");
            }
            
            
            char n;
            do
            {
                Console.SetCursorPosition(x + width / 3 + 33-3, y + height / 3 + 2);
                Console.ForegroundColor= ConsoleColor.Green;
                n = char.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (n != 'n' && n != 'y');

            if (n == 'y')
            {
                ClearScreen();
                Console.SetCursorPosition(x + width / 3 , y + height / 3 + 1);
                Console.ForegroundColor=ConsoleColor.Yellow;
                Console.WriteLine("Thank for playing ");
                Console.SetCursorPosition(x + width / 3 + 18, y + height / 3 + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<3");
                Thread.Sleep(1500);
                
                Environment.Exit(0);
                
            }
            else if (n == 'n')
                ShowMenu();
        }
        
        static void Whole()
        {
            Thread show = new Thread(ShowMenu);
            show.Start();
            Thread inputMainMenu = new Thread(Input);
            inputMainMenu.Start();
            Thread ballMove = new Thread(BallMove);
            ballMove.Start();       
        }
    }
}
