// © 2022 David Alger <RoastToast-gh@protonmail.com>
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public abstract class Enemy : Entity, IHarvestable
    {
        public abstract Enemy GetInstance();
        public abstract Item Harvest(Tool tool);
    }
}