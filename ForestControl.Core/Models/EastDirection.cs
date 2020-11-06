using System;

namespace ForestControl.Core
{
    public class EastDirection : IDirection
    {
    }

    public static partial class Directions
    {
        public static IDirection East = new EastDirection();
    }
}
