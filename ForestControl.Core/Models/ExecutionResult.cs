using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class ExecutionResult
    {
        public Vector FinalPosition { get; set; }
        public IDirection FinalDirection { get; set; }
    }
}
