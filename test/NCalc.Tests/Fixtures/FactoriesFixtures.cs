﻿using Microsoft.Extensions.DependencyInjection;
using BezierGraph.Dependencies.NCalc.Antlr.Configuration;
using BezierGraph.Dependencies.NCalc.Cache.Configuration;
using BezierGraph.Dependencies.NCalc.DependencyInjection;
using BezierGraph.Dependencies.NCalc.Factories;

namespace BezierGraph.Dependencies.NCalc.Tests.Fixtures;

public abstract class FactoriesFixtureBase
{
    public IExpressionFactory ExpressionFactory { get; protected set; }

    public ILogicalExpressionFactory LogicalExpressionFactory { get; protected set; }
}

public sealed class FactoriesFixture : FactoriesFixtureBase
{
    public FactoriesFixture()
    {
        var serviceProvider = new ServiceCollection()
            .AddNCalc()
            .Services.BuildServiceProvider();
        ExpressionFactory = serviceProvider.GetRequiredService<IExpressionFactory>();
        LogicalExpressionFactory = serviceProvider.GetRequiredService<ILogicalExpressionFactory>();
    }
}

public sealed class FactoriesWithAntlrFixture : FactoriesFixtureBase
{
    public FactoriesWithAntlrFixture()
    {
        var serviceProvider = new ServiceCollection()
            .AddNCalc()
            .WithAntlr()
            .Services.BuildServiceProvider();
        ExpressionFactory = serviceProvider.GetRequiredService<IExpressionFactory>();
        LogicalExpressionFactory = serviceProvider.GetRequiredService<ILogicalExpressionFactory>();
    }
}

public sealed class FactoriesWithMemoryCacheFixture : FactoriesFixtureBase
{
    public FactoriesWithMemoryCacheFixture()
    {
        var serviceProvider = new ServiceCollection()
            .AddMemoryCache()
            .AddNCalc()
            .WithMemoryCache()
            .Services.BuildServiceProvider();
        ExpressionFactory = serviceProvider.GetRequiredService<IExpressionFactory>();
        LogicalExpressionFactory = serviceProvider.GetRequiredService<ILogicalExpressionFactory>();
    }
}