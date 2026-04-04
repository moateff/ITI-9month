```

BenchmarkDotNet v0.15.8, Linux Ubuntu 22.04.5 LTS (Jammy Jellyfish)
Intel Core i5-5200U CPU 2.20GHz (Max: 2.50GHz) (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET SDK 10.0.102
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                | Mean       | Error      | StdDev     | Gen0     | Gen1    | Allocated |
|---------------------- |-----------:|-----------:|-----------:|---------:|--------:|----------:|
| GetAllProducts_ADO    |   3.565 ms |  0.0654 ms |  0.1110 ms | 101.5625 | 46.8750 | 387.26 KB |
| GetAllProducts_Dapper |   3.692 ms |  0.0729 ms |  0.0896 ms | 109.3750 | 54.6875 | 450.03 KB |
| GetAllProducts_EF     |   3.569 ms |  0.0707 ms |  0.1275 ms | 171.8750 |       - | 265.26 KB |
| InsertProduct_ADO     |  42.178 ms |  4.0217 ms | 11.3432 ms |        - |       - |    2.5 KB |
| InsertProduct_Dapper  |  36.662 ms |  2.2681 ms |  6.3225 ms |        - |       - |   3.19 KB |
| InsertProduct_EF      |         NA |         NA |         NA |       NA |      NA |        NA |
| UpdateProduct_ADO     | 113.941 ms | 11.0936 ms | 31.2898 ms |        - |       - |   2.52 KB |
| UpdateProduct_Dapper  |  69.334 ms |  3.1099 ms |  8.7204 ms |        - |       - |   2.74 KB |
| UpdateProduct_EF      | 106.402 ms |  9.0226 ms | 25.7420 ms |        - |       - |  19.09 KB |
| DeleteProduct_ADO     |   1.604 ms |  0.0310 ms |  0.0544 ms |        - |       - |   1.71 KB |
| DeleteProduct_Dapper  |   1.639 ms |  0.0315 ms |  0.0410 ms |        - |       - |   2.28 KB |
| DeleteProduct_EF      |   1.197 ms |  0.0228 ms |  0.0202 ms |   5.8594 |       - |   9.06 KB |

Benchmarks with issues:
  DbBenchmarks.InsertProduct_EF: DefaultJob
