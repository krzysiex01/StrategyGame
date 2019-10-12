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
            Texture2D rect = new Texture2D(TexturePack.graphicsDevice, 10, 10);

            Color[] data = new Color[10 * 10];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Black;
            rect.SetData(data);

            Vector2 coor = new Vector2(CurrentPosition.X, CurrentPosition.Y);
            spriteBatch.Begin();
            spriteBatch.Draw(rect,coor,Color.White);
            spriteBatch.End();
        }

        public bool Update(GameTime gameTime)
        {
            CurrentPosition = new Point((int)(CurrentPosition.X + Direction * 5 * gameTime.ElapsedGameTime.TotalSeconds),CurrentPosition.Y);

            if (Math.Abs(To.X - CurrentPosition.X) < 10)
            {
                return false;
            }
            return true;
        }
    }
}
