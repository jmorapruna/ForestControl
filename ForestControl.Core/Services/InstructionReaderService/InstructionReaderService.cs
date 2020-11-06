using ForestControl.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<Position> ReadInitialPosition()
        {
            string line = await _inputReader.ReadLineAsync();
            var positionString = line.Split(' ');

            int x = int.Parse(positionString[0].Trim());
            int y = int.Parse(positionString[1].Trim());

            var position = new Position(x, y);
            return position;
        }
    }
}
