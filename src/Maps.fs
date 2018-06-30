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
            yield! orderedArray
        }

    let unorderedSeq =
        let rnd = System.Random ()
        seq {
            yield! unorderedArray
        }


    [<Benchmark()>]
    member __.CreateDictOrderedArray () =
        orderedArray 
        |> dict

    [<Benchmark>]
    member __.CreateDictUnorderedArray () =
        unorderedArray 
        |> dict

    [<Benchmark>]
    member __.CreateDictOrderedList () =
        orderedList
        |> dict

    [<Benchmark>]
    member __.CreateDictUnorderedList () =
        unorderedList
        |> dict                        

    [<Benchmark>]
    member __.CreateDictOrderedSeq () =
        orderedSeq
        |> dict

    [<Benchmark>]
    member __.CreateDictUnorderedSeq () =
        unorderedSeq
        |> dict




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

