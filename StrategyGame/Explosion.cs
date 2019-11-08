using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class Explosion : IGameEffect
    {
        public Explosion(Force myForce, Player me)
        {
            MyForce = myForce;
            Me = me;
            IsFinished = false;
            Texture = TexturePack.explosion;
            GameEventEngine.Add(new GameEventDelayed(() => { IsFinished = true; }, TimeOfExplosion));
        }

        public static double TimeOfExplosion = 5.0;
        public Force MyForce { get; set; }
        public Player Me { get; set; }
        public Texture2D Texture { get; set; }
        bool IsFinished { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {

            Vector2 coor = new Vector2((float)(2 * (500 - MyForce.PosX) * ((double)Me.PlayerID - 1.5) + 500 + 600 * 0.2*(double)(Me.PlayerID-2)), (float)Force.PosY);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, coor, new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1);
            spriteBatch.End();
        }

        public bool Update(GameTime gameTime)
        {
            if (IsFinished == true)
            {
                return false;
            }
            return true;
        }
    }
}
