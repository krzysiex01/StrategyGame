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
        public double PosY { get; set; } // NOT IMPLEMENTED
        public double ReloadTime { get; set; }
        public bool IsReloading { get; set; }
        public bool Stop { get; set; }


        public virtual void Atack(Force enemyForce, GameTime gameTime)
        {
            if (!IsReloading)
            {
                enemyForce.Defend(new Missile(AtackPoints, Random.NextDouble() <= Accuracy,new Point((int)PosX,(int)PosY), new Point((int)enemyForce.PosX,(int)enemyForce.PosY)));
                GameEffectsEngine.Add(new Missile(AtackPoints, Random.NextDouble() <= Accuracy, new Point((int)PosX, (int)PosY), new Point((int)enemyForce.PosX, (int)enemyForce.PosY)));
                IsReloading = true;
                GameEventEngine.Add(new GameEventDelayed(() => { IsReloading = false; }, ReloadTime));
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
                        spriteBatch.Begin();
                        spriteBatch.Draw(Texture, new Vector2((int)PosX, 350), new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1);
                        spriteBatch.End();
                        break;
                    }
                case 2:
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(Texture, new Vector2(boardSize - (int)PosX, 350), new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.FlipHorizontally, 1);
                        spriteBatch.End();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
