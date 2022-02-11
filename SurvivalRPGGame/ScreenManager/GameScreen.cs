using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    class GameScreen : DrawableGameComponent
    {
        public ScreenState ScreenState;
        public bool IsPopup;


        public GameScreen(Game game)
            : base(game)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void Update(GameTime gameTime, bool screenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void HandleInput(InputState input)
        {

        }
    }
}
