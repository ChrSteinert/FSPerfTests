module Options

open BenchmarkDotNet.Attributes
open System.Text.RegularExpressions

type OptionValues () =

    let values = [ 1..2000 ]
    let someValues = 
        [ 
            for i in 1..2000 do
                yield i |> Some
        ]
    
    let mixedValues =
        [
            let rnd = System.Random ()
            for i in 1..2000 do
                yield if rnd.Next(0, 101) > 50 then None else i |> Some
        ]

    [<Benchmark(Baseline = true)>]
    member __.Plain () =
        values
        |> List.map ((+) 1)

    [<Benchmark>]
    member __.WithSomes () =
        someValues
        |> List.map (fun c -> 
            match c with
            | Some c -> c + 1 |> Some
            | None -> None )

    [<Benchmark>]
    member __.WithNonesAndSomes () =
        mixedValues
        |> List.map (fun c -> 
            match c with
            | Some c -> c + 1 |> Some
            | None -> None )            

type OptionReferences () =    
    let references = 
        [ 
            for _ in 1..2000 do
                yield Match.Empty
        ]
    
    let someReferences = 
        [
            for _ in 1..2000 do
                yield Match.Empty |> Some
        ]

    let mixedReferences = 
        [
            let rnd = System.Random ()
            for _ in 1..2000 do
                yield if rnd.Next(0, 101) > 50 then None else Match.Empty |> Some
        ]

    [<Benchmark(Baseline = true)>]
    member __.Plain () =
        references
        |> List.map (fun c -> c.Value)

    [<Benchmark>]
    member __.WithSomes () =
        someReferences
        |> List.map (fun c -> 
            match c with
            | Some c -> c.Value |> Some
            | None -> None )

    [<Benchmark>]
    member __.WithNonesAndSomes () =
        mixedReferences
        |> List.map (fun c -> 
            match c with
            | Some c -> c.Value |> Some
            | None -> None )                    
