namespace StrategyGame
{
    public class Missile
    {
        public Missile(double damage, bool isAccurate)
        {
            Damage = damage;
            IsAccurate = isAccurate;
        }

        public double Damage { get; set; }
        public bool IsAccurate { get; set; }
    }
}
