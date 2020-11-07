using ForestControl.Core.Models;
using System;

namespace ForestControl.Core
{
    class NorthDirection : IDirection
    {
        public char GetCode() => 'N';

        public IDirection GetTurnLeftNextDirection() => Directions.West;

        public IDirection GetTurnRightNextDirection() => Directions.East;

        public Vector GetPositionDeltaForAForwardStep() => ForwardDirectionVectors.North;
    }

    public static partial class Directions
    {
        public static IDirection North = new NorthDirection();
    }
}
