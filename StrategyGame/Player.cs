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
                return f1.PosX < f2.PosX ? 1 : f1.PosX== f2.PosX ? 0 : -1;
            }
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
            Cash = 100000;
            BoardSize = size;
            PlayerID = id;
        }

        public bool Upgrade(ForcesType forceType)
        {
            if (Upgrades[(int)forceType] + 1 >= 10)
            {
                return false;
            }

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
            if (PurchasePack.ForceCosts[(int)force.Id] > Cash)
            {
                return false;
            }
            else
            {
                Cash -= PurchasePack.ForceCosts[(int)force.Id];
                UpgradePack.UpgradeForce(force, Upgrades[(int)force.Id]);
                ListOfForces.Add(force);
                return true;
            }
        }

        public void Update(Player opponent, GameTime gameTime)
        {
            ListOfForces.Sort(new Utility.SortByX()); //still can be better

            foreach (Force force in ListOfForces)
            {
                
                force.Move(gameTime);
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
            ListOfForces.RemoveAll(s => s.Hp <= 0); //TODO optimize
        }
    }
}
