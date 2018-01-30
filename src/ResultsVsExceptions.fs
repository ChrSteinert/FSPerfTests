module ResultsVsExceptions

open BenchmarkDotNet.Attributes

type ResultsVsExceptions () =

    let mixedValues =
        [
            let rnd = System.Random ()
            for i in 1..2000 do
                yield if rnd.Next(0, 101) > 50 then None else i.ToString () |> Some
        ]

    [<Benchmark>]
    member __.CatchExceptions () =
        mixedValues
        |> List.map (fun c -> 
            try
                c.Value
            with
            | e -> e.Message    
        )

    [<Benchmark(Baseline = true)>]
    member __.UseResult () =
        mixedValues
        |> List.map (fun c -> 
            match c with
            | Some c -> c |> Ok
            | None -> "No value!" |> Error
        )