using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PacMan.Game;

namespace PacMan
{


    class Pacman 
    {
       
        public Pacman(int left, int top)
        {
            Left = left;
            Top = top;
            Path = new PacManPath();
            //Add the first coordinate and eat the dot
            Coordinate c = new Coordinate();
            c.Left = Left;
            c.Top = Top;
            Path.Coordinates.Add(c);
            EatDot();
        }
        public PacManPath Path { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        private char pacman = '\u263B';
        
        public event GameMusic Chomp;

        public int Points { get; set; }
   
       
        public void Move(ConsoleKey consoleKey)
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

        public void PrintPacman()
        {
            Console.SetCursorPosition(Left, Top);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(pacman);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Left, Top);
        }

        private void EatDot()
        {
            Points += 20;
            Chomp = PlayMusic;
            Chomp.Invoke("pacman_chomp.wav");
        }
    }
}
