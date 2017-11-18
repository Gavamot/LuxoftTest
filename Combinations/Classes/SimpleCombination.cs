using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Combinations.Data;
using Combinations.Extension;
using Combinations.Interfaces;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Combinations.Classes
{
    class SimpleCombination : ICombination
    {
        public Output GetResult(Input input)
        {
            var combinations = new List<Combination>();
            for (int i = input.Range.Min; i <= input.Range.Max; i++)
            {
                var c = GetCombinationBrutforce(input.Words, i);
                combinations.AddRange(c); 
            }
            return new Output{ Combinations = combinations.ToListString() };
        }

        private IEnumerable<Combination> GetCombinationBrutforce(List<string> words, int countSymbols)
        {
            return words.Combinations(countSymbols)
                .Select(x=> new Combination(x.ToArray()));
        }

        [TestFixture]
        class SimpleCombinationTest
        {
            private Input input;
            private List<string> words0 = new List<string>();
            private List<string> words1 = new List<string>
            {
                "A"
            };
            private List<string> words2 = new List<string>
            {
                "A", "B"
            };
            private List<string> words6 = new List<string>
            {
                "A", "B", "C", "D", "E", "F"
            };

            [SetUp]
            public void Init()
            {
                input = new Input();
            }

            // TODO: make same tests
        }

        
    }
}
