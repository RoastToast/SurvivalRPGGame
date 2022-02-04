﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SurvivalRPGGame
{
    public class SurvivalRPGGame : Game
    {
        public static GameTime GameTime { get; private set; }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public SurvivalRPGGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        // Window is in focus
        protected override void OnActivated(object sender, System.
                                            EventArgs args)
        {
            this.Window.Title = "Active Application";
            base.OnActivated(sender, args);
        }

        // Window is out of focus
        protected override void OnDeactivated(object sender, System.
                                              EventArgs args)
        {
            this.Window.Title = "InActive Application";
            base.OnActivated(sender, args);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            LevelManager.Load();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Art.Load(Content);
        }

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
            Input.Update();
            LevelManager.Update();

            if (Input.WasExitPressed())
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            LevelManager.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}