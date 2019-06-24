using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class ExplosiveForce : Force
    {
        public ExplosiveForce(GameTime gameTime)
        {
            Id = ForcesType.ExplosiveForce;
            Hp = 25;
            Range = 0;
            Speed = 60;
            Armor = 0.98;
            AtackPoints = 100;
            Accuracy = 1.0;
            Texture = TexturePack.explosiveForce;
            ReloadTime = 0;
            IsReloading = false;
        }

        public override void Atack(Force enemyForce,GameTime gameTime)
        {
            base.Atack(enemyForce, gameTime);
            Hp = 0;
        }
    }
}
