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
            GameEventEngine.Add(new GameEventDelayed(() => { IsFinished = true; }, TimeOfExplosion));
        }

        public static double TimeOfExplosion = 5.0;
        public Force MyForce { get; set; }
        public Player Me { get; set; }

        bool IsFinished;

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D rect = new Texture2D(TexturePack.graphicsDevice, (int)(600*0.2), (int)(400*0.2));

            Color[] data = new Color[(int)(600 *0.2 * 400*0.2)];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Red;
            rect.SetData(data);

            Vector2 coor = new Vector2((float)(2 * (500 - MyForce.PosX) * ((double)Me.PlayerID - 1.5) + 500 + 600 * 0.2*(double)(Me.PlayerID-2)), (float)Force.PosY);
            spriteBatch.Begin();
            spriteBatch.Draw(rect, coor, Color.White);
            spriteBatch.End();
            rect.Dispose();
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
