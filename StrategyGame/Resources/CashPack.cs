namespace StrategyGame
{
    public static class CashPack
    {
        public static int[] ForceCashReceived;

        static CashPack()
        {
            ForceCashReceived = new int[6];

            ForceCashReceived[(int)ForcesType.DroneCarrierForce] = 264;   //cost * 1.2
            ForceCashReceived[(int)ForcesType.CannonForce] = 288;
            ForceCashReceived[(int)ForcesType.RifleForce] = 180;
            ForceCashReceived[(int)ForcesType.RocketForce] = 216;
            ForceCashReceived[(int)ForcesType.ExplosiveForce] = 120;

        }
    }
}
