using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PacMan.Game;

namespace PacMan
{
    class SuperPacman : PacmanAbstract
    {
        public int Step { get; set; }
        public SuperPacman(int left, int top, ConsoleColor skinColor,int step):base(left,top,skinColor)
        {
            Step = step;
        }
        public override void Move(ConsoleKey consoleKey)
        {


            Console.SetCursorPosition(Left, Top);
            int left = Left, top = Top;
            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    top-=Step;
                    break;
                case ConsoleKey.DownArrow:
                    top+=Step;
                    break;
                case ConsoleKey.LeftArrow:
                    left-=Step;
                    break;
                case ConsoleKey.RightArrow:
                    left+=Step;
                    break;

            }
            if (isWall(top, left))
            {
                PrintPacman();
                return;
            }
            Top = top;
            Left = left;
            Console.Write(' ');
            Console.SetCursorPosition(Left, Top);
            PrintPacman();

            if (Path.isDot(Left, Top))
            {
                Coordinate c = new Coordinate();
                c.Left = Left;
                c.Top = Top;
                Path.Coordinates.Add(c);
                EatDot();
            }

        }

    }
}
