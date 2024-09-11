using Microsoft.Extensions.Logging;
using BezierGraph.Dependencies.NCalc.Cache;
using BezierGraph.Dependencies.NCalc.Domain;
using BezierGraph.Dependencies.NCalc.Exceptions;
using BezierGraph.Dependencies.NCalc.Logging;
using BezierGraph.Dependencies.NCalc.Parser;

namespace BezierGraph.Dependencies.NCalc.Factories;

/// <summary>
/// Class responsible to create <see cref="LogicalExpression"/> objects. Parlot is used for parsing strings.
/// </summary>
public sealed class LogicalExpressionFactory(ILogger<LogicalExpressionFactory> logger) : ILogicalExpressionFactory
{
    private static LogicalExpressionFactory? _instance;

    public static LogicalExpressionFactory GetInstance()
    {
        return _instance ??= new LogicalExpressionFactory(DefaultLoggerFactory.Value.CreateLogger<LogicalExpressionFactory>());
    }

    LogicalExpression ILogicalExpressionFactory.Create(string expression, ExpressionOptions options)
    {
        try
        {
            return Create(expression, options);
        }
        catch (Exception exception)
        {
            logger.LogErrorCreatingLogicalExpression(exception,expression);
            throw new NCalcParserException("Error parsing the expression.", exception);
        }
    }

    public static LogicalExpression Create(string expression, ExpressionOptions options = ExpressionOptions.None)
    {
        var parserContext = new LogicalExpressionParserContext(expression, options);
        var logicalExpression = LogicalExpressionParser.Parse(parserContext);

        return logicalExpression;
    }
}