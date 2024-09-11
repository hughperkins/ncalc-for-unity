// using Microsoft.Extensions.Logging;

namespace BezierGraph.Dependencies.NCalc.Logging;

public static class LoggerMessage
{
    public static Action<ILogger, Exception> Define(LogLevel logLevel, EventId eventId, string message)
    {
        return (logger, exception) => logger.Log(logLevel, eventId, message, exception, (s, e) => s);
    }

    public static Action<ILogger, T1, Exception> Define<T1>(LogLevel logLevel, EventId eventId, string format)
    {
        return (logger, arg1, exception) => logger.Log(logLevel, eventId, format, exception, (s, e) => string.Format(s, arg1));
    }

    public static Action<ILogger, T1, T2, Exception> Define<T1, T2>(LogLevel logLevel, EventId eventId, string format)
    {
        return (logger, arg1, arg2, exception) => logger.Log(logLevel, eventId, format, exception, (s, e) => string.Format(s, arg1, arg2));
    }

    // Add more overloads as needed for different numbers of parameters
}

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class LoggerMessageAttribute : Attribute
{
    public int EventId { get; set; }
    public LogLevel Level { get; set; }
    public required string Message { get; set; }
}

internal static partial class LogMessages
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Information,
        Message = "Expression retrieved from cache: {Expression}")]
    public static void LogRetrievedFromCache(this ILogger logger, string expression) {}

    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Information,
        Message = "Expression added to cache: {Expression}")]
    public static void LogAddedToCache(this ILogger logger, string expression) {}

    [LoggerMessage(
        EventId = 2,
        Level = LogLevel.Information,
        Message = "Expression remove from cache: {Expression}")]
    public static void LogRemovedFromCache(this ILogger logger, string expression) {}

    [LoggerMessage(
        EventId = 3,
        Level = LogLevel.Error,
        Message = "Error creating logical expression: {ExpressionString}")]
    public static void LogErrorCreatingLogicalExpression(this ILogger logger, Exception exception,
        string expressionString)  {}
}