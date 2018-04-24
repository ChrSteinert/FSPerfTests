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

    [<Benchmark>]
    member __.Copy () =
        let target : byte array = Array.zeroCreate 1000
        System.Array.Copy(array, 5000, target, 0, 1000)

    [<Benchmark(Baseline = true)>]
    member __.ForCopy () =
        let target : byte array = Array.zeroCreate 1000
        for i = 5000 to 5999 do
            target.[i - 5000] = array.[i]
        target