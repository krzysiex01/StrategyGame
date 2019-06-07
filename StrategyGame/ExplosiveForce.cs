namespace StrategyGame
{
    public class ExplosiveForce : Force
    {
        public ExplosiveForce(TexturePack texturePack)
        {
            Id = ForcesType.Wybuchowy;
            Hp = 25;
            Range = 1; //z bliska
            Speed = 30;
            Armor = 4;
            AtackPoints = 100;
            Cost = 100;
            Accuracy = 1.0;
            Texture = texturePack.explosiveForce;
        }

        public override void Atack(Force enemyForce)
        {
            base.Atack(enemyForce);
            Hp = 0;
        }
    }
}
