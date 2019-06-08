namespace StrategyGame
{
    public class CannonForce : Force
    {
        public CannonForce(TexturePack texturePack)
        {
            Id = ForcesType.Dziala;
            Hp = 200;
            Range = 4;
            Speed = 30;
            Armor = 4;
            AtackPoints = 1;
            Cost = 240;
            Accuracy = 0.5;
            Ammo = 500;
            AmmoMax = 500;
            Texture = texturePack.cannonForce;
            Reload = 5.0;
        }
    }
}
