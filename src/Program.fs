module FSPerf

open BenchmarkDotNet.Running
open BenchmarkDotNet.Exporters

[<EntryPoint>]
let main _ =
    let summary = BenchmarkRunner.Run<Generators.Generators> ()
    let summary2 = BenchmarkRunner.Run<Iterators.Iterators> ()
    let summary3 = BenchmarkRunner.Run<Maps.Maps> ()
    let summary4 = BenchmarkRunner.Run<Sets.Sets> ()
    let summary5 = BenchmarkRunner.Run<Options.Options> ()
    AsciiDocExporter.Default.ExportToLog(summary, BenchmarkDotNet.Loggers.ConsoleLogger.Default)
    AsciiDocExporter.Default.ExportToLog(summary2, BenchmarkDotNet.Loggers.ConsoleLogger.Default)
    AsciiDocExporter.Default.ExportToLog(summary3, BenchmarkDotNet.Loggers.ConsoleLogger.Default)
    AsciiDocExporter.Default.ExportToLog(summary4, BenchmarkDotNet.Loggers.ConsoleLogger.Default)
    AsciiDocExporter.Default.ExportToLog(summary5, BenchmarkDotNet.Loggers.ConsoleLogger.Default)
    0