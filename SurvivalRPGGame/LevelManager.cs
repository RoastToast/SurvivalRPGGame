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
        private static List<Entity> AddedEntities = new List<Entity>();

        private static bool isUpdating = false;

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
                Entity e = new Potato(Player.Instance.Position);
                if (!isUpdating)
                {
                    CurrentLevel.AddEntity(e);
                } else
                {
                    AddedEntities.Add(e);
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            DrawTiles(spriteBatch);
            DrawEntities(spriteBatch);
        }

        private static void DrawTiles(SpriteBatch spriteBatch)
        {
            float x = 0;
            float y = 0;

            foreach (List<Tile> row in CurrentLevel.TileSheet)
            {
                foreach (Tile t in row)
                {
                    spriteBatch.Draw(t.Texture, new Vector2(x, y), Color.White);
                    x += Tile.Width;
                }
                x = 0;
                y += Tile.Height;
            }
        }
        private static void DrawEntities(SpriteBatch spriteBatch)
        {
            foreach(Entity e in CurrentLevel.Entities)
            {
                e.Draw(spriteBatch);
            }
        }
    }
}