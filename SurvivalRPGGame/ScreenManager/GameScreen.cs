﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public abstract class GameScreen : DrawableGameComponent
    {
        public ScreenState ScreenState;
        public bool IsPopup;

        protected GameComponentCollection gameComponents = new GameComponentCollection();

        public GameScreen(Game game)
            : base(game)
        {

        }

        public override void Initialize()
        {

            foreach (GameComponent gc in gameComponents)
            {
                gc.Initialize();
            }
        }

        public new virtual void LoadContent() { }

        public new virtual void UnloadContent() { }

        public void Update(GameTime gameTime, bool screenHasFocus, bool coveredByOtherScreen)
        {
            foreach (GameComponent gc in gameComponents)
            {
                gc.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (GameComponent gc in gameComponents)
            {
                DrawableGameComponent dgc = gc as DrawableGameComponent;
                dgc?.Draw(gameTime);
            }
        }

        public abstract void HandleInput();
    }
}