using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NeuralNetwork;

namespace StrategyGame
{
    public class Bot
    {

        public int Decision()
        {
            double[] input = new double[] { 4, 0, 1, 0, 0, 4, 9, 9, 9, 9, 2, 9, 9, 9, 9, 1046 };
            
            //0 - explosive
            //1 - rifle
            //2 - rocket
            //3 - drone
            //4 - cannon
            //5 - wait (do nothing)
            //6 - upgradeExplosive
            //7 - upgradeRifle
            //8 - upgradeRocket
            //9 - upgradeDrone
            //10 - upgradeCannon

            return 1;
        }
    }

    


}
