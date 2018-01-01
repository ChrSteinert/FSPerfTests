module Sets

open BenchmarkDotNet.Attributes

type Sets () =

    let array = [| 1..2000 |]
    let list = [ 1..2000 ]
    let seq = seq { 1..2000 }

    [<Benchmark(Baseline = true)>]
    member __.CreateSetArray () =
        array
        |> set

    [<Benchmark>]
    member __.CreateSetList () =
        list
        |> set
        
    [<Benchmark>]
    member __.CreateSetSeq () =
        seq
        |> set
