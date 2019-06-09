using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrategyGame
{
    public static class Utility
    {
        public class SortByX : IComparer<Force>
        {
            public int Compare(Force f1, Force f2)
            {
                return f1.PosX < f2.PosX ? 1 : -1;
            }
        }
    }

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
                    UpgradeInfo[i, j] = "Increase all 5 basic fields +10%";
                    UpgradeCosts[i, j] = 1000;

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
            force.Armor *= UpgradeValues[(int)force.Id, upgradeLevel][1];
            force.AtackPoints *= UpgradeValues[(int)force.Id, upgradeLevel][2];
            force.Accuracy *= UpgradeValues[(int)force.Id, upgradeLevel][3];
            force.Speed *= UpgradeValues[(int)force.Id, upgradeLevel][4];
        }
    }

    public class Player
    {
        public List<Force> ListOfForces { get; set; }
        public int Cash { get; set; }
        public int BoardSize { get; set; }
        public int[] Upgrades { get; set; }
        public int PlayerID { get; set; }

        public Player(int size, int id)
        {
            ListOfForces = new List<Force>();
            Upgrades = new int[Enum.GetNames(typeof(ForcesType)).Length];
            Cash = 1000000;
            BoardSize = size;
            PlayerID = id;
        }

        public bool Upgrade(ForcesType forceType)
        {
            int cost = UpgradePack.UpgradeCosts[(int)forceType, Upgrades[(int)forceType]+1];

            if (cost > Cash)
            {
                return false;
            }
            else
            {
                Cash -= cost;
                Upgrades[(int)forceType]++;
                return true;
            }
        }

        public bool AddForces(Force force)
        {
            if (force.Cost > Cash)
            {
                return false;
            }
            else
            {
                Cash -= force.Cost;
                UpgradePack.UpgradeForce(force, Upgrades[(int)force.Id]);
                ListOfForces.Add(force);
                return true;
            }
        }

        public void Update(Player opponent, int fps, GameTime gameTime)
        {
            ListOfForces.Sort(new Utility.SortByX()); //still can be better

            foreach (Force force in ListOfForces)
            {
                force.Move(fps);
            }

            foreach (Force force in ListOfForces)
            {
                force.Stop = false;
                if (opponent.ListOfForces.Count > 0)
                {
                    if (force.PosX + opponent.ListOfForces[0].PosX + force.Range * 100.0 >= (double)BoardSize)
                    {
                        force.Stop = true;
                        force.Atack(opponent.ListOfForces[0], gameTime);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var force in ListOfForces)
            {
                force.Draw(spriteBatch, PlayerID, BoardSize);
            }
        }

        public void DestroyNoHp()
        {
            this.ListOfForces.RemoveAll(s => s.Hp <= 0); //TODO optimize
        }
    }
}
