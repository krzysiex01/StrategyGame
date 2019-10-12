using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class DroneCarrierForce : Force
    {
        List<DroneForce> drones { get; set; }

        public DroneCarrierForce(GameTime gameTime)
        {
            Id = ForcesType.DroneCarrierForce;
            Hp = 150;
            Range = 2;
            Speed = 40;
            Armor = 0.95;
            AtackPoints = 0;
            Accuracy = 0.99;
            Texture = TexturePack.droneCarrierForce;
            //LastShot = gameTime.TotalGameTime.TotalSeconds;
            //Reload = 0.3;
            drones = new List<DroneForce>();

            for (int i = 0; i < 5; i++)
            {
                drones.Add(new DroneForce(gameTime));
            }

        }

        public override void Atack(Player player, Force enemyForce,GameTime gameTime)
        {
            foreach (DroneForce drone in drones)
            {
                drone.Atack(player,enemyForce, gameTime);
            }
        }

        public override void Defend(Missile missile)//TODO: More complex type of defence
        {
            if (missile.IsAccurate)
            {
                Hp -= missile.Damage * Armor;
            }
        }
    }
}
