using ForestControl.Core.Models;
using System;

namespace ForestControl.Core
{
    class EastDirection : IDirection
    {
        public char GetCode() => 'E';

        public IDirection GetTurnLeftNextDirection() => Directions.North;

        public IDirection GetTurnRightNextDirection() => Directions.South;

        public Vector GetPositionDeltaForAForwardStep() => ForwardDirectionVectors.East;
    }

    public static partial class Directions
    {
        public static IDirection East = new EastDirection();
    }
}
