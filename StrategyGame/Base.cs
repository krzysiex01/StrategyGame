using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace StrategyGame
{
    public class Base
    {
        public double Hp { get; set; }

        public int PlayerID { get; set; }

        public double PosX { get; set; }

        public double PosY { get; set; }

        public double Armor { get; set; }

        public Base(int id)
        {
            PlayerID = id;
            Hp = 1000.0;
            Armor = 1.0;
            PosX = 0.0;
            PosY = 350.0;
        }

        public void Defend(Missile missile)
        {
            if (missile.IsAccurate)
            {
                Hp -= missile.Damage * Armor;
            }
        }
    }
}
