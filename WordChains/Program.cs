using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;

namespace WordChains
{
    public class Program
    {
        public static int Main(string[] args) =>
            Parser.Default
                .ParseArguments<CommandLineOptions>(args)
                .MapResult(FindWordChain, errs => 1);

        public static int FindWordChain(CommandLineOptions options)
        {
            var wordChain = options.Dictionary
                .FindWordChain(
                    fromWord: options.FromWord,
                    toWord: options.ToWord,
                    withDistance: options.Distance);

            return DisplayResult(options, wordChain);
        }

        public static int DisplayResult(CommandLineOptions options, IEnumerable<string> wordChain)
        {
            if (wordChain == null)
            {
                Console.WriteLine($"No word chain from { options.FromWord } to { options.ToWord } found :-(");

                return -1;
            }

            Console.WriteLine($"Found word chain from { options.FromWord } to { options.ToWord }!");
            Console.WriteLine($"  Chain length: { wordChain.Count() }");
            Console.WriteLine($"  Word chain: { wordChain.ToDisplayString() }");

            return 0;
        }
    }
}
