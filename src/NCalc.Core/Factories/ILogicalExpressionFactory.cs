using BezierGraph.Dependencies.NCalc.Domain;

namespace BezierGraph.Dependencies.NCalc.Factories;

public interface ILogicalExpressionFactory
{
    public LogicalExpression Create(string expression, ExpressionOptions options = ExpressionOptions.None);
}