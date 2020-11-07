using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class Drone
    {
        public Drone(Vector position, IDirection direction, Vector areaDimensions)
        {
            Position = position;
            Direction = direction;

            // TODO take into account
            AreaDimensions = areaDimensions;
        }

        public void ExecuteStep(IExecutionStep step)
        {
            Position = step.GetNextPosition(Position, Direction);
            Direction = step.GetNextDirection(Direction);
        }

        public Vector Position { get; private set; }
        public IDirection Direction { get; private set; }
        public Vector AreaDimensions { get; private set; }
    }
}
