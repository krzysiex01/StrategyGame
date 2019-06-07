﻿namespace StrategyGame
{
    public class CannonForce : Force
    {
        public CannonForce()
        {
            Id = ForcesType.Dziala;
            Hp = 200;
            Range = 4; //jeszcze dalej
            Speed = 15;
            Armor = 4;
            AtackPoints = 90;
            Cost = 240;
            Accuracy = 0.5;
            Ammo = 500;
            AmmoMax = 500;
        }
    }
}
