using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StrategyGame
{
    public class DataCollector
    {
        public FileStream F = new FileStream("io.txt", FileMode.Append, FileAccess.Write);
        //public List<Entry> Entries;
        public DataCollector()
        {
            //this.WriteToFile();
        }

        public void WriteToFile(LearnInputOutput inputOutputToLearn)
        {
            String output = inputOutputToLearn.Output[0].ToString();
            F.WriteByte((byte)output[0]);
            F.WriteByte(45);
            for (int i = 0; i < inputOutputToLearn.Input.Count()-1; i++)
            {

                F.WriteByte((byte)(inputOutputToLearn.Input[i]+48));
            }
            F.WriteByte(124);
            String result = inputOutputToLearn.Input[inputOutputToLearn.Input.Count() - 1].ToString();

            for (int i = 0; i < result.Length; i++)
            {

                F.WriteByte((byte)(result[i]));
            }


            F.WriteByte(13);
            F.WriteByte(10);
        }
        
        public void CloseFile()
        {
            F.Close();
        }
    }
}
