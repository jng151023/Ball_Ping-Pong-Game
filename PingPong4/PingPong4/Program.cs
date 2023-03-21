using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainMenu
{
    internal class Program
    {
        z#region GlobalVariables
        static int yP1;//Vị trí của Player1
        static int yP2;//Vị trí của Player2
        static int lengthP = 6;
        static int height = 20;//Chiều cao border
        static int width = 80;// Chiều rộng border
        static int x = 20;//Vị trí border theo cột
        static int y = 6;
        static int xMenu = x + 10;
        static int yMenu = y + 5;
        static int idxMusic = 0;
        static int idxColorP1 = 1;//Màu của Player1
        static int idxColorP2 = 1;//Màu của Player2
        static int idxColorBall = 1;//Màu của Ball
        static bool k = true;
        static bool start = true;
        static ConsoleKey consoleKey;
        static bool a = true;
        static bool b = false;
        static bool c = false;
        #endregion
        static void Main(string[] args)
        {
            Console.CursorVisible= false;
            Whole();
        }
        #region Menu
        static void MainMenu()
        {
            Console.SetCursorPosition(x + width / 2 - 5, y + 2);
            Console.Write("MAIN MENU");
            Console.SetCursorPosition(x + width / 5, y + height-2);
            Console.Write("Press ESC to quit :<");
            Console.SetCursorPosition(x + width/2 +5 , y + height - 2);
            Console.Write("Press ENTER to start <3");
            //Difficulty
            Difficulty();
            //Costumes
            Costumes();
            //Music
            Music();
        }
        #region Difficulty
        static void Difficulty()
        {
            Console.SetCursorPosition(xMenu, yMenu);
            Console.Write("Difficulty:      (Press A)        (Press B)      (Press C)");
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
            Console.SetCursorPosition(xMenu, yMenu +2);
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
        static void ClearCostumesMenu()
        {
            for (int i = 0; i < height - 8; i++)
            {

                for (int j = 0; j < width - 2; j++)
                {
                    Console.SetCursorPosition(x + 1 + j, y + 5 + i);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
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
            IdxColor(idxColorBall);
            Console.SetCursorPosition(x + 14, y + 8);
            for (int i = 0; i < 1; i++)
            {
                Console.SetCursorPosition(x + 14, y + 8 + i);
                Console.WriteLine(" ");
            }
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
                Console.WriteLine(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Ball()
        {
            IdxColor(idxColorBall);
            Console.SetCursorPosition(x + width / 2, y + height / 2);
            Console.WriteLine(" ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        #endregion
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
            Ball();
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
        #endregion
        static void Input()
        {
            do
            {
                while (k == true && start == true)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.A: ChooseEasy(); break;
                        case ConsoleKey.B: ChooseNormal(); break;
                        case ConsoleKey.C: ChooseHard(); break;
                        case ConsoleKey.D: { k = false; ClearScreen(); CostumesMenu(); break; }
                        case ConsoleKey.O: { ++idxMusic; ChooseMusic(); break; }
                        case ConsoleKey.Escape: Exit(); break;
                        case ConsoleKey.Enter: { start = false; ResetYPlayer(); ClearScreen(); ShowInGame(); break; }
                    }
                }
                
                
                //Khi ở Main Menu

                #region SelectColor
                while (a == true && k == false)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.B: { a = false; b = true; c = false; SamplePlayer2(); break; }
                        case ConsoleKey.C: { a = false; b = false; c = true; SampleBall(); break; }
                        case ConsoleKey.Escape: { k = true; ClearScreen(); MainMenu(); break; }
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
                while (b == true && k == false)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.A: { a = true; b = false; c = false; SamplePlayer1(); break; }
                        case ConsoleKey.C: { a = false; b = false; c = true; SampleBall(); break; }
                        case ConsoleKey.Escape: { k = true; ClearScreen(); MainMenu(); break; }
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
                while (c == true && k == false)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.A: { a = true; b = false; c = false; SamplePlayer1(); break; }
                        case ConsoleKey.B: { a = false; b = true; c = false; SamplePlayer2(); break; }
                        case ConsoleKey.Escape: { k = true; ClearScreen(); MainMenu(); break; }
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

                while (start == false)//Khi vào game chơi
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.W: UpP1(); break;
                        case ConsoleKey.S: DownP1(); break;
                        case ConsoleKey.UpArrow: UpP2(); break;
                        case ConsoleKey.DownArrow: DownP2(); break;
                        case ConsoleKey.Escape: { start = true; ShowMenu(); break; }
                    }
                }
            }
            while (true);
        }
        static void ResetYPlayer()
        {
            yP1 = y + 7;
            yP2 = y + 7;
        }
        static void Pause()
        {
            Console.SetCursorPosition(x+width/3, y+height/3);
            Console.Write("Continue - Press A");
            Console.SetCursorPosition(x + width / 3, y + height / 3 +1);
            Console.Write("Music - Press B");
            Console.SetCursorPosition(x + width / 3, y + height / 3+2);
            Console.Write("Back to MainMenu - Press C");
        }
        static void Exit()
        {
            ClearScreen();
            Console.SetCursorPosition(x+width/3, y+height/3);
            Console.Write("Do you want to quit?\n");
            Console.SetCursorPosition(x + width / 3, y + height / 3 +1);
            Console.Write("If yes type 'y', else type 'n': ");
            char n;
            do
            {
                Console.SetCursorPosition(x + width / 3 + 33, y + height / 3 + 1);
                n = char.Parse(Console.ReadLine());
            }
            while(n!= 'n' && n!='y');

            if (n == 'y')
            {
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else if (n=='n')
                ShowMenu();
        }
        static void Whole()
        {
            Thread show = new Thread(ShowMenu);
            show.Start();
            Thread inputMainMenu = new Thread(Input);
            inputMainMenu.Start();
        }
    }
}
