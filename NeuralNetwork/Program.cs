using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Program
    {
        public static Network GlobalNetwork = new Network(16);

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to StrategyGame bot learner, copy your input/output learning file to the correct location and name it 'io.txt'");
            Console.WriteLine("Press any key to proceed");
            Console.ReadKey();
            GlobalNetwork.DecodeIOFile();
            GlobalNetwork.CreateNetwork(0.1,0);
            GlobalNetwork.Learn(0.1);
            GlobalNetwork.PublishWeights();
            double[] input = new double[] { 4,0,1,0,0,4,9,9,9,9,2,9,9,9,9,1046 };
            GlobalNetwork.Compute(input);
        }
    }
}
