using System;
using System.Linq;
using CommandLine;

namespace WordChains
{
    class Program
    {
        private static int ConvertHistoryFile(CommandLineOptions options)
        {
            var actual = options.Dictionary.ChainWithDistanceTo(options.FromWord, options.ToWord, options.Distance);
            var chainLength = actual.Split("->").Count();

            Console.WriteLine($"\nFound chain!\n Chain length: {chainLength}\n Chain: {actual}\n");

            return 0;
        }

        public static int Main(string[] args) =>
            Parser.Default
                .ParseArguments<CommandLineOptions>(args)
                .MapResult(ConvertHistoryFile, errs => 1);
    }
}
