using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    /// <summary>
    /// This screen contains one or more MenuComponents, with only one being active at a time (active = updates + draws)
    /// This screen also contains other visual aspects that change through inheritance for it's children
    /// </summary>
    class MenuScreen : GameScreen
    {
        public MenuScreen(Game game)
            : base(game)
        {
            
        }

        public override void LoadContent()
        {
            foreach(GameComponent gc in gameComponents)
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
            
        }
    }
}
