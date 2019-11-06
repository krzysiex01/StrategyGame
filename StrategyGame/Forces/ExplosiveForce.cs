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
            Hp = ForceParametrsPack.Hp[(int)Id];
            Range = 0;
            Speed = 60;
            Armor = 0.98;
            AtackPoints = 150;
            Accuracy = 1.0;
            Texture = TexturePack.explosiveForce;
            ReloadTime = 0;
            IsReloading = false;
        }

        public override void Atack(Player player, Force enemyForce,GameTime gameTime)
        {
            base.Atack(player,enemyForce, gameTime);
            Hp = 0;
        }

        public override void Atack(Player player, GameTime gameTime)
        {
            base.Atack(player, gameTime);
            Hp = 0;
        }
    }
}
