// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SurvivalRPGGame
{
    public class SurvivalRPGGame : Game
    {
        public static GameTime GameTime { get; private set; }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        /// <summary>
        /// The manager for all of the user-interface data.
        /// </summary>
        ScreenManager screenManager;
        LevelManager levelManager;


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
            screenManager = new ScreenManager(this);
            // levelManager = new LevelManager(this);

            // levelManager.Initialize();

            // GameScreen gs = new GameplayScreen(this, levelManager);
            // gs.Initialize();
            // screenManager.push(gs);

            GameScreen MainMenuScreen = new MainMenuScreen(this);
            screenManager.push(MainMenuScreen);


            screenManager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Art.Load(Content);

            screenManager.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
            Input.Update();

            if (Input.WasExitPressed())
                Exit();
            screenManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            screenManager.Draw(gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }

}
