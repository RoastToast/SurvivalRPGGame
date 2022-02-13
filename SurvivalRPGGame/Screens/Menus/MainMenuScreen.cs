using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    /// <summary>
    /// The main menu when the game is first started, used to create new games, load saved games, and configure options
    /// </summary>
    class MainMenuScreen : MenuScreen
    {

        public MainMenuScreen(Game game)
            : base(game)
        {
            this.gameComponents.Add(new MenuComponent(game, new string[] { "New Game", "Load Game", "Options" }));
        }




    }
}
