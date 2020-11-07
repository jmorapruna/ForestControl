using ForestControl.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core
{
    public interface IExecutionStep
    {
        IDirection GetNextDirection(IDirection direction);
        Vector GetNextPosition(Vector position, IDirection direction);
    }
}
