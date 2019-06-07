namespace StrategyGame
{
    public class RifleForce : Force
    {
        public RifleForce(TexturePack texturePack)
        {
            Id = ForcesType.Karabin;
            Hp = 80;
            Range = 3; //dalej
            Speed = 25;
            Armor = 2;
            AtackPoints = 5;
            Cost = 150;
            Accuracy = 0.9;
            Ammo = 200;
            AmmoMax = 200;
            Texture = texturePack.rifleForce;
        }

    }
}
