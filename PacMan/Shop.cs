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
            Pacmans = new PacmanAbstract[2]
            {
               new Pacman(50,11,ConsoleColor.Red),
               new SuperPacman(50,11,ConsoleColor.Green,2),
            };
        }


        public PacmanAbstract PrintShop()
        {
            Console.WriteLine("Welcome to shop, choose the skin:");
            Console.Write($"1.Default(");
            Pacmans[0].PrintSimplePacman();
            Console.WriteLine(")");
            Console.Write($"2.SuperPacman(");
            Pacmans[1].PrintSimplePacman();
            Console.WriteLine(")");
            Console.WriteLine();

            int choice =Int32.Parse( Console.ReadLine());
            return Pacmans[choice - 1];

        }

        
    }
}
