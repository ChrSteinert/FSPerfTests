module Iterators

open BenchmarkDotNet.Attributes

type Iterators () =

    let array = [| 1..2000 |]
    let list = [ 1..2000 ]
    let seq = seq { 1..2000 }

    [<Benchmark(Baseline = true)>]
    member __.ArrayIterateArray () = 
        array
        |> Array.sumBy id

    [<Benchmark>]
    member __.ArrayIterateSeq () =
        array
        |> Seq.sumBy id

    [<Benchmark>]
    member __.ListIterateList () =
        list
        |> List.sumBy id

    [<Benchmark>]
    member __.ListIterateSeq () =
        list
        |> Seq.sumBy id

    [<Benchmark>]
    member __.SeqIterateSeq () =
        seq
        |> Seq.sumBy id
