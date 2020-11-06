using System;

namespace ForestControl.Core
{
    public class WestDirection : IDirection
    {
    }

    public static partial class Directions
    {
        public static IDirection West = new WestDirection();
    }
}
