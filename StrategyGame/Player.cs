using System;
using System.Collections.Generic;

namespace StrategyGame
{
    public class Player
    {
        public List<Force> ListOfForces { get; set; }
        public int Cash { get; set; }
        public int[] Upgrades { get; set; }

        public Player()
        {
            ListOfForces = new List<Force>();
            Upgrades = new int[Enum.GetNames(typeof(ForcesType)).Length];
            Cash = 1000000;
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

        public void Update(Player opponent)
        {
            foreach (Force force in ListOfForces)
            {
                force.Move();
            }

            foreach (Force force in ListOfForces)
            {
                force.Atack(opponent.ListOfForces[0]);
            }
        }

        public void DestroyNoHp()
        {
            this.ListOfForces.RemoveAll(s => s.Hp <= 0); //TODO optimize
        }
    }
}
