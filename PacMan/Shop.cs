using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class Shop
    {
        public PacmanAbstract[] Pacmans { get; set; }
        public Shop()
        {
            Pacmans = new Pacman[4]
            {
               new Pacman(ConsoleColor.Red),
               new Pacman(ConsoleColor.Green),
               new Pacman(ConsoleColor.Yellow),
               new Pacman(ConsoleColor.Blue)
            };
        }


        public ConsoleColor PrintShop()
        {
            Console.WriteLine("Welcome to shop, choose the skin:");
            for (int i = 0; i < Pacmans.Length; i++)
            {

                Console.Write($"{i + 1}.");
                Pacmans[i].PrintSimplePacman();
                Console.Write('\t');

            }
            Console.WriteLine();

            int choice =Int32.Parse( Console.ReadLine());
            return Pacmans[choice - 1].SkinColor;

        }

        
    }
}
