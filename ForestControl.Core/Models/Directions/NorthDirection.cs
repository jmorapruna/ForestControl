using System;

namespace ForestControl.Core
{
    class NorthDirection : IDirection
    {
    }

    public static partial class Directions
    {
        public static IDirection North = new NorthDirection();
    }
}
