// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class GameConfig
    {
        private static int _lastWindowWidth;
        public static int DefaultWindowWidth;
        private static int _lastWindowHeight;
        public static int DefaultWindowHeight;

        public GameConfig()
        {

        }

        public static void Initialize()
        {
            DefaultWindowWidth = 1920;
            DefaultWindowHeight = 1080;
        }

        public static void Update()
        {

        }
    }
}
