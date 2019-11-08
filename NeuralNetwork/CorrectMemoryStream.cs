using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace NeuralNetwork
{
    public class CorrectMemoryStream : MemoryStream
    {
        public override int WriteTimeout { get; set; }
        public override int ReadTimeout { get; set; }
        
    }
}
