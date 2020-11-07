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
            AreaDimensions = areaDimensions;
        }

        /// <summary>
        /// <c>_ComputeSlidingValue</c> computes a new vector component taking into account the dimension size:
        /// The vector component that's one step outside the range [1, <c>dimensionSize</c>] will return the value of the other side.
        /// </summary>
        /// <param name="coordinateComponent">Component of the component inside the range [0, <c>dimensionSize</c>+1]</param>
        /// <param name="dimensionSize">Size of the dimension, greater than 0</param>
        /// <returns></returns>
        private static int _ComputeSlidingValue(int coordinateComponent, int dimensionSize)
        {
            if (coordinateComponent == 0)
                return dimensionSize;

            if (coordinateComponent == dimensionSize + 1)
                return 1;

            return coordinateComponent;
        }

        public void ExecuteStep(IExecutionStep step)
        {
            // this position does not take the area dimensions into account
            var position = step.GetNextPosition(Position, Direction);

            // the final position takes the area dimensions into account
            Position = new Vector(
                _ComputeSlidingValue(position.X, AreaDimensions.X),
                _ComputeSlidingValue(position.Y, AreaDimensions.Y)
            );

            Direction = step.GetNextDirection(Direction);
        }

        public Vector Position { get; private set; }
        public IDirection Direction { get; private set; }
        public Vector AreaDimensions { get; private set; }
    }
}
