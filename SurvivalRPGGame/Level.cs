using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public enum ELevel
    {
        MainIsland = 0
    }

    public abstract class Level
    {
        public List<List<Tile>> TileSheet;
        public List<Entity> Entities;

        public Level()
        {
            TileSheet = new List<List<Tile>>();
            Entities = new List<Entity>();
        }
        public void Update()
        {
            UpdateEntities();
        }

        private void UpdateEntities()
        {
            foreach(Entity e in Entities)
            {
                e?.Update();
            }
        }
    }
}