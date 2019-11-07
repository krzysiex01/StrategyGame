using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Network network = new Network();

            Console.WriteLine("Welcome to StrategyGame bot learner, copy your input/output learning file to the correct location and name it 'io.txt'");
            Console.WriteLine("Press any key to proceed");
            Console.ReadKey();
            network.DecodeIOFile();

        }
    }
}
