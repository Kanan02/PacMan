using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PacMan.Game;

namespace PacMan
{
    class Ghost: IMoveable
    {
        public Ghost()
        {
            //Special random generator 
            int change = RandomNumber(0,2);
            Top = 1;
            if (change==1)
            {
                Top = RandomNumber(2, 10);
            }
            
            if (Top==1)
            {
                Left = RandomNumber(15, 80);
            }
            else if(Top==2||Top==3||Top==4||Top==5)
            {
                Left = RandomNumber(26, 31);
            }
            else 
            {
                Left = RandomNumber(68, 72);
            }

            consoleColor = (ConsoleColor)RandomNumber(0, 16);
            

        }
        public PacManPath Path { get; set; }
        private char ghost = '\u0488';
        private ConsoleColor consoleColor;

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { 
                return random.Next(min, max);
            }
        }

        public int Left { get; set; }
        public int Top { get; set; }
        public void Move()
        {


            Console.SetCursorPosition(Left, Top);
            int left = Left, top = Top;

            int direction = RandomNumber(37, 41);

            switch (direction)
            {
                case 38:
                    top--;
                    break;
                case 40:
                    top++;
                    break;
                case 37:
                    left--;
                    break;
                case 39:
                    left++;
                    break;
            
            }


            if (isWall(top, left))
            {
                PrintGhost();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            if (Path.isDot(Left,Top))
            {
                Console.Write('\u00B7');
            }
            else
            {
                Console.Write(' ');
            }
            Console.ForegroundColor = ConsoleColor.White;

            Top = top;
            Left = left;
            

            Console.SetCursorPosition(Left, Top);
            PrintGhost();

        }

       

        public void PrintGhost()
        {
            Console.SetCursorPosition(Left, Top);
            Console.ForegroundColor = consoleColor;
            Console.Write(ghost);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Left, Top);
        }
       
    }
}
