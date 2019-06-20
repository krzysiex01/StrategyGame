using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class DroneForce : Force
    {
        public DroneForce(GameTime gameTime)
        {
            Id = ForcesType.Drones;
            Hp = 15;
            Range = 2;
            Speed = 40;
            Armor = 0;
            AtackPoints = 1;
            Accuracy = 0.99;
            ReloadTime = 0.3;
            IsReloading = false;
        }
    }
}
