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
            Hp = ForceParametrsPack.Hp[(int)Id];
            Range = 4;
            Speed = 40;
            Armor = 0.8;
            AtackPoints = 20;
            Accuracy = 0.5;
            Texture = TexturePack.rocketForce;
            ReloadTime = 3.0;
            IsReloading = false;
        }

        public override void Atack(Player player, Force enemyForce,GameTime gameTime)
        {
            if (!IsReloading)
            {
                Missile missile = new Missile(enemyForce, AtackPoints, Random.NextDouble() <= Accuracy,
                    new Point((int)(2 * (500 - PosX) * (1.5 - (double)player.PlayerID) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)),
                    new Point((int)(2 * (500 - enemyForce.PosX) * ((double)player.PlayerID - 1.5) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)));


                GameEffectsEngine.Add(missile);

                Missile missile2 = new Missile(enemyForce, AtackPoints, Random.NextDouble() <= Accuracy,
                    new Point((int)(2 * (500 - PosX) * (1.5 - (double)player.PlayerID) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)),
                    new Point((int)(2 * (500 - enemyForce.PosX) * ((double)player.PlayerID - 1.5) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)));

                GameEventEngine.Add(new GameEventDelayed(() => { GameEffectsEngine.Add(missile2); }, 0.1));

                GameEventEngine.Add(new GameEventDelayed(() => { IsReloading = false; }, ReloadTime));

                IsReloading = true;
            }
        }

        public override void Atack(Player player, GameTime gameTime)
        {
            if (!IsReloading)
            {
                MissileBase missile = new MissileBase(player, AtackPoints, Random.NextDouble() <= Accuracy,
                    new Point((int)(2 * (500 - PosX) * (1.5 - (double)player.PlayerID) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)),
                    new Point((int)(2 * (500 - player.PlayerBase.PosX) * ((double)player.PlayerID - 1.5) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)));

                GameEffectsEngine.Add(missile);

                MissileBase missile2 = new MissileBase(player, AtackPoints, Random.NextDouble() <= Accuracy,
                    new Point((int)(2 * (500 - PosX) * (1.5 - (double)player.PlayerID) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)),
                    new Point((int)(2 * (500 - player.PlayerBase.PosX) * ((double)player.PlayerID - 1.5) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)));

                GameEventEngine.Add(new GameEventDelayed(() => { GameEffectsEngine.Add(missile2); }, 0.1));

                GameEventEngine.Add(new GameEventDelayed(() => { IsReloading = false; }, ReloadTime));
                IsReloading = true;
            }
        }

    }
}
