using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    abstract class PacmanAbstract
    {
        public abstract void PrintSimplePacman();

        protected char pacman = '\u263B';
        
        public ConsoleColor SkinColor { get; set; }
    }
}
