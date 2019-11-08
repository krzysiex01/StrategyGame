using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NeuralNetwork
{
    public class Program
    {
        static void Main(string[] args)
        {
            Network network= new Network(16);
            Console.WriteLine("Welcome to StrategyGame bot learner, copy your input/output learning file to the correct location and name it 'io.txt'");
            Console.WriteLine("Press any key to proceed");
            Console.ReadKey();
            network.DecodeIOFile();
            network.CreateNetwork(0.1,0);
            network.Learn(0.2);
            network.PublishWeights();
            network.Serialize();
            double[] input = new double[] { 4,0,1,0,0,4,9,9,9,9,2,9,9,9,9,1046 };
            network.Compute(input);



        }

        
    }
}
