# F# Performance Tests
This repo contains benchmarks of common F# operations. These operations can be done in multiple ways - the target is to get a feeling for how the different ways compare.

## Generators

Generators are ways to construct values (arrays, list, sequences) via different ways, like literals, comprehensions etc. 

|                     Method |        Mean |     Error |     StdDev |      Median | Scaled | ScaledSD |
|--------------------------- |------------:|----------:|-----------:|------------:|-------:|---------:|
|              SequenceYield | 1,161.46 ns | 39.790 ns | 112.878 ns | 1,147.61 ns |  49.63 |     8.00 |
|     SequenceComprehensions |   709.04 ns | 32.853 ns |  94.788 ns |   674.74 ns |  30.30 |     5.63 |
|           SequenceForYield | 1,418.76 ns | 47.228 ns | 139.253 ns | 1,399.98 ns |  60.63 |     9.81 |
| SequenceForYieldWithBraces | 1,910.63 ns | 61.413 ns | 175.216 ns | 1,927.70 ns |  81.65 |    12.90 |
|               ListLiterals |   285.30 ns | 13.820 ns |  40.749 ns |   277.91 ns |  12.19 |     2.35 |
|          ListComprehension |   567.20 ns | 17.427 ns |  49.720 ns |   563.73 ns |  24.24 |     3.77 |
|               ListForYield |   993.16 ns | 26.127 ns |  76.214 ns |   994.38 ns |  42.44 |     6.36 |
|     ListForYieldWithBraces | 1,607.90 ns | 55.440 ns | 159.067 ns | 1,594.11 ns |  68.71 |    11.15 |
|               ArrayLiteral |    23.78 ns |  1.021 ns |   3.010 ns |    23.44 ns |   1.00 |     0.00 |
|         ArrayComprehension |   759.02 ns | 15.359 ns |  38.814 ns |   752.98 ns |  32.44 |     4.49 |
|              ArrayForYield | 1,298.61 ns | 45.958 ns | 133.333 ns | 1,271.96 ns |  55.50 |     9.14 |
|    ArrayForYieldWithBraces | 1,495.82 ns | 31.780 ns |  32.636 ns | 1,485.60 ns |  63.92 |     8.33 |


## Iterators

Iterator benchmarks take different ways of accessing values in an array, list, or sequence with differnent means, like iterating an array by using the `Seq` module.

|            Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |
|------------------ |----------:|----------:|----------:|-------:|---------:|
| ArrayIterateArray |  2.503 us | 0.0276 us | 0.0245 us |   1.00 |     0.00 |
|   ArrayIterateSeq | 26.155 us | 0.2776 us | 0.2461 us |  10.45 |     0.14 |
|   ListIterateList |  6.497 us | 0.0130 us | 0.0115 us |   2.60 |     0.02 |
|    ListIterateSeq | 33.716 us | 0.6896 us | 0.6450 us |  13.47 |     0.28 |
|     SeqIterateSeq | 24.692 us | 0.1712 us | 0.1518 us |   9.86 |     0.11 |

## Options

Using plain values or the option module.

### Values

|            Method |     Mean |     Error |    StdDev | Scaled | ScaledSD |
|------------------ |---------:|----------:|----------:|-------:|---------:|
|             Plain | 33.56 us | 0.8040 us | 0.6713 us |   1.00 |     0.00 |
|         WithSomes | 76.11 us | 0.6257 us | 0.5546 us |   2.27 |     0.05 |
| WithNonesAndSomes | 74.60 us | 0.8899 us | 0.8324 us |   2.22 |     0.05 |

### References

|            Method |     Mean |     Error |    StdDev | Scaled | ScaledSD |
|------------------ |---------:|----------:|----------:|-------:|---------:|
|             Plain | 56.23 us | 0.3614 us | 0.3380 us |   1.00 |     0.00 |
|         WithSomes | 89.58 us | 0.8282 us | 0.7747 us |   1.59 |     0.02 |
| WithNonesAndSomes | 81.37 us | 0.7442 us | 0.6961 us |   1.45 |     0.01 |

## Maps

Creation of `Map`s and `dict`s from different types of inputs - lists, arrays and sequences - ordered and unordered.

|                   Method |       Mean |      Error |     StdDev | Scaled | ScaledSD |
|------------------------- |-----------:|-----------:|-----------:|-------:|---------:|
|   CreateDictOrderedArray |   140.3 us |   2.521 us |   4.609 us |   0.06 |     0.00 |
| CreateDictUnorderedArray |   161.3 us |   1.757 us |   1.372 us |   0.07 |     0.00 |
|    CreateDictOrderedList |   160.8 us |   5.270 us |  15.121 us |   0.07 |     0.01 |
|  CreateDictUnorderedList |   170.7 us |   3.161 us |   2.957 us |   0.08 |     0.00 |
|     CreateDictOrderedSeq |   137.2 us |   2.235 us |   1.981 us |   0.06 |     0.00 |
|   CreateDictUnorderedSeq |   160.1 us |   1.445 us |   1.281 us |   0.07 |     0.00 |
|    CreateMapOrderedArray | 2,186.3 us |  58.578 us |  48.915 us |   1.00 |     0.00 |
|  CreateMapUnorderedArray | 3,106.1 us | 237.683 us | 700.814 us |   1.42 |     0.32 |
|     CreateMapOrderedList | 3,336.1 us | 230.302 us | 679.052 us |   1.53 |     0.31 |
|   CreateMapUnorderedList | 3,640.4 us | 123.499 us | 360.253 us |   1.67 |     0.17 |
|      CreateMapOrderedSeq | 4,090.0 us | 229.331 us | 676.187 us |   1.87 |     0.31 |
|    CreateMapUnorderedSeq | 4,175.0 us | 171.565 us | 500.464 us |   1.91 |     0.23 |


## Sets

Creation of sets from different types of inputs - lists, arrays and sequences - ordered and unordered.

|         Method |     Mean |     Error |    StdDev | Scaled | ScaledSD |
|--------------- |---------:|----------:|----------:|-------:|---------:|
| CreateSetArray | 2.988 ms | 0.0594 ms | 0.0751 ms |   1.00 |     0.00 |
|  CreateSetList | 2.907 ms | 0.0563 ms | 0.0752 ms |   0.97 |     0.03 |
|   CreateSetSeq | 2.995 ms | 0.0587 ms | 0.0861 ms |   1.00 |     0.04 |

## Results vs. Exception Messages

Using `Result<'TSuccess, 'TError>` vs. catching `Exception`s and using the message.

|                   Method |         Mean |        Error |       StdDev | Scaled | ScaledSD |
|------------------------- |-------------:|-------------:|-------------:|-------:|---------:|
|          CatchExceptions | 122,486.5 us | 2,436.154 us | 5,646.158 us | 691.56 |    35.73 |
| CatchSelfThrownException |  72,435.1 us | 1,386.523 us | 1,541.116 us | 408.97 |    12.97 |
|                UseResult |     177.2 us |     3.508 us |     4.436 us |   1.00 |     0.00 |
|          UseStructResult |     177.1 us |     3.433 us |     3.673 us |   1.00 |     0.03 |

## Sub Arrays

Create an array that is a partial copy of the source array.

|             Method |       Mean |     Error |    StdDev | Scaled | ScaledSD |
|------------------- |-----------:|----------:|----------:|-------:|---------:|
|            Indexer | 1,078.7 ns | 19.829 ns | 18.548 ns |   1.05 |     0.02 |
| CopyCreateInstance |   175.3 ns |  3.714 ns |  3.474 ns |   0.17 |     0.00 |
|     CopyZeroCreate |   139.9 ns |  2.787 ns |  2.862 ns |   0.14 |     0.00 |
|            ForCopy | 1,031.5 ns | 17.919 ns | 15.885 ns |   1.00 |     0.00 |

## Running Benchmarks

To run all benchmarks from VS Code simply use the task `Run Benchmark`.

### CLI Arguments

Specific benchmarks can be run with specific CLI arguments. See `--help` for all available switches.
