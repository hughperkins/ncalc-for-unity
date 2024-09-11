using BezierGraph.Dependencies.NCalc.Domain;
using BezierGraph.Dependencies.NCalc.Visitors;

namespace BezierGraph.Dependencies.NCalc.Services;

/// <inheritdoc cref="IAsyncEvaluationService"/>
public class AsyncEvaluationService : IAsyncEvaluationService
{
    public ValueTask<object?> EvaluateAsync(LogicalExpression expression, AsyncExpressionContext context)
    {
        var visitor = new AsyncEvaluationVisitor(context);
        return expression.Accept(visitor);
    }
}