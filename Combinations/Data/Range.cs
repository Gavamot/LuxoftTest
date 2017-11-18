using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Combinations.Data
{
    public class Range
    {
        [XmlElement("min")]
        public int Min { get; set; }
        [XmlElement("max")]
        public int Max { get; set; }

        public bool IsCorrect()
        {
            return Min > 0 && Max > 0 && Min <= Max;
        }

        [TestFixture]
        class RangeTest
        {
            [Test]
            [TestCase(-1, 1, false)]
            [TestCase(2, 1, false)]
            [TestCase(0, 0, false)]
            [TestCase(0, 1, false)]
            [TestCase(1, 0, false)]
            [TestCase(1, 1, true)]
            [TestCase(43, 45, true)]
            public void IsCorrectTest(int min, int max, bool actual)
            {
                var range = new Range { Min = min, Max = max };
                bool res = range.IsCorrect();
                Assert.AreEqual(actual, res);
            }
        }
    }
}
