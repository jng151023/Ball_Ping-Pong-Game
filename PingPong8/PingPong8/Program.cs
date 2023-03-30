using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong8
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
        static int xP1 = x + 1;
        static int xP2 = x + width - 2;
        static int yP1;//Vị trí của Player1
        static int yP2;//Vị trí của Player2
        static int lengthP = 6;//Chiều dài Player

        //Ball
        static int ballX = x + (width / 2);//Vị trí bắt đầu của Ball theo cột
        static int ballY = y + (height / 2);//Vị trí bắt đầu của Ball theo dòng
        static int dx, dy; //Biến điều chỉnh hướng đi của Ball
        static int speed = 120;//Tốc độc của Ball

        //Tính điểm
        static int p1Score = 0;//Biến tính điểm cho player1
        static int p2Score = 0;//Biến tính điểm cho player2

        //Menu
        static int xMenu = x + 10;//Vị trí theo cột các thành phần trong menu
        static int yMenu = y + 5;//Vị trí theo dòng các thành phần trong menu

        //Music
        static int idxMusic = 0;//Biến để bật tắt music

        static int[] DO = new int[] { 131, 262, 523, 1046 };
        static int[] RE = new int[] { 147, 294, 587, 1174 };
        static int[] MI = new int[] { 165, 330, 659, 1318 };
        static int[] FA = new int[] { 175, 349, 698, 1396 };
        static int[] SO = new int[] { 196, 392, 784, 1568 };
        static int[] LA = new int[] { 220, 440, 880, 1760 };
        static int[] TI = new int[] { 247, 494, 988, 1976 };

        static int oct2 = 1;
        static int oct3 = 2;
        static int oct4 = 3;

        //Color
        static int idxColorP1 = 1;//Màu của Player1
        static int idxColorP2 = 1;//Màu của Player2

        //Menu Costumes
        static bool costumesMenu = false;//Biến để bật tắt menu costumes
        static bool costumeP1 = true;//Chọn màu cho Player1
        static bool costumeP2 = false;//Chọn màu cho Player2

        static bool gameOn = false;//Biến bắt đầu trò chơi
        static bool pauseMenuOn = false;//Biến để bật menu pause game
        static bool winGameOn = false;//Biến mở lúc win game

        static ConsoleKey consoleKey;//Biến để nhập từ bàn phím vào
        static Random random = new Random();

        static bool up1, up2, down1, down2;

        #endregion
        static void Main(string[] args)
        {
            Console.CursorVisible = true;
            Whole();
        }

        //Tên và khung viền
        #region Border
        static void PingPong()
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
        #endregion

        //Nhạc nền
        static void SweetChild()
        {
            do
            {
                for (int i = 0; i < 2; i++)
                {
                    if (idxMusic % 2 == 0)
                        Console.Beep(SO[oct2], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(SO[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(RE[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(DO[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(DO[oct4], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(RE[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(TI[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(RE[oct3], 250);
                }

                for (int i = 0; i < 2; i++)
                {
                    if (idxMusic % 2 == 0)
                        Console.Beep(LA[oct2], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(SO[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(RE[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(DO[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(DO[oct4], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(RE[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(TI[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(RE[oct3], 250);
                }

                for (int i = 0; i < 2; i++)
                {
                    if (idxMusic % 2 == 0)
                        Console.Beep(DO[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(SO[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(RE[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(DO[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(DO[oct4], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(RE[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(TI[oct3], 250);
                    if (idxMusic % 2 == 0)
                        Console.Beep(RE[oct3], 250);
                }

                if (idxMusic % 2 == 0)
                    Console.Beep(SO[oct2], 250);
                if (idxMusic % 2 == 0)
                    Console.Beep(SO[oct3], 250);
                if (idxMusic % 2 == 0)
                    Console.Beep(RE[oct3], 250);
                if (idxMusic % 2 == 0)
                    Console.Beep(DO[oct3], 250);
                if (idxMusic % 2 == 0)
                    Console.Beep(DO[oct4], 250);
                if (idxMusic % 2 == 0)
                    Console.Beep(RE[oct3], 250);
                if (idxMusic % 2 == 0)
                    Console.Beep(TI[oct3], 250);
                if (idxMusic % 2 == 0)
                    Console.Beep(RE[oct3], 250);
            }
            while (true);
        }

        //Hàm xóa màn hình 
        static void ClearScreen()
        {
            //Xóa toàn bộ trong border
            for (int i = 0; i < height - 2; i++)
            {

                for (int j = 0; j < width - 2; j++)
                {
                    Console.SetCursorPosition(x + 1 + j, y + 1 + i);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }

            //Xóa điểm của P1
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.SetCursorPosition(x + 1 + j, y - 4 + i);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            //Xóa điểm của P2
            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 6; j++)
                {
                    Console.SetCursorPosition(x + width - 7 + j, y - 4 + i);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            //Xóa thông báo "Press ESC to Pause game" trong game
            for (int i = 0; i < 23; i++)
            {
                Console.SetCursorPosition(x + 2 + i, y + height);
                Console.Write(' ');
            }
        }

        //MainMenu, CostumeMenu
        #region Menu
        static void MainMenu()
        {
            ClearScreen();
            Console.SetCursorPosition(x + width / 2 - 5, y + 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("MAIN MENU");
            Console.SetCursorPosition(x + 2, y + height - 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press ESC to quit :<");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x + width - 25, y + height - 2);
            Console.Write("Press ENTER to start <3");
            Console.ForegroundColor = ConsoleColor.White;
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


            if (speed == 120)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Easy();
                Console.ForegroundColor = ConsoleColor.White;
                Normal();
                Hard();
            }
            else if (speed == 80)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Normal();
                Console.ForegroundColor = ConsoleColor.White;
                Easy();
                Hard();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Hard();
                Console.ForegroundColor = ConsoleColor.White;
                Easy();
                Normal();
            }


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
            speed = 120;
        }
        static void ChooseNormal()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Easy(); Hard();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Normal();
            Console.ForegroundColor = ConsoleColor.White;
            speed = 80;
        }
        static void ChooseHard()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Easy(); Normal();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Hard();
            Console.ForegroundColor = ConsoleColor.White;
            speed = 40;
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
            ClearScreen();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(x + width / 2 - 7, y + 2);
            Console.Write("COSTUMES MENU");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x + width / 6, y + 4);
            Console.Write("Player1(Press A)  Player2(Press B)");
            Console.ForegroundColor = ConsoleColor.White;
            SamplePlayer1();
            Console.SetCursorPosition(x + 2, y + height - 2);
            Console.Write("Press ECS to back to Main Menu");
        }
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
        #region Color
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
        //Mẫu của các player hiện thị để xem màu của player
        #region Sample
        static void SamplePlayer1()
        {
            Console.SetCursorPosition(x + 11, y + 6);
            Console.Write("Player 1");
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
            Console.Write("Player 2");
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

        //Player và hướng di chuyển
        #region Player
        static void Player1()
        {
            for (int i = 0; i < lengthP; i++)
            {
                IdxColor(idxColorP1);
                Console.SetCursorPosition(xP1, yP1 + i);
                Console.WriteLine(" ");
                Console.BackgroundColor = ConsoleColor.Black;
                if (up1 == true)
                {
                    Console.SetCursorPosition(xP1, yP1 + lengthP);
                    Console.WriteLine(" ");
                }
                else if (down1==true)
                {
                    Console.SetCursorPosition(xP1, yP1 -1);
                    Console.WriteLine(" ");
                }
            }
        }
        static void Player2()
        {

            for (int i = 0; i < lengthP; i++)
            {
                Console.SetCursorPosition(xP2, yP2 + i);
                IdxColor(idxColorP2);
                Console.WriteLine(" ");
                Console.BackgroundColor = ConsoleColor.Black;
                if (up2 == true)
                {
                    Console.SetCursorPosition(xP2, yP2 + lengthP);
                    Console.WriteLine(" ");
                }
                else if (down2 == true)
                {
                    Console.SetCursorPosition(xP2, yP2 - 1);
                    Console.WriteLine(" ");
                }
            }
        }
        #endregion

        //Ball
        #region Ball
        static void Ball()
        {
            Console.SetCursorPosition(ballX, ballY);
            Console.Write("O");

            Thread.Sleep(speed);

            Console.SetCursorPosition(ballX, ballY);
            Console.Write(" ");
        }
        static void RandomBallX()
        {
            dx = random.Next(-1, 2);
            if (dx == 0)
                dx = 1;
        }
        static void RandomBallY()
        {
            dy = random.Next(-1, 2);
            if (dy == 0)
                dy = 1;
        }
        #endregion

        //Update vị trí mới của Player và Ball
        static void Update()
        {
            do
            {
                while (gameOn == true)
                {
                    Player1();
                    Player2();

                    //Ball không dụng Player, cạnh trên, cạnh dưới
                    if (ballY >= y + 1 && ballY <= y + height - 2 && ballX >= x + 1 && ballX <= x + width - 2)
                    {
                        Ball();
                    }
                    ballX += 1 * dx;
                    ballY += 1 * dy;

                    //đụng trên, đụng dưới quay đầu
                    if (ballY == y + 1 || ballY >= y + height - 2)
                        dy *= -1;
                    //đụng Player1 (trái) quay đầu
                    else if (ballX == x + 2 && ballY >= yP1 && ballY <= yP1 + lengthP)
                    {
                        dx *= -1;
                        RandomBallY();
                    }
                    //đụng Player2 (phải) quay đầu
                    else if (ballX == x + width - 3 && ballY >= yP2 && ballY <= yP2 + lengthP)
                    {
                        dx *= -1;
                        RandomBallY();
                    }

                    //Player1 thua
                    else if (ballX == x + 1)
                    {
                        //Cộng điểm và in điểm cho Player2
                        p2Score++;
                        PrintScore(p2Score, 72);

                        //Xét chiến thắng
                        if (p2Score == 3)
                        {
                            WinGame();
                            continue;
                        }

                        //Bắt đầu lại
                        ResetBall();
                        Ball();
                        RandomBallX();
                        RandomBallY();
                    }
                    //Player2 thua
                    else if (ballX == x + width - 2)
                    {
                        //Cộng điểm và in điểm cho Player1
                        p1Score++;
                        PrintScore(p1Score, 0);

                        //Xét chiến thắng
                        if (p1Score == 3)
                        {
                            WinGame();
                            continue;
                        }

                        //Bắt đầu lại
                        ResetBall();
                        Ball();
                        RandomBallX();
                        RandomBallY();
                    }
                }
            }
            while (true);
        }

        //Điểm 
        #region Score
        static void PrintScore(int score, int location)
        {
            switch (score)
            {
                case 0:
                    {
                        Console.SetCursorPosition(x + location, y - 4);
                        Console.WriteLine("   __  ");
                        Console.SetCursorPosition(x + location, y - 3);
                        Console.WriteLine("  /  \\ ");
                        Console.SetCursorPosition(x + location, y - 2);
                        Console.WriteLine(" | () |");
                        Console.SetCursorPosition(x + location, y - 1);
                        Console.WriteLine("  \\__/ ");
                    }
                    break;
                case 1:
                    {
                        Console.SetCursorPosition(x + location, y - 4);
                        Console.WriteLine("   _    ");
                        Console.SetCursorPosition(x + location, y - 3);
                        Console.WriteLine("  / |   ");
                        Console.SetCursorPosition(x + location, y - 2);
                        Console.WriteLine("  | |   ");
                        Console.SetCursorPosition(x + location, y - 1);
                        Console.WriteLine("  |_|   ");
                    }
                    break;
                case 2:
                    {
                        Console.SetCursorPosition(x + location, y - 4);
                        Console.WriteLine("  ___ ");
                        Console.SetCursorPosition(x + location, y - 3);
                        Console.WriteLine(" |_  )");
                        Console.SetCursorPosition(x + location, y - 2);
                        Console.WriteLine("  / / ");
                        Console.SetCursorPosition(x + location, y - 1);
                        Console.WriteLine(" /___|");
                    }
                    break;
                case 3:
                    {
                        Console.SetCursorPosition(x + location, y - 4);
                        Console.WriteLine("  ____");
                        Console.SetCursorPosition(x + location, y - 3);
                        Console.WriteLine(" |__ /");
                        Console.SetCursorPosition(x + location, y - 2);
                        Console.WriteLine("  |_ \\");
                        Console.SetCursorPosition(x + location, y - 1);
                        Console.WriteLine(" |___/");
                    }
                    break;
            }
        }
        static void Score()
        {
            PrintScore(p1Score, 0);
            PrintScore(p2Score, 72);
        }
        #endregion

        //Wingame Menu
        #region WinGame
        static void WinGame()
        {
            gameOn = false;
            winGameOn = true;
            ClearScreen();
            Console.SetCursorPosition(x + width / 2 - 13, y + height / 2 - 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<><><                  ><><>");
            Console.SetCursorPosition(x + width / 2 - 7, y + height / 2 - 3);
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (p1Score == 3)
                Console.WriteLine("Player1 Win Game");
            else if (p2Score == 3)
                Console.WriteLine("Player2 Win Game");
            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(x + width / 2 - 12, y + height / 2 - 1);
            Console.WriteLine("Do you want to play again?");
            Console.SetCursorPosition(x + width / 2 - 12, y + height / 2);
            Console.WriteLine("Yes - Press 1");
            Console.SetCursorPosition(x + width / 2 - 12, y + height / 2 + 1);
            Console.WriteLine("No - Press 0");
        }
        #endregion

        //Hiển thị giao diện
        #region Show
        //In khung và pingpong và main menu
        static void ShowMenu()
        {
            ClearScreen();
            PingPong();
            Border();
            MainMenu();
        }
        //In giao diện lúc vào game
        static void ShowInGame()
        {
            ClearScreen();
            Console.SetCursorPosition(x + 2, y + height);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Press ESC to Pause game");
            Console.ForegroundColor = ConsoleColor.White;
            Score();
        }
        #endregion

        //Reset các giá trị của player,ball,score về lúc bắt đầu
        #region Reset
        static void ResetInGame()
        {
            ResetYPlayer();
            ResetBall();
            ResetScore();
            RandomBallX();
            RandomBallY();
        }
        static void ResetYPlayer()
        {
            yP1 = y + 7;
            yP2 = y + 7;
        }
        static void ResetBall()
        {
            ballX = x + (width / 2);
            ballY = y + (height / 2);
        }
        static void ResetScore()
        {
            p1Score = 0;
            p2Score = 0;
            PrintScore(p1Score, 0);
            PrintScore(p2Score, 72);
        }
        #endregion

        //Menu lúc pause game
        static void PauseMenu()
        {
            ClearScreen();
            Console.SetCursorPosition(x + width / 2 - 5, y + 2);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("PAUSE MENU");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x + width / 2 - 10, y + height / 3);
            Console.Write("Continue - Press A");
            Console.SetCursorPosition(x + width / 2 - 10, y + height / 3 + 2);
            Console.Write("Restart - Press B");
            Console.SetCursorPosition(x + width / 2 - 10, y + height / 3 + 4);
            Console.Write("Music - Press C");
            Console.SetCursorPosition(x + width / 2 - 10, y + height / 3 + 6);
            Console.Write("Back to MainMenu - Press D");
        }

        //Menu Exit game
        static void ExitMenu()
        {
            ClearScreen();
            Console.SetCursorPosition(x + width / 2 - 5, y + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("EXIT MENU");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x + width / 3 - 3, y + height / 3 + 1);
            Console.Write("Do you want to quit?\n");
            Console.SetCursorPosition(x + width / 3 - 3, y + height / 3 + 2);
            Console.Write("If yes type 'y', else type 'n': ");

            for (int i = 0; i < width / 2; i++)
            {

                Console.SetCursorPosition(x + width / 3 - 3 + i, y + height / 3);
                Console.Write("─");
            }

            char n;
            do
            {
                Console.SetCursorPosition(x + width / 3 + 33 - 3, y + height / 3 + 2);
                Console.ForegroundColor = ConsoleColor.Green;
                n = char.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (n != 'n' && n != 'y');

            if (n == 'y')
            {
                ClearScreen();
                Console.SetCursorPosition(x + width / 2 - 10, y + height / 3 + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Thank for playing ");
                Console.SetCursorPosition(x + width / 2 - 10 + 18, y + height / 3 + 1);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("<3");
                Thread.Sleep(1500);

                Environment.Exit(0);

            }
            else if (n == 'n')
                ShowMenu();
        }

        //Các lệnh để chuyển qua lại các Menu
        static void Input()
        {
            do
            {
                //Khi ở Main Menu
                while (costumesMenu == false && gameOn == false && winGameOn == false)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.A: ChooseEasy(); break;//Chọn mức dễ
                        case ConsoleKey.B: ChooseNormal(); break;//Chọn mức trung bình
                        case ConsoleKey.C: ChooseHard(); break;//Chọn mức khó
                        case ConsoleKey.D: { costumesMenu = true; CostumesMenu(); break; }//Mở Costumes Menu
                        case ConsoleKey.O: { ++idxMusic; ChooseMusic(); break; }//Bật tắt Music
                        case ConsoleKey.Escape: ExitMenu(); break;//Mở Menu Exit
                        case ConsoleKey.Enter: { ResetInGame(); ShowInGame(); gameOn = true; break; }//Vào game
                    }
                }

                //Khi ở Costumes Menu
                #region CostumesMenu
                //Mở menu costume để chỉnh màu cho Player1
                while (costumeP1 == true && costumesMenu == true)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.B: { costumeP1 = false; costumeP2 = true; SamplePlayer2(); break; }// mở menu chọn màu cho Player2
                        case ConsoleKey.Escape: { costumesMenu = false; MainMenu(); break; }//Thoát ra Main Menu
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
                //Mở menu costume để chỉnh màu cho Player2
                while (costumeP2 == true && costumesMenu == true)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.A: { costumeP1 = true; costumeP2 = false; SamplePlayer1(); break; }//Mở menu chọn màu cho Player2
                        case ConsoleKey.Escape: { costumesMenu = false; MainMenu(); break; } //Thoát ra Main Menu
                        //Chọn màu cho Player1
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
                #endregion

                //Khi vào game
                while (gameOn == true && winGameOn == false)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.W: 
                            {   
                                yP1--; //giảm 1 đơn vị của P1
                                if (yP1 < y + 1)//nếu đụng trên thì tăng yP1 lên 1 đơn vị
                                    yP1++; 
                                up1 =true;
                                down1 = false;
                                break;
                            }
                        case ConsoleKey.S: 
                            { 
                                yP1++;
                                if (yP1 + lengthP > y + height - 1)//nếu đụng dưới thì giảm yP1 xuống 1 đơn vị
                                    yP1--;
                                up1 = false; 
                                down1 = true; 
                                break; 
                            }
                        case ConsoleKey.UpArrow: 
                            { 
                                yP2--;
                                if (yP2 < y + 1)//nếu đụng trên thì tăng yP2 lên 1 đơn vị
                                    yP2++;
                                up2 = true; 
                                down2 = false; 
                                break; 
                            }
                        case ConsoleKey.DownArrow: 
                            { 
                                yP2++;
                                if (yP2 + lengthP > y + height - 1//nếu đụng dưới thì giảm yP2 xuống 1 đơn vị
                                    yP2--;
                                up2 = false; 
                                down2 = true; 
                                break; 
                            }
                        case ConsoleKey.Escape: { pauseMenuOn = true; gameOn = false; PauseMenu(); break; }//Mở Menu Pause game
                        case ConsoleKey.D1://Khi win game nhấn 1 để chơi tiếp
                            {
                                if (winGameOn == true)
                                {
                                    ResetInGame();
                                    ShowInGame();
                                    gameOn = true;
                                    winGameOn = false;
                                }
                                break;
                            }

                        case ConsoleKey.D0://Khi win game nhấn 0 để trở về Main Menu
                            {
                                if (winGameOn == true)
                                {
                                    ShowMenu();
                                    winGameOn = false;
                                }
                                break;
                            }
                    }
                }

                //Khi win game 
                while (winGameOn == true) //tương tự như wingame ở trên (mục đích của dòng này em ghi trong word ạ)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    if (consoleKey == ConsoleKey.D1)
                    {
                        ResetInGame();
                        ShowInGame();
                        winGameOn = false;
                        gameOn = true;
                    }
                    else if (consoleKey == ConsoleKey.D0)
                    {
                        ShowMenu();
                        winGameOn = false;
                    }
                }

                //Khi pause game
                while (pauseMenuOn == true)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.A: { ShowInGame(); Thread.Sleep(200); gameOn = true; pauseMenuOn = false; break; } //tiếp tục game
                        case ConsoleKey.B: { ResetInGame(); ShowInGame(); Thread.Sleep(200); gameOn = true; pauseMenuOn = false; break; }//chơi lại từ đầu
                        case ConsoleKey.C: { ++idxMusic; break; }//bật tắt nhạc
                        case ConsoleKey.D: { ShowMenu(); pauseMenuOn = false; break; }//thoát về Main Menu
                    }
                }
            }
            while (true);
        }


        static void Whole()
        {
            Thread showMenu = new Thread(ShowMenu);
            Thread input = new Thread(Input);
            Thread update = new Thread(Update);
            Thread sweetChild = new Thread(SweetChild);
            showMenu.Start();
            input.Start();
            update.Start();
            sweetChild.Start();
        }
    }
}
