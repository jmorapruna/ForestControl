using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class ExecutionResult
    {
        public Position FinalPosition { get; set; }
        public IDirection FinalDirection { get; set; }
    }
}
