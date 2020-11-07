using ForestControl.Core.Models;
using System;

namespace ForestControl.Core
{
    class WestDirection : IDirection
    {
        public char GetCode() => 'O';

        public IDirection GetTurnLeftNextDirection() => Directions.South;

        public IDirection GetTurnRightNextDirection() => Directions.North;

        public Vector GetPositionDeltaForAForwardStep() => ForwardDirectionVectors.West;
    }

    public static partial class Directions
    {
        public static IDirection West = new WestDirection();
    }
}
