using System;

namespace ForestControl.Core
{
    class WestDirection : IDirection
    {
        public char GetCode() => 'O';
    }

    public static partial class Directions
    {
        public static IDirection West = new WestDirection();
    }
}
