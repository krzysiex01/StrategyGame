using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrategyGame
{
    public class Player
    {
        public List<Force> ListOfForces { get; set; }
        public int Cash { get; set; }
        public int BoardSize { get; set; }
        public int[] Upgrades { get; set; }

        public int PlayerID { get; set; }

        public Player(int size,int id)
        {
            ListOfForces = new List<Force>();
            Upgrades = new int[Enum.GetNames(typeof(ForcesType)).Length];
            Cash = 1000000;
            BoardSize = size;
            PlayerID = id;
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
                ListOfForces.Add(force);
                return true;
            }
        }

        public void Update(Player opponent,int fps)
        {
            foreach (Force force in ListOfForces)
            {
                force.Move(fps);
            }

            foreach (Force force in ListOfForces)
            {
                force.Stop = false;
                if(opponent.ListOfForces.Count > 0)
                {
                    
                    if (force.PosX + opponent.ListOfForces[0].PosX + force.Range * 100.0 >= (double)BoardSize)
                    {
                        force.Stop = true;
                        force.Atack(opponent.ListOfForces[0]);
                    }
           
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var force in ListOfForces)
            {
                force.Draw(spriteBatch, PlayerID,BoardSize);
            }
        }

        public void DestroyNoHp()
        {
            this.ListOfForces.RemoveAll(s => s.Hp <= 0); //TODO optimize
        }
    }
}
