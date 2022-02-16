// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class Potato : Crop
    {
        public override Crop GetInstance()
        {
            return new Potato();
        }

        public Potato()
        {
            this.Texture = Art.Potato;
        }
        public Potato(Vector2 Position)
        {
            this.Texture = Art.Potato;

            this.Position = Position;
        }
        public override Item Harvest(Tool tool)
        {
            return new PotatoSeed();
        }

        public override void Update()
        {
            
        }
    }
}