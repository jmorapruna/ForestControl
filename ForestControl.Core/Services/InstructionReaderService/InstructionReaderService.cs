using ForestControl.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestControl.Core.Services
{
    public class InstructionReaderService : IInstructionReaderService
    {
        public Vector ReadInitialPosition(string firstLine)
        {
            var positionString = firstLine.Split(' ');

            int x = int.Parse(positionString[0]);
            int y = int.Parse(positionString[1]);

            var position = new Vector(x, y);
            return position;
        }

        private static IDirection _ParseDirection(string code)
        {
            switch (code)
            {
                case "N":
                    return Directions.North;
                case "S":
                    return Directions.South;
                case "E":
                    return Directions.East;
                case "W":
                default:
                    return Directions.West;
            }
        }

        private static IExecutionStep _ParseExecutionStep(char code)
        {
            switch (code)
            {
                case 'L':
                    return ExecutionSteps.TurnLeft;
                case 'R':
                    return ExecutionSteps.TurnRight;
                default:
                case 'M':
                    return ExecutionSteps.GoForward;
            }
        }

        public ExecutionInstruction ReadTwoLinesOfInstructions(string line1, string line2)
        {
            if (line1 == null || line2 == null)
                return null;

            var initialPositionString = line1.Split(' ');

            int x = int.Parse(initialPositionString[0]);
            int y = int.Parse(initialPositionString[1]);
            var initialPosition = new Vector(x, y);

            string initialDirectionCode = initialPositionString[2];
            var initialDirection = _ParseDirection(initialDirectionCode);

            var steps = line2
                .Select(c => _ParseExecutionStep(c))
                .ToArray();

            return new ExecutionInstruction()
            {
                InitialDirection = initialDirection,
                InitialPosition = initialPosition,
                Steps = steps,
            };
        }
    }
}
