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

        public GameplayScreen(Game game, LevelManager levelManager)
            : base(game)
        {
            this.gameComponents.Add(levelManager);
        }

        public override void LoadContent()
        {
            LevelManager levelManager = gameComponents[0] as LevelManager;
            levelManager?.Load();
        }
        public override void UnloadContent()
        {
            
        }

        public override void HandleInput()
        {
            LevelManager levelManager = gameComponents[0] as LevelManager;
            levelManager?.HandleInput();
        }
    }
}
