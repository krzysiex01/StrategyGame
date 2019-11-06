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
            Hp = ForceParametrsPack.Hp[(int)Id];
            Range = 1;
            Speed = 40;
            Armor = 0.95;
            AtackPoints = 1;
            Accuracy = 0.99;
            Texture = TexturePack.droneCarrierForce;
            ReloadTime = 0.2;
            IsReloading = true;
            GameEventEngine.Add(new GameEventDelayed(() => { IsReloading = false; }, ReloadTime));
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

                Missile missile2 = new Missile(enemyForce, AtackPoints, Random.NextDouble() <= Accuracy,
                    new Point((int)(2 * (500 - PosX) * (1.5 - (double)player.PlayerID) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)),
                    new Point((int)(2 * (500 - enemyForce.PosX) * ((double)player.PlayerID - 1.5) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)));

                Missile missile3 = new Missile(enemyForce, AtackPoints, Random.NextDouble() <= Accuracy,
                    new Point((int)(2 * (500 - PosX) * (1.5 - (double)player.PlayerID) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)),
                    new Point((int)(2 * (500 - enemyForce.PosX) * ((double)player.PlayerID - 1.5) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)));

                GameEffectsEngine.Add(missile);

                GameEventEngine.Add(new GameEventDelayed(() => { GameEffectsEngine.Add(missile2); }, 0.04));

                GameEventEngine.Add(new GameEventDelayed(() => { GameEffectsEngine.Add(missile3); }, 0.08));

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

                MissileBase missile2 = new MissileBase(player, AtackPoints, Random.NextDouble() <= Accuracy,
                    new Point((int)(2 * (500 - PosX) * (1.5 - (double)player.PlayerID) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)),
                    new Point((int)(2 * (500 - player.PlayerBase.PosX) * ((double)player.PlayerID - 1.5) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)));

                MissileBase missile3 = new MissileBase(player, AtackPoints, Random.NextDouble() <= Accuracy,
                   new Point((int)(2 * (500 - PosX) * (1.5 - (double)player.PlayerID) + 500),
                   (int)Force.PosY + (int)(170 * 0.2)),
                   new Point((int)(2 * (500 - player.PlayerBase.PosX) * ((double)player.PlayerID - 1.5) + 500),
                   (int)Force.PosY + (int)(170 * 0.2)));

                GameEffectsEngine.Add(missile);

                GameEventEngine.Add(new GameEventDelayed(() => { GameEffectsEngine.Add(missile2); }, 0.04));

                GameEventEngine.Add(new GameEventDelayed(() => { GameEffectsEngine.Add(missile3); }, 0.08));

                GameEventEngine.Add(new GameEventDelayed(() => { IsReloading = false; }, ReloadTime));
                IsReloading = true;
            }
        }

    }
}
