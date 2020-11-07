using ForestControl.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForestControl.Core
{
    public interface IInstructionReaderService
    {
        Vector ReadInitialPosition(string firstLine);
        ExecutionInstruction ReadTwoLinesOfInstructions(string line1, string line2);
    }
}
