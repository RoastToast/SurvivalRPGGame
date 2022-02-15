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
        GameConfig gameConfig;
        Resolution resolution;


        public SurvivalRPGGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            this.Window.ClientSizeChanged += delegate { Resolution.WasResized = true; };
            this.Window.IsBorderless = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            screenManager = new ScreenManager(this);
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
            GameConfig.Initialize();
            Resolution.Initialize(_graphics);



            GameScreen gameplayScreen = new GameplayScreen(this);
            this.screenManager.push(gameplayScreen);
            GameScreen MainMenuScreen = new MainMenuScreen(this);
            this.screenManager.push(MainMenuScreen);


            this.screenManager.Initialize();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            this._spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Art.Load(Content);

            this.screenManager.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
            Input.Update();

            if (Input.WasExitPressed())
                Exit();

            Resolution.Update(this, _graphics);
            GameConfig.Update();
            this.screenManager.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            this._spriteBatch.Begin();
            this.screenManager.Draw(gameTime);
            this._spriteBatch.End();

            base.Draw(gameTime);
        }
    }

}
