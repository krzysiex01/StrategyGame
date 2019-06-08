namespace StrategyGame
{
    public class RocketForce : Force
    {
        public RocketForce(TexturePack texturePack)
        {
            Id = ForcesType.Rakiety;
            Hp = 120;
            Range = 2;
            Speed = 30;
            Armor = 1;
            AtackPoints = 35;
            Cost = 180;
            Accuracy = 0.5;
            Texture = texturePack.rocketForce;
            Reload = 2.0;
        }

        public override void Atack(Force enemyForce)
        {
            base.Atack(enemyForce);
            base.Atack(enemyForce);
        }

    }
}
