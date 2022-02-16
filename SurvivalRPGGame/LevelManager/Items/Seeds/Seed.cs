using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public abstract class Seed : Item
    {
        public abstract Crop GetCrop();
    }
}
