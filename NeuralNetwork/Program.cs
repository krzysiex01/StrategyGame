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
            MyNetwork network= new MyNetwork();
            Console.WriteLine("Welcome to StrategyGame bot learner, copy your input/output learning file to the correct location and name it 'io.txt'");
            Console.WriteLine("Press any key to proceed");
            Console.ReadKey();
            network.DecodeIOFile();
            network.CreateNetwork(0.2, 0);
            network.Learn(0.1,30000);
            network.PublishWeights();

            double[] input = new double[] { 4,0,1,0,0,4,9,9,9,9,2,9,9,9,9,1046 };
            network.Compute(input);

            network.ActNetwork.Save("Siec.bin");



        }

        
    }
}
