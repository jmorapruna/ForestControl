using System;

namespace ForestControl.Core
{
    class SouthDirection : IDirection
    {
        public char GetCode() => 'S';

        public IDirection GetTurnLeftNextDirection() => Directions.East;

        public IDirection GetTurnRightNextDirection() => Directions.West;
    }

    public static partial class Directions
    {
        public static IDirection South = new SouthDirection();
    }
}
