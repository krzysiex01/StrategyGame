using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class Missile : IGameEffect
    {
        public Missile(double damage, bool isAccurate,Point from, Point to)
        {
            Damage = damage;
            IsAccurate = isAccurate;
            From = from;
            To = to;
            CurrentPosition = From;
            Direction = Math.Abs(To.X-From.X);
        }

        public double Damage { get; set; }
        public bool IsAccurate { get; set; }
        public Point From { get; set; }
        public Point To { get; set; }
        public Point CurrentPosition { get; set; }
        private int Direction { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(TexturePack.smoke, new Rectangle(CurrentPosition.X, CurrentPosition.Y, TexturePack.smoke.Width, TexturePack.smoke.Height), Color.White);
            spriteBatch.End();
        }

        public bool Update(GameTime gameTime)
        {
            CurrentPosition = new Point((int)(CurrentPosition.X + Direction * 20 * gameTime.ElapsedGameTime.TotalSeconds),CurrentPosition.Y);

            if (Math.Abs(To.X - CurrentPosition.X) < 10)
            {
                return false;
            }
            return true;
        }
    }
}
