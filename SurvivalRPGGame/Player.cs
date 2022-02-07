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

        // TODO: Add Inventory System
        public List<Item> Hotbar;
        public int ActiveItem;


        private Player()
        {
            this._texture = Art.Player;

            this.Position = new Vector2(0, 0);
            this.Hotbar = new List<Item>();
            this.Hotbar.Add(new Item(true, null, false, null));
            this.Hotbar.Add(new Item(false, null, true, new Potato(), 10));

            this.ActiveItem = 0;
        }

        public Item GetActiveItem()
        {
            return this.Hotbar[ActiveItem];
        }

        public void ShiftActiveItem()
        {
            if(this.ActiveItem < this.Hotbar.Count-1)
            {
                this.ActiveItem++;
            } else if(this.ActiveItem == this.Hotbar.Count-1)
            {
                this.ActiveItem = 0;
            } else
            {
                Debug.Print("Active Item out of bounds! {0}", this.ActiveItem);
                this.ActiveItem = 0;
            }
        }

        public void AddItemToInventory(Item item)
        {
            int index = 0;

            if (item.isSeed)
            {
                index = this.Hotbar.FindIndex(x => x.SeedCrop?.GetType() == item.SeedCrop.GetType());
                if (index >= 0)
                {
                    item.Count += this.Hotbar[index].Count;
                    this.Hotbar[index] = item;
                } else
                {
                    index = this.Hotbar.FindIndex(x => x.Equals(new Item()));
                    if(index >= 0)
                    {
                        this.Hotbar[index] = item;
                    }
                }
            }
            else if (item.IsTool)
            {
                index = this.Hotbar.FindIndex(x => x.Equals(new Item()));
                if (index >= 0)
                {
                    this.Hotbar[index] = item;
                }
            }

            Debug.Print("{0}", this.Hotbar[index].Count);
        }

        public void RemoveItemFromInventory(Item item, int count = 1)
        {
            int index = this.Hotbar.FindIndex(x => x.SeedCrop?.GetType() == item.SeedCrop.GetType());
            if (index >= 0)
            {
                Item tempItem = this.Hotbar[index];
                tempItem.Count = tempItem.Count - 1;
                this.Hotbar[index] = tempItem;
                Debug.Print("{0}", this.Hotbar[index].Count);
                if (this.Hotbar[index].Count == 0)
                    this.Hotbar[index] = new Item();
            }
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