using FuncProgramming.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuncProgramming
{
    public class TextHelper
    {
        public Tuple<string, int>[] GetMostFrequentWords(string text, int count)
        {
            return Regex.Split(text, @"\W+")
                .Where(word => word != "")
                .GroupBy(word => word.ToLower())
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key.ToLower())
                .Take(count)
                .Select(x => Tuple.Create(x.Key, x.Count()))
                .ToArray();
        }

        public ILookup<string, int> BuildInvertedIndex(Document[] documents)
        {
            return documents.SelectMany(x => Regex.Split(x.Text.ToLower(), @"\W+")
                                .Where(y => y != "")
                                .Distinct()
                                .Select(y => (word: y, x.Id)))
                            .ToLookup(x => x.word, x => x.Id);
        }

        public ILookup<string, int> GetIndex()
        {
            Document[] documents =
{
                new Document {Id = 1, Text = "Hello world!"},
                new Document {Id = 2, Text = "World, world, world... Just words..."},
                new Document {Id = 3, Text = "Words — power"},
                new Document {Id = 4, Text = ""}
            };

            var index = BuildInvertedIndex(documents);
            return index;
        }
    }
}
