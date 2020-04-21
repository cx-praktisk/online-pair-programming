module ``When using Norwegian Scrabble federation dictionary``

open Xunit
open FsUnit.Xunit
open WordChains.FindWordChains
open WordChains

let inDictionary : string list =
    let options = CommandLineOptions (DictionaryFile = "norwegian-scrabble-federation-dictionary.txt");
    options.InDictionary

// You can skip facts, by including a Skip parameter to the [<Fact(...)>] attribute.
// To start executing a skipped fact, you simply change the attribute back to [<Fact>]
[<Fact(Skip="this until you want to test spesific words against the scrabble dictionary")>]
let ``Should find specific word chain and display result`` () =
    let options =
        CommandLineOptions (
            DictionaryFile = "norwegian-scrabble-federation-dictionary.txt",
            From = "ABER",
            To = "ABBA",
            Distance = 1)

    Program.findWordChain options |> should equal 0

// You can also skip theories. Again you can execute the theory be changing the attribute to [<Theory>]
[<Theory(Skip="this until you think you've got a complete solution")>]
[<InlineData("ABER", "ABBA")>]
[<InlineData("ENDER", "AKKAR")>]
[<InlineData("TENKE", "BANJO")>]
[<InlineData("SOMMER", "BOKMÅL")>]
let ``Should find word chain with one letter distance`` (fromWord : string) (toWord : string) =
    wordChain inDictionary fromWord toWord 1
    |> should not' (be Empty)

[<Theory(Skip = "this until you think you've got a complete solution")>]
[<InlineData("OVERINGENIØRENE", "OLIGARKISTSKHET", 1)>]
let ``Should not find word chain`` (fromWord : string) (toWord : string) (withDistance : int) =
    wordChain inDictionary fromWord toWord withDistance
    |> should be Empty

[<Theory(Skip = "this until you have implemented variable distance between words")>]
[<InlineData("SOMMER", "BOKMÅL", 1)>]
[<InlineData("PARKETT", "AGITERE", 3)>]
[<InlineData("ENDETARMSÅPNINGEN", "HELHETSTENKNINGER", 7)>]
let ``Should find word chain`` (fromWord : string) (toWord : string) (withDistance : int) =
    wordChain inDictionary fromWord toWord withDistance
    |> should not' (be Empty)
