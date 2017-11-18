using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Combinations.Data
{
    [XmlRoot("input")]
    public class Input
    {
        [XmlElement("range")]
        public Range Range { get; set; }

        [XmlArray("words")]
        [XmlArrayItem("word")]
        public List<string> Words { get; set; } = new List<string>();

        public bool IsCorrectWords()
        {
            for (int i = 0, iMax = Words.Count - 1; i < iMax; i++)
            {
                string word = Words[i];
                for (int j = i + 1, jMax = iMax + 1; j < jMax; j++)
                {
                    if (word == Words[j])
                        return false;
                }
            }
            return true;
        }

        public bool IsMaxLessOrEqualsWordCount()
        {
            return Words.Count >= Range.Max;
        }

        [TestFixture]
        class InputTest
        {
            [Test]
            [TestCase(false, 1)]
            [TestCase(true, 0)]
            [TestCase(true, 1, "first")]
            [TestCase(true, 2, "first", "second", "thrid")]
            [TestCase(true, 3, "first1", "first2", "second")]
            [TestCase(false, 4, "firs1t", "second", "first2")]
            public void IsMaxLessOrEqualsWordCountTest(bool actual, int max, params string[] words)
            {
                var range = new Input { Words = words.ToList(), Range = new Range { Max = max } };
                bool res = range.IsMaxLessOrEqualsWordCount();
                Assert.AreEqual(actual, res);
            }

            [Test]
            [TestCase(true)]
            [TestCase(true, "first")]
            [TestCase(true, "first", "second", "thrid")]
            [TestCase(false, "first", "first", "second")]
            [TestCase(false, "first", "second", "first")]
            [TestCase(false, "first", "first", "first")]
            public void IsCorrectWordsTest(bool actual, params string[] words)
            {
                var range = new Input { Words = words.ToList() };
                bool res = range.IsCorrectWords();
                Assert.AreEqual(actual, res);
            }
        }
    }
}
