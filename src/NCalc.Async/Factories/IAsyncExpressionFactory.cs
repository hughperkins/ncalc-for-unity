using BezierGraph.Dependencies.NCalc.Domain;

namespace BezierGraph.Dependencies.NCalc.Factories;

public interface IAsyncExpressionFactory
{
    public AsyncExpression Create(
        string expression,
        AsyncExpressionContext? expressionContext = null);

    public AsyncExpression Create(
        LogicalExpression logicalExpression,
        AsyncExpressionContext? expressionContext = null);
}