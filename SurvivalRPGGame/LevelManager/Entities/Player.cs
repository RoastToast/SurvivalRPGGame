// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SurvivalRPGGame
{
    public class Player : Entity
    {
        private static Player instance;
        /// <summary>
        /// Gets an instance of the player or creates a new one if none exists
        /// </summary>
        public static Player Instance
        {
            get
            {
                if (instance == null)
                    instance = new Player();

                return instance;
            }
        }

        /// <summary>
        /// Speed Coefficient
        /// </summary>
        public float Speed = 10f;
        /// <summary>
        /// The Player's inventory
        /// </summary>
        Inventory inventory;

        private Player()
        {
            this.Texture = Art.Player;

            this.Position = new Vector2(0, 0);
            this.inventory = new Inventory();
        }

        public List<Item> GetHotbar()
        {
            return inventory.Hotbar;
        }

        /// <summary>
        /// Get the player's active item in the hotbar
        /// </summary>
        /// <returns></returns>
        public Item GetActiveItem()
        {
            return this.inventory.GetActiveItem();
        }

        /// <summary>
        /// Change the player's active item in the hotbar
        /// </summary>
        public void ShiftActiveItem()
        {
            this.inventory.ShiftActiveItem();
        }

        /// <summary>
        /// Add an item to the player's inventory
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToInventory(Item item)
        {
            this.inventory.AddItemToInventory(item);
        }

        /// <summary>
        /// Remove an item from the player's inventory
        /// </summary>
        /// <param name="item"></param>
        /// <param name="count"></param>
        public void RemoveItemFromInventory(Item item, int count = 1)
        {
            this.inventory.RemoveItemFromInventory(item, count);
        }

        /// <summary>
        /// Update the player
        /// </summary>
        public override void Update()
        {
            float x = 0f;
            float y = 0f;
            float angle = 0f;
            float a = 0f;


            Vector2 direction = Input.GetMovementDirection();

            if (direction.X != 0 || direction.Y != 0)
            {
                angle = MathUtil.DirectionToAngle(direction);
                a = (MathF.PI / 180) * angle;

                // Pythagorean Theorum:
                //      A*2 + B*2 = C*2
                x = this.Position.X + (MathF.Cos(a) * this.Speed);
                y = this.Position.Y + (MathF.Sin(a) * this.Speed);


                Position = new Vector2(x, y);
            }
        }
    }
}