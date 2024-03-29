﻿using System;
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
        public int Income { get; set; }
        public bool IsIncome { get; set; }
        public double IncomeTime { get; set; }
        public DataCollector Data { get; set; }
        public bool IsInactive { get; set; }
        public Base PlayerBase { get; set; }

        public Player(int size, int id, DataCollector data)
        {
            ListOfForces = new List<Force>();
            Upgrades = new int[Enum.GetNames(typeof(ForcesType)).Length];
            Cash = 1000;
            BoardSize = size;
            PlayerID = id;
            PlayerBase = new Base(id);
            Income = 20;
            IsIncome = true;
            IncomeTime = 5.0;
            IsInactive = true;
            Data = data;
        }

        public bool Upgrade(ForcesType forceType)
        {
            if (Upgrades[(int)forceType] + 1 >= 10)
            {
                return false;
            }

            int cost = UpgradePack.UpgradeCosts[(int)forceType, Upgrades[(int)forceType]];

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

        public bool AddForces(Force force, Player opponent, GameTime gameTime)
        {
            if (PurchasePack.ForceCosts[(int)force.Id] > Cash)
            {
                return false;
            }
            else
            {
                if (this.PlayerID == 1)
                {
                    LearnInputOutput learning = new LearnInputOutput(opponent.ListOfForces, this.ListOfForces, this.Upgrades, this.Cash, (int)force.Id);
                    Data.WriteToFile(learning);
                    this.DidSomething(gameTime);
                }
                Cash -= PurchasePack.ForceCosts[(int)force.Id];
                force.OriginalRange = force.Range;
                UpgradePack.UpgradeForce(force, Upgrades[(int)force.Id]);
                force.MaxHp = force.Hp;
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
                        
                        force.Atack(opponent,opponent.ListOfForces[0], gameTime);
                        if (force.PosX + opponent.ListOfForces[0].PosX + force.OriginalRange * 100.0 >= BoardSize)
                        {
                            force.Stop = true;
                        }
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
                        force.Atack(opponent, gameTime);
                        if (force.PosX + force.OriginalRange * 100.0 >= BoardSize)
                        {
                            force.Stop = true;
                        }
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

        public void DestroyNoHp(Player opponent)
        {
            if(ListOfForces.Count>0)
            {
                Force force = ListOfForces[0];
                if (force.Hp <= 0)
                {
                    opponent.Cash += CashPack.ForceCashReceived[(int)force.Id];
                    Explosion explosion = new Explosion(force,this);
                    GameEffectsEngine.Add(explosion);
                    ListOfForces.RemoveAt(0);
                }
            }
        }

        public void AddCash(GameTime gameTime)
        {
            if(IsIncome==true)
            {
                IsIncome = false;
                GameEventEngine.Add(new GameEventDelayed(() => { Cash += Income; IsIncome = true; }, IncomeTime));
            }  
        }

        public void DidSomething(GameTime gameTime)
        {
            
            IsInactive = false;   
            
        }
    }
}
