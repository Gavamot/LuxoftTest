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
    class FileXmlDataSource : IInputDataSource
    {
        private string inputFile;
        public FileXmlDataSource(string input)
        {
            inputFile = input;
        }

        /// <exception cref="IOException">Input file does not exist</exception>
        /// <exception cref="InvalidOperationException">Dont </exception>
        /// <exception cref="FormatException">Invalid range or there are the same words</exception>
        public Input GetDataSorce()
        {
            if(!File.Exists(inputFile))
                throw new IOException("Input file does not exist!");
            var serializer = new XmlSerializer(typeof(Input));

            XmlTextReader xml;
            try {
                xml = new XmlTextReader(inputFile);
            }
            catch (Exception e) {
                throw new IOException("Could not read file", e);
            }

            Input res;
            try {
                res = (Input) serializer.Deserialize(xml);
            }
            catch (Exception e) {
                throw new IOException("Could not serialize the file", e);
            }
            if (!res.Range.IsCorrect())
                throw new FormatException("Invalid range");
            if(!res.IsCorrectWords())
                throw new FormatException("There are the same words");
            if(!res.IsMaxLessOrEqualsWordCount())
                throw new FormatException("Words are less than the maximum range value");
            return res;
        }
    }
}
