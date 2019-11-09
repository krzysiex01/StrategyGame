using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame
{
    public class LearnInputOutput
    {
        public List<int> Input { get; set; }
        public List<int> Output { get; set; }

        public LearnInputOutput(List<Force> enemyForcesAll, List<Force> yourForcesAll, int[] upgrades, int cash, int decision)
        {
            Input = new List<int>();
            Output = new List<int>();

            Output.Add(decision);

            for (int i = 0; i < upgrades.Length; i++)
            {
                Input.Add(upgrades[i]);
            }

            for (int i=0;i<5;i++)
            {
                if(i<enemyForcesAll.Count())
                {
                    Input.Add((int)enemyForcesAll[i].Id);
                }
                else
                {
                    Input.Add(9);
                }
            };

            for (int i = 0; i < 5; i++)
            {
                if (i < yourForcesAll.Count())
                {
                    Input.Add((int)yourForcesAll[i].Id);
                }
                else
                {
                    Input.Add(9);
                }
            };

            Input.Add(cash);


        }
    }
}
