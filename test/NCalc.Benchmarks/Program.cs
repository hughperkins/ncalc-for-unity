using BenchmarkDotNet.Running;
using BezierGraph.Dependencies.NCalc.Benchmarks;

BenchmarkRunner.Run<LogicalExpressionFactoryBenchmark>(null, args);
BenchmarkRunner.Run<SimpleEvaluationBenchmark>(null, args);
BenchmarkRunner.Run<EvaluateVsLambdaBenchmark>(null, args);