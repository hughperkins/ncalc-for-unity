using BezierGraph.Dependencies.NCalc.Domain;
using BezierGraph.Dependencies.NCalc.Visitors;

namespace BezierGraph.Dependencies.NCalc.Services;

/// <inheritdoc cref="IEvaluationService"/>
public class EvaluationService : IEvaluationService
{
    public object? Evaluate(LogicalExpression? expression, ExpressionContext context)
    {
        var visitor = new EvaluationVisitor(context);
        return expression?.Accept(visitor);
    }
}