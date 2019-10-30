namespace StrategyGame
{
    public static class UpgradePack
    {
        public static string[,] UpgradeInfo { get; }

        public static double[,][] UpgradeValues { get; }

        public static int[,] UpgradeCosts { get; }

        static UpgradePack() //TODO: More complex and personalized values, costs and descriptions for each force type
        {
            UpgradeInfo = new string[6,10];
            UpgradeValues = new double[6,10][];
            UpgradeCosts = new int[6, 10];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    UpgradeValues[i, j] = new double[5];
                    UpgradeInfo[i, j] = "HP, Atack and Speed +10%";
                    UpgradeCosts[i, j] = 500*(j+1);

                    for (int k = 0; k < 5; k++)
                    {
                        UpgradeValues[i, j][k] = 1 + j * 0.1;
                    }
                }
            }
        }

        public static void UpgradeForce(Force force, int upgradeLevel)
        {
            force.Hp *= UpgradeValues[(int)force.Id, upgradeLevel][0];
            //force.Armor *= UpgradeValues[(int)force.Id, upgradeLevel][1];  //TODO: Armor & Accuracy upgrades
            force.AtackPoints *= UpgradeValues[(int)force.Id, upgradeLevel][2];
            //force.Accuracy *= UpgradeValues[(int)force.Id, upgradeLevel][3];
            force.Speed *= UpgradeValues[(int)force.Id, upgradeLevel][4];
        }
    }
}
