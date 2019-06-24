using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace StrategyGame
{
    public class Missile
    {
        public Missile(double damage, bool isAccurate,Point from, Point to)
        {
            Damage = damage;
            IsAccurate = isAccurate;
            From = from;
            To = to;
        }

        public double Damage { get; set; }
        public bool IsAccurate { get; set; }
        public Point From { get; set; }
        public Point To { get; set; }
    }
}
