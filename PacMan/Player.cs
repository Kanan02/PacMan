using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Player:IComparable
    {
        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }
        public Player()
        {
            Name = "";
            Score = 0;
        }
        public override string ToString()
        {
            return $"Name: {Name}   Score: {Score}";
        }

       

        public int CompareTo(object obj)
        {
            return this.Score.CompareTo((obj as Player).Score);
        }

        public string Name { get; set; }

        public int Score { get; set; }
        public ConsoleColor Skin { get; set; }

    }
}
