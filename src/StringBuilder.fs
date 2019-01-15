module StringBuilder

open BenchmarkDotNet.Attributes

type StringBuilder () =

    [<Params(5, 10, 100, 10_000)>]
    member val Size = 0 with get, set

    member val Strings : string array = [| |] with get, set

    [<GlobalSetup>]
    member this.Setup () =
        this.Strings <-
            [|
                let rnd = System.Random ()
                for __ = 1 to this.Size do
                    yield 
                        [|
                            let length = rnd.Next(3, 16)
                            for __ = 1 to length do
                                yield rnd.Next(97, 123) |> char
                        |] |> string
            |]

    [<Benchmark(Baseline = true)>]
    member this.ReduceAdd () =
        this.Strings
        |> Array.reduce (+)


    [<Benchmark>]
    member this.ReduceConcat () =
        this.Strings
        |> Array.reduce (fun a b -> System.String.Concat(a, b))

    [<Benchmark>]
    member this.FoldAdd () =
        this.Strings
        |> Array.fold (fun acc c -> acc + c) System.String.Empty

    [<Benchmark>]
    member this.FoldConcat () =
        this.Strings
        |> Array.fold (fun acc c -> System.String.Concat(acc, c)) System.String.Empty

    [<Benchmark>]
    member this.Concat () =
        this.Strings
        |> System.String.Concat

    [<Benchmark>]
    member this.StringBuilder () =
        (this.Strings
        |> Array.fold (fun (acc : System.Text.StringBuilder) c -> acc.Append c) (System.Text.StringBuilder ())).ToString ()
