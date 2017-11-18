using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Combinations.Data
{
    [XmlRoot("input")]
    public class Output
    {
        [XmlArray("combinations")]
        [XmlArrayItem("combination")]
        public List<string> Combinations { get; set; }
    }
}
