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
    public class LevelManager
    {
        /// <summary>
        /// The level the player is currently in
        /// </summary>
        private Level CurrentLevel;

        /// <summary>
        /// Maps keys from MonoGame Keys to this Game's Functional Keys
        /// </summary>
        private Dictionary<KeyFunctions, Keys> ConfiguredKeys = new Dictionary<KeyFunctions, Keys>();

        private static LevelManager instance;
        public static LevelManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new LevelManager();

                return instance;
            }
        }

        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;

        /// <summary>
        /// If true, the configuration file has been loaded
        /// </summary>
        private bool _isInitialized;
        /// <summary>
        /// Controls Update Logic, if true the CurrentLevel will update
        /// </summary>
        public bool Running { get; set; }
        /// <summary>
        /// Controls Draw Logic
        /// </summary>
        private bool _active;

        public LevelManager()
        {
            this._active = false;
            this.Running = false;
        }

        /// <summary>
        /// Initialized the class with values from configuration file
        /// </summary>
        public void Initialize()
        {
            _isInitialized = true;
        }

        /// <summary>
        /// Prevents the Update() logic from running
        /// </summary>
        public void Pause()
        {
            this.Running = false;
        }

        /// <summary>
        /// Allows the Update() logic to run
        /// </summary>
        public void Resume()
        {
            this.Running = true;
        }

        /// <summary>
        /// Save Levels to a save file
        /// </summary>
        public void Load(int SaveSlot)
        {
            CurrentLevel = new MainIsland();

            Item[] items = new Item[]{new PotatoSeed(), new Hatchet()};
            foreach(Item i in items)
                Player.Instance.AddItemToInventory(i);

            ConfiguredKeys.Add(KeyFunctions.PauseMenu, Keys.Escape);
            ConfiguredKeys.Add(KeyFunctions.Inventory, Keys.Tab);
            ConfiguredKeys.Add(KeyFunctions.Action, Keys.E);
            ConfiguredKeys.Add(KeyFunctions.Action2, Keys.F);
            ConfiguredKeys.Add(KeyFunctions.ChangeTool, Keys.R);

            this.Running = true;
            this._active = true;
        }

        /// <summary>
        /// Save Levels to a save file
        /// </summary>
        public void Save(int SaveSlot)
        {
            this.Running = false;
            this._active = false;
        }

        /// <summary>
        /// Updates the Current Level
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (Running)
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
        public void Draw(GameTime gameTime)
        {
            if (_active)
            {
                CurrentLevel.Draw(gameTime);
            }
        }
    }
}