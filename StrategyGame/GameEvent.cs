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
                var next = it.Next;

                if (!it.Value.Update(gameTime))
                {
                    GameEvents.Remove(it);
                }
                it = next;
            }
        }
    }

    public interface GameEvent
    {
        bool Update(GameTime gameTime);
    }

    public class GameEventCyclic: GameEvent
    {
        private Action Action { get; set; }
        private double TimeRemaining { get; set; }
        private double TimeLapse { get; }
        private int RepeatCount { get; set; }
        private double TimeLapseRemaining { get; set; }
        private bool IsDelayed { get; set; }

        public GameEventCyclic(Action action, double lapse, int repeat, double delay = 0)
        {
            TimeRemaining = delay;
            TimeLapseRemaining = lapse;
            IsDelayed = delay != 0 ? true : false;
            TimeLapse = lapse;
            Action = action;
            RepeatCount = repeat;
        }

        public bool Update(GameTime gameTime)
        {
            if (IsDelayed)
            {
                TimeRemaining -= gameTime.ElapsedGameTime.TotalSeconds;

                if (TimeRemaining <= 0)
                {
                    Action();
                    RepeatCount--;
                    IsDelayed = false;
                }
                return true;
            }
            else
            {
                TimeLapseRemaining -= gameTime.ElapsedGameTime.TotalSeconds;

                if (RepeatCount <= 0)
                {
                    return false;
                }

                if (TimeLapseRemaining <= 0)
                {
                    Action();
                    RepeatCount--;
                    TimeLapseRemaining += TimeLapse; 
                }
                return true;
            }
        }
    }

    public class GameEventDelayed: GameEvent
    {
        private Action Action { get; set; }
        private double TimeRemaining { get; set; }

        public GameEventDelayed(Action action, double delay)
        {
            TimeRemaining = delay;
            Action = action;
        }

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
