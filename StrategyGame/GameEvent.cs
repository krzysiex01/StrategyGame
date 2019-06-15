using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrategyGame
{
    public static class GameEventEngine
    {
        private static LinkedList<GameEvent> GameEvents = new LinkedList<GameEvent>();

        public static void Add(GameEvent gameEvent)
        {
            GameEvents.AddLast(gameEvent);
        }

        public static void Update(GameTime gameTime)
        {
            var it = GameEvents.First;

            while (it != null)
            {
                var current = it.Next;

                if (!current.Value.Update(gameTime))
                {
                    GameEvents.Remove(current);
                }
            }
        }
    }

    public class GameEvent
    {
        public GameEvent(Action action, double delay)
        {
            TimeRemaining = delay;
            Action = action;
            Delay = delay;
        }

        private Action Action { get; set; }
        private double Delay { get; set; }
        private double TimeRemaining { get; set; }

        public bool Update(GameTime gameTime)
        {
            TimeRemaining -= gameTime.ElapsedGameTime.TotalSeconds;

            if (TimeRemaining <= 0)
            {
                Action();
                return false;
            }

            return true;
        }
    }
}
