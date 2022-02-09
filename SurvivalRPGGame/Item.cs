// © 2022 David Alger <RoastToast-gh@protonmail.com>
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{

    //TODO: Find a way to plant seeds, harvest crops, get produce
    //  Seed -> Crop -> Produce
    public struct Item
    {
        public readonly bool IsTool;
        public readonly Tool Tool;
        public readonly bool isSeed;
        public readonly Crop SeedCrop;
        private int _count;
        public int Count
        {
            readonly get => _count;
            set => _count = value;
        }

        public Item(bool isTool, Tool Tool, bool isSeed, Crop SeedCrop, int Count)
        {
            this.IsTool = isTool;
            this.Tool = Tool;
            this.isSeed = isSeed;
            this.SeedCrop = SeedCrop;
            this._count = Count;
        }
        public Item(bool isTool, Tool Tool, bool isSeed, Crop SeedCrop)
        {
            this.IsTool = isTool;
            this.Tool = Tool;
            this.isSeed = isSeed;
            this.SeedCrop = SeedCrop;
            this._count = 1;
        }
    }
}