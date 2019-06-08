using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class ExplosiveForce : Force
    {
        public ExplosiveForce(TexturePack texturePack, GameTime gameTime)
        {
            Id = ForcesType.Wybuchowy;
            Hp = 25;
            Range = 0;
            Speed = 60;
            Armor = 4;
            AtackPoints = 100;
            Cost = 100;
            Accuracy = 1.0;
            Texture = texturePack.explosiveForce;
            Reload = 0;
            LastShot = gameTime.TotalGameTime.TotalSeconds;
        }

        public override void Atack(Force enemyForce,GameTime gameTime)
        {
            base.Atack(enemyForce, gameTime);
            Hp = 0;
        }
    }
}
