using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PacMan.Game;

namespace PacMan
{
    abstract class PacmanAbstract
    {
        public  void PrintSimplePacman()
        {
            Console.ForegroundColor = SkinColor;
            Console.Write(pacman);
            Console.ForegroundColor = ConsoleColor.White;

        }

        protected char pacman = '\u263B';

        public ConsoleColor SkinColor { get; set; }
 
        public PacmanAbstract(int left, int top, ConsoleColor skinColor)
        {
            Path = new PacManPath();
            Left = left;
            Top = top;
            SkinColor = skinColor;
        }
        public PacmanAbstract()
        {

        }
        public PacManPath Path { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }

        public event GameMusic Chomp;

        public int Points { get; set; }

        public abstract void Move(ConsoleKey consoleKey);



        protected void EatDot()
        {
            Points += 20;
            Chomp = PlayMusic;
            Chomp.Invoke("pacman_chomp.wav");
        }

        public void PrintPacman()
        {
            Console.SetCursorPosition(Left, Top);
            Console.ForegroundColor = SkinColor;
            Console.Write(pacman);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Left, Top);
        }
    }
        
    }
