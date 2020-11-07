using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class Vector
    {
        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }

    public static class ForwardDirectionVectors
    {
        public static Vector East = new Vector(1, 0);
        public static Vector North = new Vector(0, 1);
        public static Vector West = new Vector(-1, 0);
        public static Vector South = new Vector(0, -1);
    }
}
