using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class MainIsland : Level
    {
        public MainIsland()
        {
            TileSheet = new List<List<Tile>>();
            for (int i = 0; i < 20; i++)
            {
                TileSheet.Add(new List<Tile>());
                for (int a = 0; a < 30; a++) {
                    TileSheet[i].Add(new Tile(Art.Tile, 0));
                }
            }

            Entities = new List<Entity>();
            Entities.Add(Player.Instance);
        }

    }
}