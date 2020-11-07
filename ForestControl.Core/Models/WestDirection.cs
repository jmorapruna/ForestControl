using System;

namespace ForestControl.Core
{
    class WestDirection : IDirection
    {
    }

    public static partial class Directions
    {
        public static IDirection West = new WestDirection();
    }
}
