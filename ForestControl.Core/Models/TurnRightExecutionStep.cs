using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class TurnRightExecutionStep : IExecutionStep
    {
    }

    public static partial class ExecutionSteps
    {
        public static IExecutionStep TurnRight = new TurnRightExecutionStep();
    }
}
