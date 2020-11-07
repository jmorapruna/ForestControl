using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class Drone
    {
        public Drone(Position position, IDirection direction)
        {
            Position = position;
            Direction = direction;
        }

        public void ExecuteStep(IExecutionStep step)
        {
            Direction = step.GetNextDirection(Direction);
        }

        public Position Position { get; private set; }
        public IDirection Direction { get; private set; }
    }
}
