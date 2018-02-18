module ResultsVsExceptions

open BenchmarkDotNet.Attributes

[<Struct>]
type StructResult<'TSuccess, 'TError> =
| SOk of SuccessValue : 'TSuccess
| SError of ErrorValue : 'TError

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

    [<Benchmark>]
    member __.CatchSelfThrownException () =
        mixedValues
        |> List.map (fun c -> 
            try
                match c with
                | Some c -> c
                | None -> raise (System.NullReferenceException())
            with
            | e -> e.Message    
        )        

    [<Benchmark(Baseline = true)>]
    member __.UseResult () =
        mixedValues
        |> List.map (fun c -> 
            match c with
            | Some c -> c |> Ok
            | None -> "No value!" |> Result.Error
        )

    [<Benchmark>]
    member __.UseStructResult () =
        mixedValues
        |> List.map (fun c -> 
            match c with
            | Some c -> c |> SOk
            | None -> "No value!" |> SError
        )