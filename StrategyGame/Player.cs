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

        public Base PlayerBase;

        public Player(int size, int id)
        {
            ListOfForces = new List<Force>();
            Upgrades = new int[Enum.GetNames(typeof(ForcesType)).Length];
            Cash = 100000;
            BoardSize = size;
            PlayerID = id;
            PlayerBase = new Base(id);
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

        private void DetectCollision(int playerId)
        {
            if (playerId == 1)
            {

            for (int i = 1; i < ListOfForces.Count; i++)
            {
                if (ListOfForces[i - 1].PosX < ListOfForces[i].PosX + ListOfForces[i].Texture.Width * 0.2)
                {
                    ListOfForces[i].Stop = true;
                }
                else
                {
                    ListOfForces[i].Stop = false;
                }
            }
            }
            else
            {
                for (int i = 1; i < ListOfForces.Count; i++)
                {
                    if (ListOfForces[i - 1].PosX< ListOfForces[i].PosX + ListOfForces[i - 1].Texture.Width * 0.2)
                    {
                        ListOfForces[i].Stop = true;
                    }
                    else
                    {
                        ListOfForces[i].Stop = false;
                    }
                }
            }
        }

        public void Update(Player opponent, GameTime gameTime)
        {
            //ListOfForces.Sort(new Utility.SortByX()); //still can be better
            DetectCollision(PlayerID);

            foreach (Force force in ListOfForces)
            {
                force.Move(gameTime);
            }

            foreach (Force force in ListOfForces)
            {
                force.Stop = false;
                if (opponent.ListOfForces.Count > 0)
                {
                    if (force.PosX + opponent.ListOfForces[0].PosX + force.Range * 100.0 >= BoardSize)
                    {
                        force.Stop = true;
                        force.Atack(opponent,opponent.ListOfForces[0], gameTime);
                    }
                }
            }

            if (opponent.ListOfForces.Count == 0)
            {
                foreach (Force force in ListOfForces)
                {
                    force.Stop = false;
                    if (force.PosX + force.Range * 100.0 >= BoardSize)
                    {
                        force.Stop = true;
                        force.Atack(opponent, gameTime);
                        
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
