module ``When pair programming``

open Xunit
open FsUnit.Xunit
open WordChains.FindWordChains

// Simple tests are called facts in xUnit, and are public methods marked with a [Fact] attribute.
[<Fact>]
let ``Distance between CAT and CUT should be 1`` () =
    distanceBetween "CAT" "CUT"
    |> should equal 1 // This test project is using FsUnit (https://fsprojects.github.io/FsUnit/xUnit.html).

// xUnit also supports theories, which are parameterized tests.
// They are declared using a [Theory] attribute.
// Every set of parameters in an [InlineData(...)] attribute, is a single test case.
[<Theory>]
[<InlineData("CAT", "CUT", 1)>]
[<InlineData("CAT", "PAT", 1)>]
let ``Distance between`` (aWord : string) (anotherWord : string) (expectedDistance : int) =
    distanceBetween aWord anotherWord
    |> should equal expectedDistance
