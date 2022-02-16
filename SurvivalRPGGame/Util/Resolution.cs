// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class Resolution
    {
        public static Matrix ScaleMatrix { get; set; }

        public static Vector2 Scale { get; set; }

        public static int GameWidth { get; set; }
        public static int GameHeight { get; set; }
        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }
        public static bool WasResized { get; set; }
        private static int PreviousWindowWidth;
        private static int PreviousWindowHeight;

        public static void Initialize(GraphicsDeviceManager graphics)
        {
            ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            GameWidth = 1280;
            GameHeight = 720;
            graphics.PreferredBackBufferWidth = GameConfig.DefaultWindowWidth;
            graphics.PreferredBackBufferHeight = GameConfig.DefaultWindowHeight;
            PreviousWindowWidth = graphics.PreferredBackBufferWidth;
            PreviousWindowHeight = graphics.PreferredBackBufferHeight;
            WasResized = false;
            CalculateMatrix(graphics);
            graphics.ApplyChanges();
        }


        public static void Update(Game game, GraphicsDeviceManager graphics)
        {
            if (WasResized)
            {
                if (graphics.PreferredBackBufferWidth < Resolution.GameWidth / 4)
                {
                    if (graphics.PreferredBackBufferWidth == 0) graphics.PreferredBackBufferWidth = PreviousWindowWidth;
                    else graphics.PreferredBackBufferWidth = Resolution.GameWidth / 4;
                }
                if (graphics.PreferredBackBufferHeight < Resolution.GameHeight / 4)
                {
                    if (graphics.PreferredBackBufferHeight == 0) graphics.PreferredBackBufferHeight = PreviousWindowHeight;
                    else graphics.PreferredBackBufferHeight = Resolution.GameHeight / 4;
                }
                graphics.ApplyChanges();
                CalculateMatrix(graphics);
                PreviousWindowWidth = graphics.PreferredBackBufferWidth;
                PreviousWindowHeight = graphics.PreferredBackBufferHeight;
                WasResized = false;
            }
        }


        static void CalculateMatrix(GraphicsDeviceManager graphics)
        {
            ScaleMatrix = Matrix.CreateScale((float)graphics.PreferredBackBufferWidth / GameWidth, (float)graphics.PreferredBackBufferHeight / GameHeight, 1f);
            Scale = new Vector2(ScaleMatrix.M11, ScaleMatrix.M22);
        }
    }
}
