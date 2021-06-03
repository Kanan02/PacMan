using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PacMan
{
    
    
    
    class Program
    {
        public static bool HasXmlFile()
        {

            DirectoryInfo directoryInfo = new DirectoryInfo(AppContext.BaseDirectory);
            foreach (var item in directoryInfo.GetFiles())
            {

                if (item.Name == "players.xml")
                {
                    return true;
                }

            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            XMLFileHandler xmlFileHandler = new XMLFileHandler();
            if (!HasXmlFile())
            {
                xmlFileHandler.CreateXmlFile();
            }
            PrintPacManWord();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tWelcome to Pacman!");
            
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            if (xmlFileHandler.IsOldPlayer(name))
            {
                Console.WriteLine($"Welcome back {name}, your best score is {xmlFileHandler.Players.Where(x=>x.Name==name).ElementAt(0).Score}!");
            }
            bool sound = true;
            while (true)
            {

                Console.WriteLine("1.Play  2.ScoreBoard 3.Settings 4.Exit");
                int choice = Int32.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("1.Easy 2.Medium  3.Hard");
                    int choice2 = Int32.Parse(Console.ReadLine());
                    Game game;
                    Console.Clear();
                    PrintPacManWord();
                    Console.SetCursorPosition(0, 0);
                    if (choice2 == 1)
                    {
                        game = new Game(8, 1000,sound);
                    }
                    else if (choice2 == 2)
                    {
                        game = new Game(12, 800,sound);
                    }
                    else
                    {
                        game = new Game(20, 500,sound);
                    }
                    game.Move();
                    Console.Clear();
                    Player player = new Player(name, game.Pacman.Points);

                    xmlFileHandler.AddPlayer(player);

                    xmlFileHandler.LoadListToFile();

                }
                else if (choice == 2)
                {
                    xmlFileHandler.Players.Sort();
                    xmlFileHandler.Players.Reverse();
                    int i = 1;
                    foreach (var item in xmlFileHandler.Players)
                    {

                        Console.WriteLine($"№ {i}. "+item);
                        i++;
                    }


                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                else if (choice == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Volume");
                    Console.WriteLine("1.On 2.Off 3.Back");
                    int volume =int.Parse(Console.ReadLine());
                    if (volume==1)
                    {
                        sound = true;
                    }
                    else if(volume == 2)
                    {
                        sound = false;
                    }
                    else
                    {
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                }
                else if(choice==4)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }





        public static void PrintPacManWord()
        {
            
            Console.ForegroundColor = ConsoleColor.Red;
            
            int left = 20;
            Console.SetCursorPosition(left, 20);
            Console.WriteLine("*******");
            Console.SetCursorPosition(left, 21);
            Console.WriteLine("*     *");
            Console.SetCursorPosition(left, 22);
            Console.WriteLine("*******");
            Console.SetCursorPosition(left, 23);
            Console.WriteLine("*");
            Console.SetCursorPosition(left, 24);
            Console.WriteLine("*");
            left += 10;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(left, 20);
            Console.WriteLine("  **  ");
            Console.SetCursorPosition(left, 21);
            Console.WriteLine("*    *");
            Console.SetCursorPosition(left, 22);
            Console.WriteLine("******");
            Console.SetCursorPosition(left, 23);
            Console.WriteLine("*    *");
            Console.SetCursorPosition(left, 24);
            Console.WriteLine("*    *");
            left += 10;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(left, 20);
            Console.WriteLine("*******");
            Console.SetCursorPosition(left, 21);
            Console.WriteLine("*     ");
            Console.SetCursorPosition(left, 22);
            Console.WriteLine("*     ");
            Console.SetCursorPosition(left, 23);
            Console.WriteLine("*     ");
            Console.SetCursorPosition(left, 24);
            Console.WriteLine("*******");
            left += 10;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(left, 20);
            Console.WriteLine("*       *");
            Console.SetCursorPosition(left, 21);
            Console.WriteLine("* *  *  *");
            Console.SetCursorPosition(left, 22);
            Console.WriteLine("*   *   *");
            Console.SetCursorPosition(left, 23);
            Console.WriteLine("*       *");
            Console.SetCursorPosition(left, 24);
            Console.WriteLine("*       *");
            left += 11;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(left, 20);
            Console.WriteLine("  **  ");
            Console.SetCursorPosition(left, 21);
            Console.WriteLine("*    *");
            Console.SetCursorPosition(left, 22);
            Console.WriteLine("******");
            Console.SetCursorPosition(left, 23);
            Console.WriteLine("*    *");
            Console.SetCursorPosition(left, 24);
            Console.WriteLine("*    *");
            left += 9;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(left, 20);
            Console.WriteLine("**       *");
            Console.SetCursorPosition(left, 21);
            Console.WriteLine("* *      *");
            Console.SetCursorPosition(left, 22);
            Console.WriteLine("*   *    *");
            Console.SetCursorPosition(left, 23);
            Console.WriteLine("*     *  *");
            Console.SetCursorPosition(left, 24);
            Console.WriteLine("*       **");

        }


    }

}
