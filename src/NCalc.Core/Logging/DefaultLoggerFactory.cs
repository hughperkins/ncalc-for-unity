// using Microsoft.Extensions.Logging;
// using UnityEngine;

namespace BezierGraph.Dependencies.NCalc.Logging;

public enum LogLevel
{
    Trace = 0,
    Debug = 1,
    Information = 2,
    Warning = 3,
    Error = 4,
    Critical = 5,
    None = 6
}

public interface ILogger
{
    void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception, string> formatter);
    bool IsEnabled(LogLevel logLevel);
    IDisposable BeginScope<TState>(TState state);
}

public readonly struct EventId
{
    public int Id { get; }
    public string? Name { get; }

    public EventId(int id, string? name = null)
    {
        Id = id;
        Name = name;
    }

    public override string ToString() => Name ?? Id.ToString();
}

public interface ILogger<T> : ILogger
{
}

// public static class UnityLoggerFactory
// {
//     public static ILogger<T> CreateLogger<T>() => new UnityLogger<T>();
// }

public interface ILoggerProvider : IDisposable
{
    ILogger CreateLogger(string categoryName);
}

public interface ILoggerFactory
{
    ILogger CreateLogger(string categoryName);
    void AddProvider(ILoggerProvider provider);
    void Dispose();
}

// public static class LoggerFactoryExtensions
// {
//     public static ILogger<T> CreateLogger<T>(this ILoggerFactory factory)
//     {
//         return (ILogger<T>)factory.CreateLogger(typeof(T).FullName);
//     }
// }

// public class CompositeLogger : ILogger
// {
//     private readonly string _categoryName;
//     private readonly IList<ILoggerProvider> _providers;

//     public CompositeLogger(string categoryName, IList<ILoggerProvider> providers)
//     {
//         _categoryName = categoryName;
//         _providers = providers;
//     }

//     public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
//     {
//         foreach (var provider in _providers)
//         {
//             provider.CreateLogger(_categoryName).Log(logLevel, eventId, state, exception, formatter);
//         }
//     }

//     public bool IsEnabled(LogLevel logLevel) => true;

//     public IDisposable BeginScope<TState>(TState state) => null;
// }

// public class ConsoleLoggerProvider : ILoggerProvider
// {
//     public ILogger CreateLogger(string categoryName)
//     {
//         return new ConsoleLogger(categoryName);
//     }

//     public void Dispose() { }
// }

// public class ConsoleLogger : ILogger
// {
//     private readonly string _categoryName;

//     public ConsoleLogger(string categoryName)
//     {
//         _categoryName = categoryName;
//     }

//     public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
//     {
//         Console.WriteLine($"[{_categoryName}] {logLevel}: {formatter(state, exception)}");
//     }

//     public bool IsEnabled(LogLevel logLevel) => true;

//     public IDisposable BeginScope<TState>(TState state) => null;
// }

// public class TraceSourceLoggerProvider : ILoggerProvider
// {
//     private readonly string _name;

//     public TraceSourceLoggerProvider(string name)
//     {
//         _name = name;
//     }

//     public ILogger CreateLogger(string categoryName)
//     {
//         return new TraceSourceLogger(_name, categoryName);
//     }

//     public void Dispose() { }
// }

// public class TraceSourceLogger : ILogger
// {
//     private readonly string _name;
//     private readonly string _categoryName;

//     public TraceSourceLogger(string name, string categoryName)
//     {
//         _name = name;
//         _categoryName = categoryName;
//     }

//     public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
//     {
//         System.Diagnostics.Trace.WriteLine($"[{_name}] [{_categoryName}] {logLevel}: {formatter(state, exception)}");
//     }

//     public bool IsEnabled(LogLevel logLevel) => true;

//     public IDisposable BeginScope<TState>(TState state) => null;
// }
// public class LoggerFactoryOptions
// {
//     private readonly LoggerFactory _factory;

//     public LoggerFactoryOptions(LoggerFactory factory)
//     {
//         _factory = factory;
//     }

//     // public void AddConsole()
//     // {
//     //     _factory.AddProvider(new ConsoleLoggerProvider());
//     // }

//     // public void AddTraceSource(string name)
//     // {
//     //     _factory.AddProvider(new TraceSourceLoggerProvider(name));
//     // }
// }

// public class LoggerFactory : ILoggerFactory
// {
//     private readonly List<ILoggerProvider> _providers = new List<ILoggerProvider>();

//     public ILogger CreateLogger(string categoryName)
//     {
//         return new CompositeLogger(categoryName, _providers);
//     }

//     public void AddProvider(ILoggerProvider provider)
//     {
//         _providers.Add(provider);
//     }

//     public void Dispose()
//     {
//         foreach (var provider in _providers)
//         {
//             provider.Dispose();
//         }
//         _providers.Clear();
//     }

//     public static LoggerFactory Create(Action<LoggerFactoryOptions> configure)
//     {
//         var factory = new LoggerFactory();
//         var options = new LoggerFactoryOptions(factory);
//         configure(options);
//         return factory;
//     }
// }

// static class DefaultLoggerFactory
// {
//     public static ILoggerFactory Value { get; }

//     static DefaultLoggerFactory()
//     {
//         Value = LoggerFactory.Create(options =>
//         {
//             if (AppContext.TryGetSwitch("NCalc.Logging.EnableConsole", out var enableConsole) && enableConsole)
//             {
//                 options.AddConsole();
//             }

//             if (AppContext.TryGetSwitch("NCalc.Logging.EnableTrace", out var enableTrace) && enableTrace)
//             {
//                 options.AddTraceSource("NCalc");
//             }
//         });
//     }
// }
