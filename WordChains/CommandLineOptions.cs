using System.IO;
using System.Linq;
using CommandLine;

namespace WordChains
{
    public class CommandLineOptions
    {
        [Value(0, MetaName = "dictionary file", Required = true, HelpText = "A dictionary file, containing a collection of words, with one single word on every line.")]
        public string DictionaryFile { get; set; }

        [Option('f', "from", Default = "ABER", HelpText = "The word you want to start the word chain with.")]
        public string From { get; set; }

        [Option('t', "to", Default = "ABBA", HelpText = "The word you want to end the word chain with.")]
        public string To { get; set; }

        [Option('d', "distance", Default = 1, HelpText = "The distance, i.e. the number of letters that differ, between each word in the word chain.")]
        public int Distance { get; set; }

        public string FromWord => CleanWord(From);

        public string ToWord => CleanWord(To);

        public string[] Dictionary =>
            File
                .ReadLines(DictionaryFile)
                .Where(word => !string.IsNullOrWhiteSpace(word))
                .Select(word => CleanWord(word))
                .ToArray();

        private string CleanWord(string word) => word.ToUpper().Trim();
    }
}
