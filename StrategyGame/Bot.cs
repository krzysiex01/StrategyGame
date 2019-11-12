using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NeuralNetwork;
using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;
using AForge.Controls;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrategyGame
{
    public class Bot
    {
        public Network ActNetwork { get; set; }
        public bool IsStarted { get; set; }
        public Bot()
        {
            ActNetwork = Network.Load("Siec.bin");
            IsStarted = false;
        }

        public int Decision(Player player, Player bot)
        {
            List<Force> enemyForcesAll = player.ListOfForces;
            List<Force> yourForcesAll = bot.ListOfForces;
            int[] upgrades = bot.Upgrades;
            int cash = bot.Cash;

            double[] input = new double[16];

            for (int i = 0; i < upgrades.Length; i++)
            {
                input[i] = upgrades[i];
            }

            for (int i = 5; i < 10; i++)
            {
                if (i - 5 < enemyForcesAll.Count())
                {
                    input[i] = (double)((int)enemyForcesAll[i - 5].Id);
                }
                else
                {
                    input[i] = 9;
                }
            };

            for (int i = 10; i < 15; i++)
            {
                if (i - 10 < yourForcesAll.Count())
                {
                    input[i] = (double)((int)yourForcesAll[i - 10].Id);
                }
                else
                {
                    input[i] = 9;
                }
            };

            input[15] = cash;


            //editing input to match learned form
            for (int i = 0; i < 15; i++)
            {
                input[i] /= 10.0;
            }
            input[15] = Math.Min(input[15] / 2000.0, 1);

            double[] result;
            result = ActNetwork.Compute(input);

            for (int i = 0; i < 4; i++)
            {
                result[i] = Math.Round(result[i]);
            }

            int decision = 0;
            for (int i = 0; i < 4; i++)
            {
                decision += (int)result[i] * (int)Math.Pow(2.0, i);
            }

            return decision;

            //0 - buy explosive
            //1 - buy rifle
            //2 - buy rocket
            //3 - buy drone
            //4 - buy cannon
            //5 - wait (do nothing)
            //6 - upgradeExplosive
            //7 - upgradeRifle
            //8 - upgradeRocket
            //9 - upgradeDrone
            //10 - upgradeCannon
            //11 - wait (do nothing)
            //12 - wait (do nothing)
            //13 - wait (do nothing)
            //14 - wait (do nothing)
            //15 - wait (do nothing)
        }

        public void Proceed(int decision, Player player, Player bot, GameTime gameTime)
        {
            switch (decision)
            {
                case 0:
                    {
                        bot.AddForces(new ExplosiveForce(gameTime), bot, gameTime);
                        break;
                    }
                case 1:
                    {
                        bot.AddForces(new RifleForce(gameTime), bot, gameTime);
                        break;
                    }
                case 2:
                    {
                        bot.AddForces(new RocketForce(gameTime), bot, gameTime);
                        break;
                    }
                case 3:
                    {
                        bot.AddForces(new DroneCarrierForce(gameTime), bot, gameTime);
                        break;
                    }
                case 4:
                    {
                        bot.AddForces(new CannonForce(gameTime), bot, gameTime);
                        break;
                    }
                case 5:
                    {
                        //wait
                        break;
                    }
                case 6:
                    {
                        bot.Upgrade((ForcesType)0);
                        break;
                    }
                case 7:
                    {
                        bot.Upgrade((ForcesType)1);
                        break;
                    }
                case 8:
                    {
                        bot.Upgrade((ForcesType)2);
                        break;
                    }
                case 9:
                    {
                        bot.Upgrade((ForcesType)3);
                        break;
                    }
                case 10:
                    {
                        bot.Upgrade((ForcesType)4);
                        break;
                    }
                default:
                    break;

            }
        }



    }
}
