using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame
{
    public class Win
    {

       public int CheckWin(Player player1, Player player2)
       {
            if(player1.PlayerBase.Hp<=0)
            {
                return 2;
            }else if(player2.PlayerBase.Hp<=0)
            {
                return 1;
            }else
            {
                return 0;
            }

       }
    }
}
