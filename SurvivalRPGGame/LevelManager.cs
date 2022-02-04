using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class LevelManager
    {
        private static Level CurrentLevel;

        private static bool isUpdating;

        public LevelManager()
        {

        }

        public static void Load()
        {
            CurrentLevel = new MainIsland();
        }

        public static void Save()
        {

        }

        public static void Update()
        {
            CurrentLevel.Update();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            DrawTiles(spriteBatch);
            DrawEntities(spriteBatch);
        }

        private static void DrawEntities(SpriteBatch spriteBatch)
        {
            foreach(Entity e in CurrentLevel.Entities)
            {
                e.Draw(spriteBatch);
            }
        }

        private static void DrawTiles(SpriteBatch spriteBatch)
        {
            float x = 0;
            float y = 0;

            foreach(List<Tile> row in CurrentLevel.TileSheet)
            {
                foreach(Tile t in row)
                {
                    spriteBatch.Draw(t.Texture, new Vector2(x, y), Color.White);
                    x += Tile.Width;
                }
                x = 0;
                y += Tile.Height;
            }
        }
    }
}