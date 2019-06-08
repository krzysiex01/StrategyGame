using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class RocketForce : Force
    {
        public RocketForce(TexturePack texturePack, GameTime gameTime)
        {
            Id = ForcesType.Rakiety;
            Hp = 120;
            Range = 2;
            Speed = 40;
            Armor = 0.8;
            AtackPoints = 35;
            Cost = 180;
            Accuracy = 0.5;
            Texture = texturePack.rocketForce;
            Reload = 2.0;
            LastShot = gameTime.TotalGameTime.TotalSeconds;
        }

        public override void Atack(Force enemyForce,GameTime gameTime)
        {
            base.Atack(enemyForce, gameTime);
            base.Atack(enemyForce, gameTime);
        }

    }
}
