using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class PacManPath
    {

        public List<Coordinate> Coordinates { get; set; }

        public PacManPath()
        {
            Coordinates = new List<Coordinate>();

        }
        public bool isDot(int left, int top)
        {
            bool isDot = true;
            for (int i = 0; i < Coordinates.Count; i++)
            {
                if (Coordinates[i].Top == top && Coordinates[i].Left == left)
                {
                    isDot = false;
                    break;
                }
            }
            return isDot;
        }
    }
}
