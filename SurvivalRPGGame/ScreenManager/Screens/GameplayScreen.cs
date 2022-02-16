// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    /// <summary>
    /// The main GamePlay screen. Draws the level and all of the fun parts of a game
    /// </summary>
    class GameplayScreen : GameScreen
    {
        Camera camera;
        HUDComponent HUD;
        public GameplayScreen(Game game)
            : base(game)
        {
            this.ScreenState = ScreenState.Active;
            this.IsPopup = false;
            camera = new Camera();
            HUD = new HUDComponent(game);
        }

        public override void Initialize()
        {
            LevelManager.Instance.Initialize();
            HUD.Initialize();
        }


        public override void LoadContent()
        {
            HUD.LoadContent();
        }
        public override void UnloadContent()
        {
            HUD.UnloadContent();
        }

        public override void Update(GameTime gameTime, bool screenHasFocus, bool coveredByOtherScreen)
        {
            if (screenHasFocus)
            {
                LevelManager.Instance.Update(gameTime);
                camera.Follow(Player.Instance);
                HUD.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (LevelManager.Instance.Running)
            {
                ScreenManager.SpriteBatch.Begin(transformMatrix: camera.Transform);
                LevelManager.Instance.Draw(gameTime);
                ScreenManager.SpriteBatch.End();
                ScreenManager.SpriteBatch.Begin(transformMatrix: Resolution.ScaleMatrix);
                HUD.Draw(gameTime);
                ScreenManager.SpriteBatch.End();
            }
        }

        public override void HandleInput()
        {
            LevelManager.Instance.HandleInput();
        }
    }
}
