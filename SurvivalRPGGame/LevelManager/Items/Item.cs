// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{

    //TODO: Find a way to plant seeds, harvest crops, get produce
    //  Seed -> Crop -> Produce
    public abstract class Item
    {
        public int Count { get; set; } = 1;
        public Texture2D Texture;
        // The tint of the image. This will also allow us to change the transparency.
        protected Color _color = Color.White;
    }
}