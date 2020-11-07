using System;

namespace ForestControl.Core
{
    class EastDirection : IDirection
    {
    }

    public static partial class Directions
    {
        public static IDirection East = new EastDirection();
    }
}
