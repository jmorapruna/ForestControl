using System;

namespace ForestControl.Core
{
    class NorthDirection : IDirection
    {
        public char GetCode() => 'N';
    }

    public static partial class Directions
    {
        public static IDirection North = new NorthDirection();
    }
}
