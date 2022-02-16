using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    class PotatoSeed : Seed
    {
        public PotatoSeed()
        {
            this.Texture = Art.Potato;
        }
        public override Crop GetCrop()
        {
            return new Potato();
        }
    }
}
