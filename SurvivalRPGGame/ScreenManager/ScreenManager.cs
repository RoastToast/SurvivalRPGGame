// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    /// <summary>
    /// The Screen Manager is the component which manages one or more GameScreen instances. 
    /// It maintains a stack of screens, calls their Update and Draw Methods at the 
    /// appropriate times, and automatically routes input to the topmost active screen.
    /// 
    /// Based off ideas from the sample:
    /// https://github.com/CartBlanche/MonoGame-Samples/blob/master/GameStateManagement/Screens/GameplayScreen.cs
    /// by CarteBlanche
    /// </summary>
    class ScreenManager : VisualComponent
    {
        Stack<GameScreen> Screens = new Stack<GameScreen>();
        Stack<GameScreen> ScreensToUpdate = new Stack<GameScreen>();

        bool isInitialized;
        private static SpriteBatch _spriteBatch;
        public static SpriteBatch SpriteBatch
        {
            get => _spriteBatch;
        }

        private SpriteFont _font;
        public SpriteFont SpriteFont
        {
            get => _font;
        }

        private Texture2D _blankTexture;
        public Texture2D BlankTexture
        {
            get => _blankTexture;
        }

        public ScreenManager(Game game)
            : base(game)
        {
            
        }

        public override void Initialize()
        {
            foreach (GameScreen gs in Screens)
            {
                gs.Initialize();
            }

            isInitialized = true;
        }

        /// <summary>
        /// Load your graphics content.
        /// </summary>
        public new void LoadContent()
        {
            // Load content belonging to the screen manager.
            ContentManager content = Game.Content;

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach(GameScreen screen in Screens)
            {
                screen.LoadContent();
            }
        }

        /// <summary>
        /// Update all active screens in the stack. The first active screen handles input.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            bool screenHasFocus = Game.IsActive;
            bool coveredByOtherScreen = false;

            foreach(GameScreen screen in Screens) 
            {
                screen.Update(gameTime, screenHasFocus, coveredByOtherScreen);

                if (screen.ScreenState == ScreenState.TransitionOn ||
                    screen.ScreenState == ScreenState.Active)
                {
                    // If this is the first active screen we came across,
                    // give it a chance to handle input.
                    if (screenHasFocus)
                    {
                        screen.HandleInput();

                        screenHasFocus = false;
                    }

                    // If this is an active non-popup, inform any subsequent
                    // screens that they are covered by it.
                    if (!screen.IsPopup)
                        coveredByOtherScreen = true;
                }
            }
            if(Screens.Peek().ScreenState == ScreenState.DisposeMe)
            {
                Screens.Pop();
            }
        }

        /// <summary>
        /// Draw all visible screens starting at the bottom of the stack.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            foreach(GameScreen gs in Screens)
            {
                gs.Draw(gameTime);
            }
        }

        /// <summary>
        /// Push new screen to the top of the stack
        /// </summary>
        /// <param name="screen"></param>
        public void push(GameScreen screen)
        {
            Screens.Push(screen);
        }

        /// <summary>
        /// Pop the top screen off of the stack
        /// </summary>
        public void pop()
        {
            Screens.Pop();
        }
    }
}
