using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class GoForwardExecutionStep : IExecutionStep
    {
        public IDirection GetNextDirection(IDirection direction) => direction;
        
        public Vector GetNextPosition(Vector position, IDirection direction)
        {
            var delta = direction.GetPositionDeltaForAForwardStep();

            return new Vector(position.X + delta.X, position.Y + delta.Y);
        }
    }

    public static partial class ExecutionSteps
    {
        public static IExecutionStep GoForward = new GoForwardExecutionStep();
    }
}
