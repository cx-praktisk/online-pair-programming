namespace WordChains

open System.IO;
open CommandLine;

type CommandLineOptions() =
    let isNotNullOrWhiteSpace = System.String.IsNullOrWhiteSpace >> not

    let trimAndUppercase (word : string) : string = word.ToUpper().Trim()

    [<Value(0, MetaName = "dictionary file", Required = true, HelpText = "A dictionary file, containing a collection of words, with one single word on every line.")>]
    member val DictionaryFile = "" with get, set

    [<Option('f', "from", Default = "ABER", HelpText = "The word you want to start the word chain with.")>]
    member val From = "" with get, set

    [<Option('t', "to", Default = "ABBA", HelpText = "The word you want to end the word chain with.")>]
    member val To = "" with get, set

    [<Option('d', "distance", Default = 1, HelpText = "The distance, i.e. the number of letters that differ, between each word in the word chain.")>]
    member val Distance = 1 with get, set

    member this.FromWord = trimAndUppercase this.From

    member this.ToWord = trimAndUppercase this.To

    member this.InDictionary : string list =
        File.ReadLines this.DictionaryFile
        |> List.ofSeq
        |> List.filter isNotNullOrWhiteSpace
        |> List.map trimAndUppercase
