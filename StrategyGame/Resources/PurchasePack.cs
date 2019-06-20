namespace StrategyGame
{
    public static class PurchasePack
    {
        public static string[] ForceDescription;
        public static int[] ForceCosts;

        static PurchasePack()
        {
            ForceDescription = new string[6];
            ForceCosts = new int[6];

            ForceCosts[(int)ForcesType.DroneCarrierForce] = 220;
            ForceCosts[(int)ForcesType.CannonForce] = 240;
            ForceCosts[(int)ForcesType.RifleForce] = 150;
            ForceCosts[(int)ForcesType.RocketForce] = 180;
            ForceCosts[(int)ForcesType.ExplosiveForce] = 100;

        }
    }
}
