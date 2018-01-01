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

## Maps

Creation of maps from different types of inputs - lists, arrays and sequences - ordered and unordered.

|                   Method|      Mean|      Error|     StdDev|    Median|  Scaled|  ScaledSD |
|-------------------------|---------:|----------:|----------:|---------:|-------:|----------:|
|    CreateMapOrderedArray|  3.547 ms|  0.1266 ms|  0.3733 ms|  3.567 ms|    1.00|      0.00 |
|  CreateMapUnorderedArray|  3.638 ms|  0.1378 ms|  0.4019 ms|  3.467 ms|    1.04|      0.15 |
|     CreateMapOrderedList|  3.138 ms|  0.0625 ms|  0.1220 ms|  3.108 ms|    0.89|      0.10 |
|   CreateMapUnorderedList|  3.461 ms|  0.1025 ms|  0.2925 ms|  3.355 ms|    0.99|      0.13 |
|      CreateMapOrderedSeq|  3.362 ms|  0.0662 ms|  0.1574 ms|  3.333 ms|    0.96|      0.11 |
|    CreateMapUnorderedSeq|  3.492 ms|  0.0696 ms|  0.0953 ms|  3.499 ms|    1.00|      0.10 |

## Sets

Creation of sets from different types of inputs - lists, arrays and sequences - ordered and unordered.

|         Method |     Mean |     Error |    StdDev | Scaled | ScaledSD |
|--------------- |---------:|----------:|----------:|-------:|---------:|
| CreateSetArray | 2.988 ms | 0.0594 ms | 0.0751 ms |   1.00 |     0.00 |
|  CreateSetList | 2.907 ms | 0.0563 ms | 0.0752 ms |   0.97 |     0.03 |
|   CreateSetSeq | 2.995 ms | 0.0587 ms | 0.0861 ms |   1.00 |     0.04 |

## Running Benchmarks

To run all benchmarks from VS Code simply use the task `Run Benchmark`.