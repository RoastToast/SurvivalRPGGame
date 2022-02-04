using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class Art
    {
        public static Texture2D Player { get; private set; }
        public static Texture2D Crop { get; private set; }
        public static Texture2D Tile { get; private set; }

        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("Player");
            Crop = content.Load<Texture2D>("Crop");
            Tile = content.Load<Texture2D>("Tile");
        }

    }
}