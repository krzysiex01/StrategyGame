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
        public int Cost { get; set; }
        public double Accuracy { get; set; }
        private Random Random { get; } = new Random();
        public double Ammo { get; set; } // NOT IMPLEMENTED
        public double AmmoMax { get; set; } // NOT IMPLEMENTED
        public double PosX { get; set; }
        public double PosY { get; set; } // NOT IMPLEMENTED

        public bool Stop { get; set; }
        public double Reload { get; set; } // IS BEING IMPLEMENTED
        public double LastShot { get; set; } //IS BEING IMPLEMENTED


        public Texture2D Texture { get; set; }

        public virtual void Atack(Force enemyForce, GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalSeconds - LastShot >= Reload)
            {
                enemyForce.Defend(new Missile(AtackPoints, Random.NextDouble() <= Accuracy));
                LastShot = gameTime.TotalGameTime.TotalSeconds;
            }
        }

        public virtual void Defend(Missile missile)
        {
            if (missile.IsAccurate)
            {
                Hp -= missile.Damage * Armor;
            }
        }

        public void Move(int fps)
        {
            if (!Stop)
            {
                PosX += 1.0 / ((double)fps) * Speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int playerID, int boardSize)
        {
            spriteBatch.Begin();
            switch (playerID)
            {
                case 1:
                    {
                        spriteBatch.Draw(Texture, new Vector2((int)PosX - (int)(0.2 * (double)Texture.Width), 300), new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.FlipHorizontally, 1);
                        break;
                    }
                case 2:
                    {
                        spriteBatch.Draw(Texture, new Vector2(boardSize - (int)PosX, 300), new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1);
                        break;
                    }
                default:
                    break;
            }
            spriteBatch.End();
        }
    }
}
