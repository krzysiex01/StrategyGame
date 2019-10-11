using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame
{
    public static class GameEffectsEngine
    {
        private static LinkedList<IGameEffect> GameEffects  = new LinkedList<IGameEffect>();

        public static void Add(IGameEffect gameEffect)
        {
            GameEffects.AddLast(gameEffect);
        }

        public static void Update(GameTime gameTime)
        {
            var it = GameEffects.First;

            while (it != null)
            {
                var next = it.Next;

                if (!it.Value.Update(gameTime))
                {
                    GameEffects.Remove(it);
                }
                it = next;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            var it = GameEffects.First;

            while (it != null)
            {
                var next = it.Next;

                it.Value.Draw(spriteBatch);
                it = next;
            }
        }
    }

    public interface IGameEffect
    {
        void Draw(SpriteBatch spriteBatch);
        bool Update(GameTime gameTime);
    }


}
