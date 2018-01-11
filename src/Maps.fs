module Maps

open BenchmarkDotNet.Attributes

type Maps () =

    let orderedArray = 
        [| 
            for i in 1..2000 do
                yield i, i
        |]
    let orderedList = 
        [ 
            for i in 1..2000 do
                yield i, i
        ]
    let unorderedArray = 
        let rnd = System.Random ()
        [|
            for _ in 1..2000 do
                yield rnd.Next (), rnd.Next ()
        |]
    let unorderedList =
        let rnd = System.Random ()
        [
            for _ in 1..2000 do
                yield rnd.Next (), rnd.Next ()
        ]
    
    let orderedSeq =
        seq {
            yield orderedArray
        }

    let unorderedSeq =
        let rnd = System.Random ()
        seq {
            yield! unorderedArray
        }

    [<Benchmark(Baseline = true)>]
    member __.CreateMapOrderedArray () =
        orderedArray 
        |> Map

    [<Benchmark>]
    member __.CreateMapUnorderedArray () =
        unorderedArray 
        |> Map

    [<Benchmark>]
    member __.CreateMapOrderedList () =
        orderedList
        |> Map

    [<Benchmark>]
    member __.CreateMapUnorderedList () =
        unorderedList
        |> Map                        

    [<Benchmark>]
    member __.CreateMapOrderedSeq () =
        orderedSeq
        |> Map

    [<Benchmark>]
    member __.CreateMapUnorderedSeq () =
        unorderedSeq
        |> Map                                