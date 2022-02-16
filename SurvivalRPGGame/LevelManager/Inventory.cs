// © 2022 David Alger <RoastToast-gh@protonmail.com>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SurvivalRPGGame
{
    class Inventory
    {
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
            for (int i = 0; i < _inventorySize; i++)
            {
                this.Hotbar.Add(new Empty());
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
            int index = -1;

            if (item is Seed)
            {
                index = this.Hotbar.FindIndex(x => x.GetType() == item.GetType());
                if (index >= 0)
                {
                    item.Count += this.Hotbar[index].Count;
                    this.Hotbar[index] = item;
                }
                else
                {
                    index = this.Hotbar.FindIndex(x => x.GetType() == new Empty().GetType());
                    if (index >= 0)
                    {
                        this.Hotbar[index] = item;
                    }
                }
            }
            else if (item is Tool)
            {
                index = this.Hotbar.FindIndex(x => x.GetType() == new Empty().GetType());
                if (index >= 0)
                {
                    this.Hotbar[index] = item;
                }
            }
        }

        public void RemoveItemFromInventory(Item item, int count = 1)
        {
            int index = this.Hotbar.FindIndex(x => x.GetType() == item.GetType());
            if (index >= 0)
            {
                Item tempItem = this.Hotbar[index];
                tempItem.Count = tempItem.Count - 1;
                this.Hotbar[index] = tempItem;
                Debug.Print("{0}", this.Hotbar[index].Count);
                if (this.Hotbar[index].Count == 0)
                    this.Hotbar[index] = new Empty();
            }
        }
    }
}
