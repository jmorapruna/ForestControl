﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core.Models
{
    public class TurnLeftExecutionStep : IExecutionStep
    {
        public IDirection GetNextDirection(IDirection direction) => direction.GetTurnLeftNextDirection();

        public Vector GetNextPosition(Vector position, IDirection direction) => position;
    }

    public static partial class ExecutionSteps
    {
        public static IExecutionStep TurnLeft = new TurnLeftExecutionStep();
    }
}
