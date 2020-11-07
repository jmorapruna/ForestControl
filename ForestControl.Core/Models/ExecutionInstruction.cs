using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class ExecutionInstruction
    {
        public Position InitialPosition { get; set; }
        public IDirection InitialDirection { get; set; }
        public IEnumerable<IExecutionStep> Steps { get; set; }
    }
}
