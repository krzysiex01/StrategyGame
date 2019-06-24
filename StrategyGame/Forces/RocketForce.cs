using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class RocketForce : Force
    {
        public RocketForce(GameTime gameTime)
        {
            Id = ForcesType.RocketForce;
            Hp = 120;
            Range = 2;
            Speed = 40;
            Armor = 0.8;
            AtackPoints = 35;
            Accuracy = 0.5;
            Texture = TexturePack.rocketForce;
            ReloadTime = 2.0;
            IsReloading = false;
        }

        public override void Atack(Force enemyForce,GameTime gameTime)
        {
            base.Atack(enemyForce, gameTime);
            base.Atack(enemyForce, gameTime);
        }

    }
}
