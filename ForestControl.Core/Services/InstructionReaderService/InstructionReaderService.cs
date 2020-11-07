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
        private readonly StreamReader _inputReader;

        public InstructionReaderService(Stream inputStream)
        {
            _inputReader = new StreamReader(inputStream);
        }

        public async Task<Position> ReadInitialPositionAsync()
        {
            string line = await _inputReader.ReadLineAsync();
            var positionString = line.Split(' ');

            int x = int.Parse(positionString[0]);
            int y = int.Parse(positionString[1]);

            var position = new Position(x, y);
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

        public async Task<ExecutionInstruction> ReadTwoLinesOfInstructions()
        {
            string firstLine = await _inputReader.ReadLineAsync();
            if (firstLine == null)
                return null;

            var initialPositionString = firstLine.Split(' ');

            int x = int.Parse(initialPositionString[0]);
            int y = int.Parse(initialPositionString[1]);
            var initialPosition = new Position(x, y);

            string initialDirectionCode = initialPositionString[2];
            var initialDirection = _ParseDirection(initialDirectionCode);

            string secondLine = await _inputReader.ReadLineAsync();
            if (secondLine == null)
                return null;

            var steps = secondLine
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
