using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public struct Item
    {
        public bool isTool;
        public Tool Tool;
        public bool isSeed;
        public Crop SeedCrop;

        public Item(bool isTool, Tool Tool, bool isSeed, Crop SeedCrop)
        {
            this.isTool = isTool;
            this.Tool = Tool;
            this.isSeed = isSeed;
            this.SeedCrop = SeedCrop;
        }
    }
}