Online pair programming
=======================
_Workshop on online pair programming, using VS Code Live Share._

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

TODO: Work in progress
----------------------
* Should have some on general VS Code and C# usage.
* Document how to use the test project.
    - Focus on doing this inside of VS Code.
* Document how to use the console application.
* Should have some on setting up Live Share.
* Should have something on how to do pair programming.
* Strip back implementation and tests to a good starting point for participants.