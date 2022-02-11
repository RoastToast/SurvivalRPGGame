// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class MainIsland : Level
    {
        public MainIsland(Game game)
            : base(game)
        {
            TileSheet = new List<List<Tile>>();
            for (int i = 0; i < 20; i++)
            {
                TileSheet.Add(new List<Tile>());
                for (int a = 0; a < 30; a++)
                {
                    TileSheet[i].Add(new Tile(Art.Tile, 0));
                }
            }

            Entities = new List<Entity>();
            Entities.Add(Player.Instance);
            Entities.Add(new Potato(new Vector2(5 * 32, 1 * 32)));
            Entities.Add(new Potato(new Vector2(20 * 32, 5 * 32)));
            Entities.Add(new Potato(new Vector2(11 * 32, 9 * 32)));
            Entities.Add(new Potato(new Vector2(2 * 32, 8 * 32)));
            Entities.Add(new Potato(new Vector2(23 * 32, 13 * 32)));

        }

    }
}