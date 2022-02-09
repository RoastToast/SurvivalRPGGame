// © 2022 David Alger <RoastToast-gh@protonmail.com>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SurvivalRPGGame
{
    class Inventory
    {
        private static Inventory _instance;
        public static Inventory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Inventory();

                return _instance;
            }
        }

        // TODO: Add Inventory System
        public List<Item> Hotbar;
        private int _activeItem;
        public int ActiveItem
        {
            get => _activeItem;
        }
        private int _inventorySize;

        public Inventory()
        {
            _inventorySize = 10;
            this.Hotbar = new List<Item>();
            for(int i = 0; i < _inventorySize; i++)
            {
                this.Hotbar.Add(new Item());
            }
        }

        // Summary:
        //     This is sample Description Text
        public Item GetActiveItem()
        {
            return this.Hotbar[ActiveItem];
        }

        public void ShiftActiveItem()
        {
            if (this.ActiveItem < this.Hotbar.Count - 1)
            {
                this._activeItem++;
            }
            else if (this.ActiveItem == this.Hotbar.Count - 1)
            {
                this._activeItem = 0;
            }
            else
            {
                Debug.Print("Active Item out of bounds! {0}", this.ActiveItem);
                this._activeItem = 0;
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
                }
                else
                {
                    index = this.Hotbar.FindIndex(x => x.Equals(new Item()));
                    if (index >= 0)
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
    }
}
