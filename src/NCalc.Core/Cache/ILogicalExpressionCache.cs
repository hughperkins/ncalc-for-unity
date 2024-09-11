using BezierGraph.Dependencies.NCalc.Domain;

namespace BezierGraph.Dependencies.NCalc.Cache;

public interface ILogicalExpressionCache
{
    public bool TryGetValue(string expression, out LogicalExpression? logicalExpression);
    public void Set(string expression, LogicalExpression logicalExpression);
}