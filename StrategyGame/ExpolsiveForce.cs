namespace StrategyGame
{
    public class ExpolsiveForce : Force
    {
        public ExpolsiveForce()
        {
            Id = ForcesType.Wybuchowy;
            Hp = 25;
            Range = 1; //z bliska
            Speed = 30;
            Armor = 4;
            AtackPoints = 100;
            Cost = 100;
            Accuracy = 1.0;
        }

        public override void Atack(Force enemyForce)
        {
            base.Atack(enemyForce);
            Hp = 0;
        }
    }
}
