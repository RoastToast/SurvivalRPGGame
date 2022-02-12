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
        public static Player Instance
        {
            get
            {
                if (instance == null)
                    instance = new Player();

                return instance;
            }
        }

        // Speed of movement
        public float Speed = 10f;
        Inventory inventory;

        private Player()
        {
            this._texture = Art.Player;

            this.Position = new Vector2(0, 0);
            this.inventory = Inventory.Instance;
        }

        public Item GetActiveItem()
        {
            return this.inventory.GetActiveItem();
        }

        public void ShiftActiveItem()
        {
            this.inventory.ShiftActiveItem();
        }

        public void AddItemToInventory(Item item)
        {
            this.inventory.AddItemToInventory(item);
        }

        public void RemoveItemFromInventory(Item item, int count = 1)
        {
            this.inventory.RemoveItemFromInventory(item, count);
        }

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