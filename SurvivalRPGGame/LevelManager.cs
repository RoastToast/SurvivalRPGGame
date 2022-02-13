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
    public class LevelManager : VisualComponent
    {
        /// <summary>
        /// The level the player is currently in
        /// </summary>
        private static Level CurrentLevel;

        /// <summary>
        /// Maps keys from MonoGame Keys to this Game's Functional Keys
        /// </summary>
        private static Dictionary<KeyFunctions, Keys> ConfiguredKeys = new Dictionary<KeyFunctions, Keys>();

        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        /// <summary>
        /// If true, the configuration file has been loaded
        /// </summary>
        bool _isInitialized;
        /// <summary>
        /// Controls Update Logic, if true the CurrentLevel will update
        /// </summary>
        bool _running;

        public LevelManager(Game game,
            SpriteBatch spriteBatch,
            SpriteFont spriteFont)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
        }

        /// <summary>
        /// Initialized the class with values from configuration file
        /// </summary>
        public override void Initialize()
        {
            _running = true;
            _isInitialized = true;
        }

        /// <summary>
        /// Prevents the Update() logic from running
        /// </summary>
        public void Pause()
        {
            this._running = false;
        }

        /// <summary>
        /// Allows the Update() logic to run
        /// </summary>
        public void Resume()
        {
            this._running = true;
        }

        /// <summary>
        /// Save Levels to a save file
        /// </summary>
        public void Load()
        {
            CurrentLevel = new MainIsland();

            Item[] items = new Item[]{new Item(false, null, true, new Potato()), new Item(true, null, false, null)};
            foreach(Item i in items)
                Inventory.Instance.AddItemToInventory(i);

            ConfiguredKeys.Add(KeyFunctions.PauseMenu, Keys.Escape);
            ConfiguredKeys.Add(KeyFunctions.Inventory, Keys.Tab);
            ConfiguredKeys.Add(KeyFunctions.Action, Keys.E);
            ConfiguredKeys.Add(KeyFunctions.Action2, Keys.F);
            ConfiguredKeys.Add(KeyFunctions.ChangeTool, Keys.R);
        }

        /// <summary>
        /// Save Levels to a save file
        /// </summary>
        public void Save()
        {

        }

        /// <summary>
        /// Updates the Current Level
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (_running)
            {
                CurrentLevel.Update(gameTime);
            }
        }

        /// <summary>
        /// Check configured keys and call corrosponding methods
        /// </summary>
        public void HandleInput()
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

        /// <summary>
        /// Draws the Current Level
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            CurrentLevel.Draw(gameTime);
        }
    }
}