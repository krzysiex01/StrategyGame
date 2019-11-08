using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;
using AForge.Controls;

namespace NeuralNetwork
{
    [Serializable]
    public class Network
    {
        public double[][] Input { get; set; } = null;
        public double[][] Output { get; set; } = null;
        public ActivationNetwork Network1 { get; set; }
        public BackPropagationLearning Teacher { get; set; }
        public int LineCount { get; set; }
        public int MiddleNeuronsCount { get; set; } = 16;
        public FileStream F { get; set; }


        public Network()
        {
        }

        public void DecodeIOFile()
        {
            string[] lines = File.ReadAllLines("io.txt");
            File.WriteAllLines("io.txt", lines.Distinct().ToArray());
            LineCount = File.ReadLines(@"io.txt").Count();
            Input = new double[LineCount][];
            Output = new double[LineCount][];
            F = new FileStream("io.txt", FileMode.Open, FileAccess.ReadWrite);
            for (int i = 0; i < LineCount; i++)
            {
                int output = F.ReadByte();
                Output[i] = new double[4];
                Output[i][0] =output%2;
                output /= 2;
                Output[i][1] = output % 2;
                output /= 2;
                Output[i][2] = output % 2;
                output /= 2;
                Output[i][3] = output % 2;


                int byteInp;
                byteInp = F.ReadByte(); //read "-"

                Input[i] = new double[16];
                for (int j = 0; j < 15; j++)
                {
                    byteInp = F.ReadByte();
                    //Console.Write((char)byteInp);
                    Input[i][j] = (double)(byteInp - 48)/10.0;
                }

                byteInp = F.ReadByte(); //read "|"

                String cash = null;

                do
                {
                    byteInp = F.ReadByte();
                    cash += (char)byteInp;
                } while (byteInp != 13);

                //Console.Write(cash);

                int cashInt = 0;
                try
                {
                    cashInt = System.Convert.ToInt32(cash);
                    Input[i][15] = Math.Min((double)cashInt/2000.0,1);
                }
                catch (FormatException)
                {
                    // the FormatException is thrown when the string text does 
                    // not represent a valid integer.
                }
                catch (OverflowException)
                {
                    // the OverflowException is thrown when the string is a valid integer, 
                    // but is too large for a 32 bit integer.  Use Convert.ToInt64 in
                    // this case.
                }
                byteInp = F.ReadByte(); //read "10"

                //Console.WriteLine();
            }

            for (int i = 0; i < LineCount; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(Input[i][j]);
                    Console.Write(" ");
                }

                Console.Write(Output[i][0]);
                Console.Write(" ");
                Console.Write(Output[i][1]);
                Console.Write(" ");
                Console.Write(Output[i][2]);
                Console.Write(" ");
                Console.WriteLine(Output[i][3]);

            }


            Console.ReadKey();
        }


        public void CreateNetwork(double learningRate, double momentum)
        {
            Network1 = new ActivationNetwork((IActivationFunction)new SigmoidFunction(2), 16, MiddleNeuronsCount, 4);
            Teacher = new BackPropagationLearning(Network1);
            Teacher.LearningRate = learningRate;
            Teacher.Momentum = momentum;
        }

        public void Learn(double errorLimit)
        {
            bool needToStop = false;
            int iteration = 1;

            while (!needToStop)
            {
                double error = Teacher.RunEpoch(Input, Output)/(double)LineCount;
                iteration++;
                Console.WriteLine(error);
                //Console.WriteLine(Network1.Layers[0].Neurons[1].Weights[0]);
                //Console.WriteLine(Network1.Compute(Input[0])[0]);

                if (error <= errorLimit)
                    needToStop = true;
                
            }

        }

        public void PublishWeights()
        {
            Console.WriteLine("Warstwa srodkowa");
            for(int i=0;i<MiddleNeuronsCount;i++)
            {
                for(int j=0;j<16;j++)
                {
                    Console.Write(Network1.Layers[0].Neurons[i].Weights[j].ToString("F2"));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Output");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(Network1.Layers[1].Neurons[i].Weights[j].ToString("F2"));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public int Compute(double[] input)
        {
            //editing input to match learned form
            for(int i=0;i<15;i++)
            {
                input[i] /= 10.0;
            }
            input[15] = Math.Min(input[15] / 2000.0, 1);

            double[] result;
            result = Network1.Compute(input);

            for (int i = 0; i < 4; i++)
            {
                result[i] = Math.Round(result[i]);
            }

            for (int i=0;i<4;i++)
            {
                Console.Write(result[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.ReadKey();

            int decision=0;
            for(int i=0;i<4;i++)
            {
                decision += (int)result[i]*(int)Math.Pow(2.0, i);
            }
            Console.WriteLine(decision);
            Console.ReadKey();
            return decision;

        }


    }

}
