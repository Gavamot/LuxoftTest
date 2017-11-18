using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Combinations.Data;

namespace Combinations
{
    class OutputDataAcceptToXml : IOutputDataAccept
    {
        private string outputFile;
        public OutputDataAcceptToXml(string output)
        {
            this.outputFile = output;
        }
        /// <exception cref="IOException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void Save(Output output)
        {
            var xml = new StringBuilder();
            var settings = new XmlWriterSettings
            {
                Indent = true,
                ConformanceLevel = ConformanceLevel.Auto,
                OmitXmlDeclaration = true
            };
            using (var writer = XmlWriter.Create(xml, settings))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                var xs = new XmlSerializer(typeof(Output), "");
                xs.Serialize(writer, output, ns);
            }
            try{
                File.WriteAllText(outputFile, xml.ToString(), Encoding.UTF8);
            }
            catch (Exception e) {
                throw new IOException("Could not write output file", e);
            }
        }
    }
}
