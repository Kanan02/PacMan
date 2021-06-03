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
        public Pacman( ConsoleColor skinColor)
        {
            
            SkinColor = skinColor;

        }
        public Pacman(int left, int top,ConsoleColor skinColor)
        {
            Left = left;
            Top = top;
            Path = new PacManPath();
            Coordinate c = new Coordinate();
            c.Left = Left;
            c.Top = Top;
            Path.Coordinates.Add(c);
            EatDot();
            SkinColor = skinColor;

        }
        public PacManPath Path { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }

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

       

        private void EatDot()
        {
            Points += 20;
            Chomp = PlayMusic;
            Chomp.Invoke("pacman_chomp.wav");
        }

        public  void PrintPacman()
        {
            Console.SetCursorPosition(Left, Top);
            Console.ForegroundColor = SkinColor;
            Console.Write(pacman);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Left, Top);
        }
        public override void PrintSimplePacman()
        {
            
            Console.ForegroundColor = SkinColor;
            Console.Write(pacman);
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
