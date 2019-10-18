using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class DroneCarrierForce : Force
    {
        public DroneCarrierForce(GameTime gameTime)
        {
            Id = ForcesType.DroneCarrierForce;
            Hp = 150;
            Range = 1;
            Speed = 40;
            Armor = 0.95;
            AtackPoints = 1;
            Accuracy = 0.99;
            Texture = TexturePack.droneCarrierForce;
            ReloadTime = 0.3;
        }

        public override void Atack(Player player, Force enemyForce,GameTime gameTime)
        {
            base.Atack(player, enemyForce, gameTime);
            base.Atack(player, enemyForce, gameTime);
            base.Atack(player, enemyForce, gameTime);
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
