﻿using System;
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
        public int Armor { get; set; } // Storing as % value - TODO: UPDATE VALUES
        public double AtackPoints { get; set; }
        public int Cost { get; set; }
        public double Accuracy { get; set; }
        private Random Random { get; } = new Random();
        public double Ammo { get; set; } // NOT IMPLEMENTED
        public double AmmoMax { get; set; } // NOT IMPLEMENTED
        public double PosX { get; set; }
        public double PosY { get; set; } // NOT IMPLEMENTED

        public bool Stop { get; set; }
        public bool Reloading { get; set; } // NOT IMPLEMENTED

        public Texture2D Texture { get; set; }

        public virtual void Atack(Force enemyForce)
        {
            enemyForce.Defend(new Missile(AtackPoints, Random.NextDouble() <= Accuracy));
        }

        public virtual void Defend(Missile missile)
        {
            if (missile.IsAccurate)
            {
                Hp -= missile.Damage * Armor;
            }
        }

        public void Move()
        {
            if (!Stop)
            {
                PosX += 0.1 * Speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Vector2((int)PosX, 300), new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.FlipHorizontally, 1);
            spriteBatch.End();
        }
    }
}
