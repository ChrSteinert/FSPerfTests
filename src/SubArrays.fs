module SubArrays

open System

open BenchmarkDotNet.Attributes

type SubArrays () =

    let array = 
        let rnd = Random ()
        Array.init 10000 (fun _ -> rnd.Next () |> byte)

    [<Benchmark>]
    member __.Indexer () =
        array.[5000..5999]

    [<Benchmark(Baseline = true)>]
    member __.CopyTo () =
        let target : byte array = Array.zeroCreate 1000
        for i = 5000 to 5999 do
            target.[i - 5000] = array.[i]
        target