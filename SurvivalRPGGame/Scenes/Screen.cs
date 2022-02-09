// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{

    /// <summary>
    /// This is a screen that can be added to the ScreenManager. Extend it and add components 
    /// to it in the Initialize() method. You can also override the Update() and Draw() method.
    /// </summary>
    public class Screen : DrawableGameComponent
    {
        /// <summary>
        /// This member tells if this screen is initialized.
        /// </summary>
        public bool Initialized { get; private set; }

        /// <summary>
        /// Set this member to true if this screen doesn't cover the entire screen.
        /// </summary>
        public bool Translucent { get; set; }

        /// <summary>
        /// A reference to the ScreenManager.
        /// </summary>
        public ScreenManager Manager { get; internal set; }

        /// <summary>
        /// The GameComponentCollection, add components for this screen.
        /// </summary>
        public GameComponentCollection Components { get; private set; }

        public Screen(Game game)
            : base(game)
        {
            this.Components = new GameComponentCollection();
            Translucent = false;
        }

        public override void Initialize()
        {
            foreach (GameComponent gc in this.Components)
                gc.Initialize();
            Initialized = true;
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent gc in this.Components)
                if (gc.Enabled)
                    gc.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (GameComponent gc in this.Components)
                if (gc is IDrawable && (gc as IDrawable).Visible)
                    (gc as IDrawable).Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
