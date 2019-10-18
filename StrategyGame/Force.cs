using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrategyGame
{
    /// <summary>
    /// This is the base class for all fighting in game.
    /// </summary>
    public abstract class Force
    {
        public ForcesType Id { get; set; }
        public double Hp { get; set; }
        public double Range { get; set; }
        public double Speed { get; set; }
        public double Armor { get; set; } // Storing as % value - the more the WORSE
        public double AtackPoints { get; set; }
        public double Accuracy { get; set; }
        private Random Random { get; } = new Random();
        public Texture2D Texture { get; set; }
        public double PosX { get; set; }
        public static double PosY { get; set; } = 350;
        public double ReloadTime { get; set; }
        public bool IsReloading { get; set; }
        public bool Stop { get; set; }

        public virtual void Atack(Player player, Force enemyForce, GameTime gameTime)
        {
            if (!IsReloading)
            {
                Missile missile = new Missile(enemyForce, AtackPoints, Random.NextDouble() <= Accuracy,
                    new Point((int)(2 * (500 - PosX) * (1.5 - (double)player.PlayerID) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)),
                    new Point((int)(2 * (500 - enemyForce.PosX) * ((double)player.PlayerID - 1.5) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)));
                GameEffectsEngine.Add(missile);
                GameEventEngine.Add(new GameEventDelayed(() => { IsReloading = false; }, ReloadTime));
                IsReloading = true;
            }
        }

        public virtual void Atack(Player player, GameTime gameTime)
        {
            if (!IsReloading)
            {
                MissileBase missile = new MissileBase(player, AtackPoints, Random.NextDouble() <= Accuracy,
                    new Point((int)(2 * (500 - PosX) * (1.5 - (double)player.PlayerID) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)),
                    new Point((int)(2 * (500 - player.PlayerBase.PosX) * ((double)player.PlayerID - 1.5) + 500),
                    (int)Force.PosY + (int)(170 * 0.2)));
                GameEffectsEngine.Add(missile);
                GameEventEngine.Add(new GameEventDelayed(() => { IsReloading = false; }, ReloadTime));
                IsReloading = true;
            }
        }

        public virtual void Defend(Missile missile)
        {
            if (missile.IsAccurate)
            {
                Hp -= missile.Damage * Armor;
            }
        }

        public void Move(GameTime gameTime)
        {
            if (!Stop)
            {
                PosX += gameTime.ElapsedGameTime.TotalSeconds * Speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int playerID, int boardSize)
        {
            switch (playerID)
            {
                case 1:
                    {
                        HpBar.Draw(spriteBatch,
                new Vector2((int)(2 * (500 - PosX) * ((double)playerID - 1.5) + 500 - (int)(600 * 0.2)),
                    (int)Force.PosY - 15),
                (int)(Texture.Width * 0.02),
                Hp / ForceParametrsPack.Hp[(int)Id]);
                        spriteBatch.Begin();
                        spriteBatch.Draw(Texture, new Vector2((int)PosX - (int)(600 * 0.2), (int)PosY), new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1);
                        spriteBatch.End();
                        break;
                    }
                case 2:
                    {
                        HpBar.Draw(spriteBatch,
                new Vector2((int)(2 * (500 - PosX) * ((double)playerID - 1.5) + 500),
                    (int)Force.PosY - 15),
                (int)(Texture.Width * 0.02),
                Hp / ForceParametrsPack.Hp[(int)Id]);
                        spriteBatch.Begin();
                        spriteBatch.Draw(Texture, new Vector2(boardSize - (int)PosX, (int)PosY), new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.FlipHorizontally, 1);
                        spriteBatch.End();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
