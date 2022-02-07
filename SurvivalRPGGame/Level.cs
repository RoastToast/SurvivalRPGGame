using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SurvivalRPGGame
{
    public enum ELevel
    {
        MainIsland = 0
    }

    public abstract class Level
    {
        protected Texture2D LevelTexture;
        protected List<List<Tile>> TileSheet;
        protected List<Entity> Entities;
        protected List<Entity> AddedEntities;

        protected bool isUpdating;

        public Level()
        {
            TileSheet = new List<List<Tile>>();
            Entities = new List<Entity>();
            AddedEntities = new List<Entity>();
            isUpdating = false;
        }

        // Summary
        //     Decide which Action to take based on the active item
        //     
        public void Action(Item item, Vector2 Position)
        {
            if (item.IsTool)
            {
                Entity entity = Entities.Find(x => x.Position == Position);
                IHarvestable harvestable = entity as IHarvestable;
                if (harvestable != null)
                {
                    Item HarvestedItem = _Harvest(item.Tool, harvestable);
                    Player.Instance.AddItemToInventory(HarvestedItem);
                    Entities.Remove(entity);
                }
                    
            }
            else if (item.isSeed)
            {
                if (_PlantCrop(item.SeedCrop, Position))
                {
                    Player.Instance.RemoveItemFromInventory(item);
                }
            }
        }

        // Summary
        //     If there is a crop/Object at the location, and the Tool matches the Crop/Object
        //     Remove the Crop
        // TODO: After player inventory implemented, add item to inventory when tool matches Crop/Object harvested
        //     
        private Item _Harvest(Tool tool, IHarvestable harvestable)
        {
            return(harvestable.Harvest(tool));
        }

        // Summary
        //     If the current tile is empty, plant a crop at the location
        //     
        private bool _PlantCrop(Crop SeedCrop, Vector2 Position)
        {
            bool Success = false;
            Crop c = SeedCrop.GetInstance();
            c.Position = Position;
            Entity Existing = this.Entities.Find(x => x.Position == Position);
            if (Existing == null || Existing.Equals(Player.Instance))
            {
                if (!isUpdating)
                {
                    Debug.Print("Adding {0}!", c.GetType());
                    this.Entities.Add(c);
                    Success = true;
                } else
                {
                    Debug.Print("{0} is updating...", this.GetType());
                    this.AddedEntities.Add(c);
                    Success = true;
                }
            } else {
                Debug.Print("Tile Already Occupied :(");
                Success = false;
            }
            return Success;
        }

        //
        // Summary
        //    Old Planting and Harvesting Code
        //
        //public void AddEntity(Entity e)
        //{
        //    _addEntity(e);
        //}

        //private void _addEntity(Entity e)
        //{
        //    Entity Existing = this.Entities.Find(x => x.Position == e.Position);
        //    if(Existing == null || Existing.Equals(Player.Instance))
        //    {
        //        Debug.Print("Adding Entity!");
        //        this.Entities.Add(e);
        //    } else
        //    {
        //        Debug.Print("Tile Already Occupied :(");
        //    }
        //}

        //public void RemoveEntity(Vector2 Position)
        //{
        //    _removeEntity(Position);
        //}

        //private void _removeEntity(Vector2 Position)
        //{
        //    Entity e = this.Entities.Find(x => x.Position == Position);
        //    if (e != null)
        //    {
        //        this.Entities.Remove(e);
        //    }
        //}

        public void Update()
        {
            // Set isUpdating to true to stop any changes to this level's entities
            this.isUpdating = true;
            UpdateEntities();

            if(AddedEntities.Count != 0)
            {
                while(AddedEntities.Count != 0)
                {
                    Entities.Add(AddedEntities[0]);
                    AddedEntities.RemoveAt(0);
                }
            }

            // Set isUpdating to false at the very end of Update()
            this.isUpdating = false;
            // DO NOT PLACE ANY CODE AFTER THIS
        }

        private void UpdateEntities()
        {
            foreach(Entity e in Entities)
            {
                e?.Update();
            }
        }

        //
        // Summary
        //     Draw this Level
        //
        public void Draw(SpriteBatch spriteBatch)
        {
            DrawTiles(spriteBatch);
            DrawEntities(spriteBatch);
        }

        //
        // Summary
        //     Draw this Level's Tiles
        //
        private void DrawTiles(SpriteBatch spriteBatch)
        {
            float x = 0;
            float y = 0;

            foreach (List<Tile> row in this.TileSheet)
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
        //
        // Summary
        //     Draw this Level's Entities
        //
        private void DrawEntities(SpriteBatch spriteBatch)
        {
            foreach (Entity e in this.Entities)
            {
                e.Draw(spriteBatch);
            }
        }
    }
}