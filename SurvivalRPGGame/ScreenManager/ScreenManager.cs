using Microsoft.Xna.Framework;
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
    class ScreenManager : DrawableGameComponent
    {
        Stack<GameScreen> Screens = new Stack<GameScreen>();
        Stack<GameScreen> ScreensToUpdate = new Stack<GameScreen>();

        InputState input = new InputState();

        bool isInitialized;

        public ScreenManager(Game game)
            : base(game)
        {

        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (GameScreen gs in Screens)
            {
                gs.Initialize();
            }

            isInitialized = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Make a copy of the master screen list, to avoid confusion if
            // the process of updating one screen adds or removes others.
            ScreensToUpdate.Clear();

            foreach (GameScreen gs in Screens)
            {
                ScreensToUpdate.Push(gs);
            }

            bool screenHasFocus = Game.IsActive;
            bool coveredByOtherScreen = false;

            while (ScreensToUpdate.Count > 0)
            {
                GameScreen screen = ScreensToUpdate.Pop();

                screen.Update(gameTime, screenHasFocus, coveredByOtherScreen);

                if (screen.ScreenState == ScreenState.TransitionOn ||
                    screen.ScreenState == ScreenState.Active)
                {
                    // If this is the first active screen we came across,
                    // give it a chance to handle input.
                    if (screenHasFocus)
                    {
                        screen.HandleInput(input);

                        screenHasFocus = false;
                    }

                    // If this is an active non-popup, inform any subsequent
                    // screens that they are covered by it.
                    if (!screen.IsPopup)
                        coveredByOtherScreen = true;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void push(GameScreen screen)
        {
            Screens.Push(screen);
        }

        public void pop()
        {
            Screens.Pop();
        }
    }
}
