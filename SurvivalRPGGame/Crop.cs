using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public abstract class Crop : Entity, IHarvestable
    {
        public abstract Crop GetInstance();
        public abstract Item Harvest(Tool tool);
    }
}