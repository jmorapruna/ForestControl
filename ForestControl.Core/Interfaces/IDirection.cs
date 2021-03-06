﻿using ForestControl.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestControl.Core
{
    public interface IDirection
    {
        char GetCode();
        IDirection GetTurnLeftNextDirection();
        IDirection GetTurnRightNextDirection();
        Vector GetPositionDeltaForAForwardStep();
    }
}
