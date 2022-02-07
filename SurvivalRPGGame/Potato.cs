using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class Potato : Crop
    {
        public override Crop Instance()
        {
            return new Potato();
        }

        public Potato()
        {
            this._texture = Art.Potato;
        }
        public Potato(Vector2 Position)
        {
            this._texture = Art.Potato;

            this.Position = Position;
        }
        public override void Update()
        {
            
        }
    }
}