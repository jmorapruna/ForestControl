using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class GoForwardExecutionStep : IExecutionStep
    {
    }

    public static partial class ExecutionSteps
    {
        public static IExecutionStep GoForward = new GoForwardExecutionStep();
    }
}
