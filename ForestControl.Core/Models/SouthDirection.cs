using System;

namespace ForestControl.Core
{
    public class SouthDirection : IDirection
    {
    }

    public static partial class Directions
    {
        public static IDirection South = new SouthDirection();
    }
}
