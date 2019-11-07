using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NeuralNetwork
{
    class Network
    {
        public double[][] Input { get; set; } = null;
        public double[][] Output { get; set; } = null;

        public FileStream F = new FileStream("io.txt", FileMode.Open, FileAccess.Read);
        public void DecodeIOFile()
        {
            var lineCount = File.ReadLines(@"io.txt").Count();
            Input = new double[lineCount][];
            Output = new double[lineCount][];

            for (int i=0;i<lineCount ;i++)
            {
                int output = F.ReadByte();
                Output[i] = new double[1];
                Output[i][0] = output-48;

                int byteInp;
                byteInp = F.ReadByte(); //read "-"

                Input[i] = new double[16];
                for(int j=0; j<15 ;j++)
                {
                    byteInp = F.ReadByte();
                    //Console.Write((char)byteInp);
                    Input[i][j] = byteInp-48;
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
                    Input[i][15] = cashInt;
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

            for(int i=0;i<lineCount;i++)
            {
                for(int j=0;j<16;j++)
                {
                    Console.Write(Input[i][j]);
                    Console.Write(" ");
                }

                Console.WriteLine(Output[i][0]);

            }


            Console.ReadKey();
        }



    }

}
