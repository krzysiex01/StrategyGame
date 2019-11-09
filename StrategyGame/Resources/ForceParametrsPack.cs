using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame
{
    static public class ForceParametrsPack
    {
        public static double[] Hp { get; set; }
        static ForceParametrsPack()
        {
            
            Hp = new double[6];
            Hp[(int)ForcesType.DroneCarrierForce] = 180;
            Hp[(int)ForcesType.CannonForce] = 200;
            Hp[(int)ForcesType.RifleForce] = 80;
            Hp[(int)ForcesType.RocketForce] = 120;
            Hp[(int)ForcesType.ExplosiveForce] = 40;

        }
    }
}
