// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class VisualComponent : DrawableGameComponent
    {

        public VisualComponent(Game game)
            : base(game)
        {

        }

        public new virtual void LoadContent() { }
        public new virtual void UnloadContent() { }
    }
}
