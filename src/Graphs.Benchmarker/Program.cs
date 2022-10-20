using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run(typeof(Graphs.Benchmarker.Sorting));