﻿namespace StrategyGame
{
    public class DroneForce : Force
    {
        public DroneForce()
        {
            Id = ForcesType.Drony;
            Hp = 15;
            Range = 2;
            Speed = 40;
            Armor = 0;
            AtackPoints = 1;
            Cost = 220;
            Accuracy = 0.99;
            Ammo = 200;
            AmmoMax = 200;
            Reload = 0.3;
        }
    }
}
