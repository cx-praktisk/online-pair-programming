module WordChains.Program

open WordChains.FindWordChains
open CommandLine

let displayResult (options : CommandLineOptions) (wordChain : string list) : int =
    if List.isEmpty wordChain then
        printfn "No word chain from %s to %s found :-(" options.FromWord options.ToWord
        -1
    else
        printfn "Found word chain from %s to %s!" options.FromWord options.ToWord
        printfn "  Chain length: %d" (List.length wordChain)
        printfn "  Word chain: %s" (System.String.Join (" -> ", wordChain))
        0

let findWordChain (options : CommandLineOptions) : int =
    wordChain options.InDictionary options.FromWord options.ToWord options.Distance
    |> displayResult options

[<EntryPoint>]
let main argv =
    Parser.Default
        .ParseArguments<CommandLineOptions>(argv)
        .MapResult(findWordChain, (fun errs -> 1));