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
    class MainMenuScreen : GameScreen
    {

        public MainMenuScreen(Game game)
            : base(game)
        {
            this.gameComponents.Add(new MenuComponent(game, new string[] { "New Game", "Load Game", "Options" }));
        }

        public override void LoadContent()
        {
            foreach (GameComponent gc in gameComponents)
            {
                VisualComponent vc = gc as VisualComponent;
                vc?.LoadContent();
            }
        }

        public override void UnloadContent()
        {
            foreach (GameComponent gc in gameComponents)
            {
                VisualComponent vc = gc as VisualComponent;
                vc?.UnloadContent();
            }
        }

        public override void HandleInput()
        {
            string Selection = String.Empty;
            foreach(GameComponent gc in gameComponents)
            {
                MenuComponent menu = gc as MenuComponent;
                Selection = menu?.HandleInput();
                switch(Selection)
                {
                    case "New Game":
                        LevelManager.Instance.Load(1);
                        this.ScreenState = ScreenState.DisposeMe;
                        break;

                    case "Load Game":
                        LevelManager.Instance.Load(1);
                        break;
                    case "Options":
                        this.OptionsMenu();
                        break;

                    default:
                        break;
                }
            }
        }

        private void OptionsMenu()
        {

        }




    }
}
