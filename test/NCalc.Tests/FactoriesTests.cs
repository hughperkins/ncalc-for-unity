using BezierGraph.Dependencies.NCalc.Factories;
using BezierGraph.Dependencies.NCalc.Tests.Fixtures;

namespace BezierGraph.Dependencies.NCalc.Tests;

[Trait("Category", "DependencyInjection")]
public class FactoriesTests(FactoriesFixture fixture) : IClassFixture<FactoriesFixture>
{
    private readonly IExpressionFactory _expressionFactory = fixture.ExpressionFactory;
    private readonly ILogicalExpressionFactory _logicalExpressionFactory = fixture.LogicalExpressionFactory;

    [Fact]
    public void Expression_From_Factory_Should_Evaluate()
    {
        Assert.Equal(4, _expressionFactory.Create("2+2").Evaluate());
    }

    [Fact]
    public void Logical_Expression_From_Factory_Should_Evaluate()
    {
        Assert.Equal(4, _expressionFactory.Create(_logicalExpressionFactory.Create("2+2")).Evaluate());
    }
}