﻿using System;

namespace ForestControl.Core
{
    class SouthDirection : IDirection
    {
    }

    public static partial class Directions
    {
        public static IDirection South = new SouthDirection();
    }
}