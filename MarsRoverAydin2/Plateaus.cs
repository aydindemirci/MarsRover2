using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverAydin2
{
    class Plateaus : Coordinate
    {
        public void Set(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public int Get(string coordinate)
        {
            return coordinate=="X" ? X : Y;
        }

    }
}
