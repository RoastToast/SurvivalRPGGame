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
        public GameplayScreen(Game game)
            : base(game)
        {
            this.ScreenState = ScreenState.Active;
            this.IsPopup = false;
        }

        public override void Initialize()
        {
            LevelManager.Instance.Initialize();
        }


        public override void LoadContent()
        {

        }
        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime, bool screenHasFocus, bool coveredByOtherScreen)
        {
            if (screenHasFocus)
            {
                LevelManager.Instance.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            LevelManager.Instance.Draw(gameTime);
        }

        public override void HandleInput()
        {
            LevelManager.Instance.HandleInput();
        }
    }
}
