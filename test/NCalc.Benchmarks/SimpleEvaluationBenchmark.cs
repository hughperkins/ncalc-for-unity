using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BezierGraph.Dependencies.NCalc.Factories;
using BezierGraph.Dependencies.NCalc.Handlers;

namespace BezierGraph.Dependencies.NCalc.Benchmarks;

[RankColumn]
[CategoriesColumn]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class SimpleEvaluationBenchmark
{
    private Expression Expression { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var logicalExpression = LogicalExpressionFactory.Create("pi == 3.14 || 'Chers' == name");
        var expression = new Expression(logicalExpression)
        {
            Parameters =
            {
                ["name"] = "Chers"
            }
        };

        expression.EvaluateParameter += delegate (string name, ParameterArgs args)
        {
            if (name == "pi")
                args.Result = 3.14;
        };

        Expression = expression;
    }

    [Benchmark]
    public object SimpleEvaluation()
    {
        return Expression.Evaluate();
    }
}