module FSPerf

open Argu

open BenchmarkDotNet.Running
open BenchmarkDotNet.Exporters
open ResultsVsExceptions
open System

type CliArguments =
| Generators
| Iterators
| Maps
| Sets
| Options
| ResultsVsExceptions
| SubArrays
    interface IArgParserTemplate 
        with
            member this.Usage =
                match this with
                | c -> "run " + c.ToString () + " benchmarks."
[<EntryPoint>]
let main _ =
    let parser = ArgumentParser.Create<CliArguments> (errorHandler = ProcessExiter(colorizer = function ErrorCode.HelpText -> None | _ -> Some ConsoleColor.Red))
    let args = parser.ParseCommandLine ()
    let benchmarks =
        args.GetAllResults () 
        |> List.fold (fun acc arg -> 
            match arg with
            | Generators -> BenchmarkRunner.Run<Generators.Generators> () :: acc
            | Iterators -> BenchmarkRunner.Run<Iterators.Iterators> () :: acc
            | Maps -> BenchmarkRunner.Run<Maps.Maps> () :: acc
            | Sets -> BenchmarkRunner.Run<Sets.Sets> () :: acc
            | Options -> BenchmarkRunner.Run<Options.OptionValues> () :: BenchmarkRunner.Run<Options.OptionReferences> () :: acc
            | ResultsVsExceptions -> BenchmarkRunner.Run<ResultsVsExceptions.ResultsVsExceptions> () :: acc
            | SubArrays -> BenchmarkRunner.Run<SubArrays.SubArrays> () :: acc
        ) []
    if not (List.isEmpty benchmarks) then
        benchmarks |> List.iter (fun summary -> AsciiDocExporter.Default.ExportToLog(summary, BenchmarkDotNet.Loggers.ConsoleLogger.Default))
    else
        parser.PrintUsage "" |> printfn "%s"
    0