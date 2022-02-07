using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class LevelManager
    {
        private static Level CurrentLevel;
        private static Dictionary<KeyFunctions, Keys> ConfiguredKeys = new Dictionary<KeyFunctions, Keys>();

        public LevelManager()
        {

        }

        // TODO: Load Levels from Save File
        public static void Load()
        {
            CurrentLevel = new MainIsland();
            ConfiguredKeys.Add(KeyFunctions.PauseMenu, Keys.Escape);
            ConfiguredKeys.Add(KeyFunctions.Inventory, Keys.Tab);
            ConfiguredKeys.Add(KeyFunctions.Action, Keys.E);
            ConfiguredKeys.Add(KeyFunctions.Action2, Keys.F);
        }

        // TODO: Save Levels to File
        public static void Save()
        {

        }

        public static void Update()
        {
            CheckKeyPresses();
            CurrentLevel.Update();
        }

        //
        // Summary:
        //     Check predefined keys and call logic for those keys
        //
        private static void CheckKeyPresses()
        {
            if (Input.WasKeyPressed(ConfiguredKeys[KeyFunctions.Action]))
            {
                CurrentLevel.Action(new Item(false, null, true, new Potato()), Player.Instance.GetTile());
            } else if (Input.WasKeyPressed(ConfiguredKeys[KeyFunctions.Action2]))
            {

                CurrentLevel.Action(new Item(true, null, false, null), Player.Instance.GetTile());
            }

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            CurrentLevel.Draw(spriteBatch);
        }
    }
}