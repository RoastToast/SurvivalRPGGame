// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    /// <summary>
    /// Main Game Logic Class
    /// LevelManager handles all game logic, including tracking and updating all levels
    /// </summary>
    public class LevelManager : GameComponent
    {
        private static Level CurrentLevel;
        private static Dictionary<KeyFunctions, Keys> ConfiguredKeys = new Dictionary<KeyFunctions, Keys>();

        public LevelManager(Game game)
            : base(game)
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        // TODO: Load Levels from Save File
        public void Load()
        {
            CurrentLevel = new MainIsland(Game);

            Item[] items = new Item[]{new Item(false, null, true, new Potato()), new Item(true, null, false, null)};
            foreach(Item i in items)
                Inventory.Instance.AddItemToInventory(i);

            ConfiguredKeys.Add(KeyFunctions.PauseMenu, Keys.Escape);
            ConfiguredKeys.Add(KeyFunctions.Inventory, Keys.Tab);
            ConfiguredKeys.Add(KeyFunctions.Action, Keys.E);
            ConfiguredKeys.Add(KeyFunctions.Action2, Keys.F);
            ConfiguredKeys.Add(KeyFunctions.ChangeTool, Keys.R);
        }

        // TODO: Save Levels to File
        public void Save()
        {

        }

        public override void Update(GameTime gameTime)
        {
            CheckKeyPresses();
            CurrentLevel.Update();
        }

        //
        // Summary:
        //     Check predefined keys and call logic for those keys
        //
        private void CheckKeyPresses()
        {
            if (Input.WasKeyPressed(ConfiguredKeys[KeyFunctions.Action]))
            {
                CurrentLevel.Action(Player.Instance.GetActiveItem(), Player.Instance.GetTile());
            } 
            //else if (Input.WasKeyPressed(ConfiguredKeys[KeyFunctions.Action2]))
            //{
            //
            //    CurrentLevel.Action(new Item(true, null, false, null), Player.Instance.GetTile());
            //} 
            else if (Input.WasKeyPressed(ConfiguredKeys[KeyFunctions.ChangeTool]))
            {
                Player.Instance.ShiftActiveItem();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentLevel.Draw(spriteBatch);
        }
    }
}