using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PacMan
{
    
    
    class Game:IMoveable
    {
        #region Ctor

       
        public Game(int nGhosts, int numberOfMilliseconds,bool hasSound,PacmanAbstract pacman)
        {
            DisplayBoard();
            HasSound = hasSound;

            Pacman = pacman;
            this.numberOfMilliseconds = numberOfMilliseconds;
            Ghosts = new List<Ghost>(nGhosts);
            for (int i = 0; i < nGhosts; i++)
            {
                Ghosts.Add(new Ghost());


            }
            foreach (var item in Ghosts)
            {
                item.PrintGhost();
                item.Path = Pacman.Path;
            }
            Pacman.PrintPacman();

            Start += PlayMusic;
            Start.Invoke("pacman_beginning.wav");

            string map = "\t _________________________________________________________________________________\n\t|                                                                                 |\n\t|           |\u0305\u0305\u0305\u0305|                   |\u0305\u0305\u0305\u0305\u0305\u0305\u0305|                   |\u0305\u0305\u0305\u0305|           |\n\t|           |    |                   |       |                   |    |           |\n\t|           |____|                   |       |                   |____|           |\n\t|\u0305\u0305\u0305\u0305\u0305\u0305\u0305|              |\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305         \u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305|              |\u0305\u0305\u0305\u0305\u0305\u0305\u0305|\n\t|       |              |                                   |              |       |\n\t|_______|              |_____________         _____________|              |_______|\n\t|           |\u0305\u0305\u0305\u0305|                   |       |                   |\u0305\u0305\u0305\u0305|           |\n\t|           |    |                   |       |                   |    |           |\n\t|           |____|                   |_______|                   |____|           |\n\t|                                                                                 |\n\t \u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\n";
            map = map.Replace("\t", "        ");
            
            char[] mymap = new char[1400];

            for (int i = 0; i < map.Length; i++)
            {
                mymap[i] = map[i];
            }

            Map2D = Make2DArray(mymap, 13, 92);

        }

        #endregion

        #region Parameters

        public static bool HasSound { get; set; }
        public delegate void GameMusic(string music);
        public event GameMusic Start;
        
        public event GameMusic Death;
        public PacmanAbstract Pacman { get; set; }
        public List<Ghost> Ghosts { get; set; }

        private char dot = Char.Parse("\u00B7");
        private int numberOfMilliseconds;
        public static char[,] Map2D { get; set; }


        #endregion


        #region MoveAndPrintBoard

       
        public void Move()
        {
          
            var response = ConsoleKey.RightArrow;
            bool isEnd = false;
            while (!isEnd)
            {
                while (!Console.KeyAvailable&&!isEnd)
                {
                    Pacman.Move(response);
                    
                    foreach (var item in Ghosts)
                    {
                        item.Move();

                        if (Pacman.Left==item.Left&&Pacman.Top==item.Top)
                        {
                            Death += PlayMusic;
                            Death.Invoke("pacman_death.wav");
                            isEnd = true;
                            Console.SetCursorPosition(20, 17);

                            Console.WriteLine("\t\tThe End!");
                            Thread.Sleep(4000);
                            
                            Console.WriteLine("Press Enter to continue.");
                            break;
                        }
                        if (Pacman.Points == 12120)
                        {
                            isEnd = true;
                            Console.WriteLine("You won!!");
                            break;
                        }
                       
                    }

                    Thread.Sleep(numberOfMilliseconds);
                    Console.SetCursorPosition(92, 2);
                    Console.WriteLine("You Score is: "+Pacman.Points);
                    Console.SetCursorPosition(92, 3);
                    Console.WriteLine("Press Q to Quit.");
                }

                response = (Console.ReadKey()).Key;
                if (response==ConsoleKey.Q)
                {
                    break;
                }
            }


        }



        public void DisplayBoard()
        {


            #region BoringPrint

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\t _________________________________________________________________________________");
            Console.WriteLine("\t|                                                                                 |".Replace(' ', dot));
            Console.WriteLine("\t|           |\u0305\u0305\u0305\u0305|                   |\u0305\u0305\u0305\u0305\u0305\u0305\u0305|                   |\u0305\u0305\u0305\u0305|           |".Replace(' ', dot));


            Console.Write("\t|           |".Replace(' ', dot));
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("|                   |".Replace(' ', dot));
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("       ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("|                   |".Replace(' ', dot));
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("|           |".Replace(' ', dot));


            Console.Write("\t|           |____|                   |".Replace(' ', dot));
            Console.Write("       ");
            Console.WriteLine("|                   |____|           |".Replace(' ', dot));


            Console.Write("\t|\u0305\u0305\u0305\u0305\u0305\u0305\u0305|              |\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305".Replace(' ', dot));
            Console.Write("         ");
            Console.WriteLine("\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305|              |\u0305\u0305\u0305\u0305\u0305\u0305\u0305|".Replace(' ', dot));


            Console.Write("\t|");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("       ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("|              |".Replace(' ', dot));
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("                                   ");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Write("|              |".Replace(' ', dot));
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("       ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("|");


            Console.Write("\t|_______|              |_____________".Replace(' ', dot)); Console.Write("         "); Console.WriteLine("_____________|              |_______|".Replace(' ', dot));
            Console.Write("\t|           |\u0305\u0305\u0305\u0305|                   ".Replace(' ', dot)); Console.Write("|       |"); Console.WriteLine("                   |\u0305\u0305\u0305\u0305|           |".Replace(' ', dot));


            Console.Write("\t|           |".Replace(' ', dot));
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("|                   |".Replace(' ', dot));
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("       ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("|                   |".Replace(' ', dot));
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("|           |".Replace(' ', dot));


            Console.WriteLine("\t|           |____|                   |_______|                   |____|           |".Replace(' ', dot));
            Console.WriteLine("\t|                                                                                 |".Replace(' ', dot));
            Console.WriteLine("\t \u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305");
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
        }


        #endregion


        #region Static Methods
        private static char[,] Make2DArray(char[] input, int height, int width)
        {
            char[,] output = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output[i, j] = input[i * width + j];
                }
            }
            return output;
        }


        public static void PlayMusic(string music)
        {
            if (HasSound)
            {

                try
                {


                    SoundPlayer player = new SoundPlayer($"{AppContext.BaseDirectory}\\{music}");
                    if (music == "pacman_beginning.wav")
                    {
                        player.PlaySync();
                    }
                    else
                    {
                        player.Play();
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }

        public static bool isWall(int top, int left)
        {
            if (top<1||left<7||left>90||top>11)
            {
                return true;
            }
            return (Map2D[top, left - 1] == '|' || Map2D[top, left - 1] == '\u0305' || Map2D[top, left - 1] == '_');

        }


        #endregion



    }

}
