using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace StrategyGame
{
    public class Base
    {
        public double HP { get; set; }

        public int PlayerID { get; set; }

        public double PosX { get; set; }

        public double PosY { get; set; }

        public double Armor { get; set; }

        public Base(int id)
        {
            PlayerID = id;
            HP = 1000.0;
            Armor = 1;
            PosX = id * 1000.0;
            PosY = 350;
        }
    }
}
