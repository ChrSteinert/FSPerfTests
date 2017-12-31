module FSPerf

open System

open BenchmarkDotNet.Running
open BenchmarkDotNet.Exporters

[<EntryPoint>]
let main _ =
    let summary = BenchmarkRunner.Run<Generators.Generators> ()
    let summary2 = BenchmarkRunner.Run<Iterators.Iterators> ()
    AsciiDocExporter.Default.ExportToLog(summary, BenchmarkDotNet.Loggers.ConsoleLogger.Default)
    AsciiDocExporter.Default.ExportToLog(summary2, BenchmarkDotNet.Loggers.ConsoleLogger.Default)
    0