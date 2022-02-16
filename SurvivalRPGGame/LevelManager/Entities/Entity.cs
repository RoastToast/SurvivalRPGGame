// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public abstract class Entity
    {
        //TODO: Add _texture as Animation. Change Texture.get to return the texture for the current animation in the sequence
        public Texture2D Texture { get; set; }
        // The tint of the image. This will also allow us to change the transparency.
        protected Color _color = Color.White;

        public Vector2 Position { get; set; }
        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }
        }
        // true if the entity was destroyed and should be deleted.
        public bool isExpired { get; set; }


        public Vector2 GetTile()
        {
            return MathUtil.GetTile(this.Position, Tile.Width, Tile.Height);
        }

        public abstract void Update();
    }
}