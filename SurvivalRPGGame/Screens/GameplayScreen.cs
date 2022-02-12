using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
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

        public override void HandleInput()
        {
            LevelManager levelManager = gameComponents[0] as LevelManager;
            levelManager?.HandleInput();
        }
    }
}
