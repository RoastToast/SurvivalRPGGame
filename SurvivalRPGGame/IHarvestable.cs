﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public interface IHarvestable
    {
        public Item Harvest(Tool tool);
    }
}