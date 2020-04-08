Online pair programming
=======================
_Workshop on online pair programming, using VS Code Live Share._

TODO: Work in progress
----------------------
* Should have some on general VS Code and C# usage.
* Document how to use the test project.
    - Focus on doing this inside of VS Code.
* Document how to use the console application.
* Should have some on setting up Live Share.
* Should have something on how to do pair programming.
    - Write code in _FindWordChains.cs_ and write tests in _WhenPairProgramming.cs_.
    - Start by making `DistanceTo(...)` work.
    - Switch when going from writing a test to making it pass.
* Everyone will probably want to create their own [hangouts-sessions](https://meet.google.com/) to talk while they code. This should ble documented as well.

Installation Guide
------------------
_To partake in the workshop, you'll need to have the .NET Core 3.1 SDK, and VS Code with the C# and Live Share extensions._

### .NET Core 3.1 SDK
_If you already have .NET Core installed, you can check the version with `dotnet --version`._

You can get .NET Core from the [.NET Core SDK download page](https://www.microsoft.com/net/download). Just follow the instructions for your operating system, and you should be all set.

### VS Code with C# and Live Share extensions
C# can be edited in a number of different editors and IDE's, but since we'll be relying on VS Code Live share in this workshop, you'll have to use VS Code. You can grab a copy of VS Code from the [VS Code download page](https://code.visualstudio.com/).

To make it a little bit easier to work with C#, you also want to get the [C# extension for VS Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

Finally you need to get the [Live Share extension for VS Code](https://marketplace.visualstudio.com/items?itemName=MS-vsliveshare.vsliveshare). In order to use Live Share, you'll also need a GitHub or Microsoft account. If you don't have either, it's quite easy to [create a new GitHub account](https://github.com/join).

Building, running and testing
-----------------------------

### Testing

```shell
$ WordChain.Test> dotnet test

...

Test Run Successful.
Total tests: 6
     Passed: 3
    Skipped: 3
 Total time: 1.2184 Seconds
```

### Running

```shell
$ WordChain> dotnet run
WordChains 1.0.0
Copyright (C) 2020 WordChains

ERROR(S):
  A required value not bound to option name is missing.

  -f, --from                  (Default: ABER) The word you want to start the word chain with.

  -t, --to                    (Default: ABBA) The word you want to end the word chain with.

  -d, --distance              (Default: 1) The distance, i.e. the number of letters that differ, between
                              each word in the word chain.

  --help                      Display this help screen.

  --version                   Display version information.

  dictionary file (pos. 0)    Required. A dictionary file, containing a collection of words, with one
                              single word on every line.
```

```shell
$ WordChain> dotnet run -- ../norwegian-scrabble-federation-dictionary.txt -f abba -t aber
Found word chain from ABBA to ABER!
  Chain length: 33
  Word chain: ABBA -> ALBA -> ALFA -> ALKA -> AKKA -> AKKE -> AKME -> AKNE -> AGNE -> AGNA -> AGGA -> ANGA -> ANDA -> ANDE -> ANGE -> ALGE -> ALGI -> ANGI -> ANGL -> ANAL -> APAL -> ASAL -> ATAL -> AVAL -> AVAR -> AFAR -> AGAR -> AGAM -> AGAT -> AGET -> AGEN -> AGER -> ABER
```

```shell
$ WordChain> dotnet run -- ../norwegian-scrabble-federation-dictionary.txt -f parkett -t agitere -d 3
Found word chain from PARKETT to AGITERE!
  Chain length: 12
  Word chain: PARKETT -> BAKKETE -> ANKRETE -> AFARENE -> ACIDENE -> ADAMENE -> ACYLENE -> ADJØENE -> AETAENE -> ADOBENE -> AGAMENE -> AGITERE
```

Word Chains
-----------
_Description borrowed from [http://codekata.com/](http://codekata.com/kata/kata19-word-chains/)._

There’s a type of puzzle where the challenge is to build a chain of words, starting with one particular word and ending with another. Successive entries in the chain must all be real words, and each can differ from the previous word by just one letter. For example, you can get from "CAT" to "DOG" using the following chain.

```
CAT -> COT -> COG -> DOG
```

The objective of this kata is to write a program that accepts start and end words and, using words from the dictionary, builds a word chain between them. For added programming fun, return the shortest word chain that solves each puzzle. For example, you can turn "LEAD" into "GOLD" in four steps (LEAD, LOAD, GOAD, GOLD), and "RUBY" into "CODE" in six steps (RUBY, RUBS, ROBS, RODS, RODE, CODE).

Once your code works, try timing it. Does it take less than a second for the above examples given a decent-sized word list? And is the timing the same forwards and backwards (so "LEAD" into "GOLD" takes the same time as "GOLD" into "LEAD")?

### Where should you start?
It's a good idea to start with creating a function that finds the distance between two words. I.e. (ABBA, ALBA) -> 1.

Then you might want to find all words with a given distance in a sequence of words. I.e. (ABBA, [ALBA, SALT, KATT, ABVA], 1) -> [ALBA, ABVA], since both ALBA and ABVA is a single letter apart from ABBA.

Find a chain between two words in the word-list. I.e. (ABBA, [ALBA, SALT, KATT, ABVA]) -> ABBA => ALBA.

Some problems that we might want to give people a test for.
* Cycles: You might end up just going between a couple of words.

### When you have a working solution
* Can you find the shortest chain between the words?
* Can you make the code faster?
