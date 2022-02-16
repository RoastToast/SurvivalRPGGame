// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class Art
    {
        public static SpriteFont MenuFont { get; private set; }
        public static Texture2D Player { get; private set; }
        public static Texture2D Crop { get; private set; }
        public static Texture2D Tile { get; private set; }
        public static Texture2D Potato { get; private set; }
        public static Texture2D Hatchet { get; private set; }
        public static Texture2D Hotbar { get; private set; }
        public static Texture2D ActiveHotbar { get; private set; }

        public static void Load(ContentManager content)
        {
            MenuFont = content.Load<SpriteFont>("MenuFont");
            Player = content.Load<Texture2D>("Player");
            Crop = content.Load<Texture2D>("Crop");
            Tile = content.Load<Texture2D>("Tile");
            Potato = content.Load<Texture2D>("Potato");
            Hatchet = content.Load<Texture2D>("Hatchet_Stone");
            Hotbar = content.Load<Texture2D>("Hotbar");
            ActiveHotbar = content.Load<Texture2D>("ActiveHotbar");
        }

    }
}