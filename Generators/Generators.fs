module Generators

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Diagnosers

[<MemoryDiagnoser>]
type Generators () =

    [<Benchmark>]
    member __.SequenceYield () =
        seq {
            yield 1
            yield 2
            yield 3
            yield 4
            yield 5
            yield 6
            yield 7
            yield 8
            yield 9
            yield 10
            yield 11
            yield 12
        }
        |> Seq.toArray

    [<Benchmark>]
    member __.SequenceComprehensions () =
        seq { 1..12 }
        |> Seq.toArray

    [<Benchmark>]
    member __.SequenceForYield () =
        seq { 
            for i in 1..12 do
                yield i
        }
        |> Seq.toArray

    [<Benchmark>]
    member __.SequenceForYieldWithBraces () =
        seq { 
            for i in [1..12] do
                yield i
        }
        |> Seq.toArray
    
    [<Benchmark>]
    member __.ListLiterals () =
        [ 1;2;3;4;5;6;7;8;9;10;11;12 ]
        |> List.toArray
    
    [<Benchmark>]
    member __.ListComprehension () =
        [ 1..12 ]
        |> List.toArray
    
    [<Benchmark>]
    member __.ListForYield () =
        [ 
            for i in 1..12 do
                yield i
        ]
        |> List.toArray

    [<Benchmark>]
    member __.ListForYieldWithBraces () =
        [ 
            for i in [1..12] do
                yield i
        ]
        |> List.toArray

    [<Benchmark(Baseline = true)>]
    member __.ArrayLiteral () =
        [| 1;2;3;4;5;6;7;8;9;10;11;12 |]

    [<Benchmark>]
    member __.ArrayComprehension () =
        [| 1..12 |]
    
    [<Benchmark>]
    member __.ArrayForYield () =
        [|
            for i in 1..12 do
                yield i
        |]

    [<Benchmark>]
    member __.ArrayForYieldWithBraces () =
        [|
            for i in [1..12] do
                yield i
        |]

[<EntryPoint>]
let main _ =
    BenchmarkRunner.Run<Generators> ()
    |> ignore
    0 // return an integer exit code
