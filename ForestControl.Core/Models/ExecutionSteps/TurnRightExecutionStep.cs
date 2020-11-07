using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class TurnRightExecutionStep : IExecutionStep
    {
        public IDirection GetNextDirection(IDirection direction) => direction.GetTurnRightNextDirection();

        public Vector GetNextPosition(Vector position, IDirection direction) => position;
    }

    public static partial class ExecutionSteps
    {
        public static IExecutionStep TurnRight = new TurnRightExecutionStep();
    }
}
