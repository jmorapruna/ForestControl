using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class TurnLeftExecutionStep : IExecutionStep
    {
    }

    public static partial class ExecutionSteps
    {
        public static IExecutionStep TurnLeft = new TurnLeftExecutionStep();
    }
}
