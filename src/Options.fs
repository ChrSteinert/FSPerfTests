module Options

open BenchmarkDotNet.Attributes

type Options () =

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
    
        