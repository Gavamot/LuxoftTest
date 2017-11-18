using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations.Data
{
    class Combination
    {
        private readonly List<string> words = new List<string>();
        private const string seporator = " ";

        public Combination(params string[] words)
        {
            this.words.AddRange(words);
        }

        public int Count => words.Count;

        public void AddWord(string word)
        {
            words.Add(word);
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            if (Count <= 0)
                return "";
            res.Append(words[0]);
            for (int i = 1; i < Count; i++)
            {
                res.Append(seporator);
                res.Append(words[i]);
            }
            return res.ToString();
        }
    }
}
