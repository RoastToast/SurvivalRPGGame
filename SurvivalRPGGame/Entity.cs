using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public abstract class Entity
    {
        protected Texture2D _texture;
        // The tint of the image. This will also allow us to change the transparency.
        protected Color _color = Color.White;

        public Vector2 Position { get; set; }
        // true if the entity was destroyed and should be deleted.
        public bool isExpired { get; set; }



        public abstract void Update();

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, _color);
        }
    }
}