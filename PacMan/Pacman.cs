using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PacMan.Game;

namespace PacMan
{


    class Pacman :PacmanAbstract
    {
        public Pacman(int left, int top,ConsoleColor skinColor):base(left,top,skinColor)
        {
            
            
            Coordinate c = new Coordinate();
            c.Left = Left;
            c.Top = Top;
            Path.Coordinates.Add(c);
            EatDot();
            SkinColor = skinColor;
            
        }
        public override void Move(ConsoleKey consoleKey)
        {
           
            
            Console.SetCursorPosition(Left, Top);
            int left=Left, top=Top;
            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    top--;
                    break;
                case ConsoleKey.DownArrow:
                    top++;
                    break;
                case ConsoleKey.LeftArrow:
                    left--;
                    break;
                case ConsoleKey.RightArrow:
                    left++;
                    break;

            }
            if (isWall(top,left))
            {
                PrintPacman();
                return;
            }
            Top = top;
            Left = left;
            Console.Write(' ');
            Console.SetCursorPosition(Left, Top);
            PrintPacman();

            if (Path.isDot(Left,Top))
            {
                Coordinate c=new Coordinate();
                c.Left = Left;
                c.Top = Top;
                Path.Coordinates.Add(c);
                EatDot();
            }

        }
    }
}
