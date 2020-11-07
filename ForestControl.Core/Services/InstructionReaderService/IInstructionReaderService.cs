using ForestControl.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForestControl.Core.Services
{
    public interface IInstructionReaderService
    {
        Task<Position> ReadInitialPositionAsync();
        Task<ExecutionInstruction> ReadTwoLinesOfInstructions();
    }
}
