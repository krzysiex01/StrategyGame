using System.Collections.Generic;

namespace StrategyGame
{
    public class DroneCarrierForce : Force
    {
        List<DroneForce> drones { get; set; }

        public DroneCarrierForce(TexturePack texturePack)
        {
            Id = ForcesType.BazaDronow;
            Hp = 150;
            Range = 2; //blisko
            Speed = 40;
            Armor = 1;
            AtackPoints = 0;
            Cost = 220;
            Accuracy = 0.99;
            Ammo = 0;
            AmmoMax = 0;
            Texture = texturePack.droneCarrierForce;
            drones = new List<DroneForce>();

            for (int i = 0; i < 5; i++)
            {
                drones.Add(new DroneForce());
            }
        }

        public override void Atack(Force enemyForce)
        {
            foreach (DroneForce drone in drones)
            {
                drone.Atack(enemyForce);
            }
        }

        public override void Defend(Missile missile)//TODO: More complex type of defence
        {
            if (missile.IsAccurate)
            {
                Hp -= missile.Damage * Armor;
            }
        }
    }
}
