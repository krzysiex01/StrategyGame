namespace StrategyGame
{
    public class RocketForce : Force
    {
        public RocketForce()
        {
            Id = ForcesType.Rakiety;
            Hp = 120;
            Range = 2; //blisko
            Speed = 15;
            Armor = 1;
            AtackPoints = 35;
            Cost = 180;
            Accuracy = 0.5;
        }

        public override void Atack(Force enemyForce)
        {
            base.Atack(enemyForce);
            base.Atack(enemyForce);
        }

    }
}
