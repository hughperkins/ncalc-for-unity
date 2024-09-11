﻿using Microsoft.Extensions.DependencyInjection;
using BezierGraph.Dependencies.NCalc.Cache;
using BezierGraph.Dependencies.NCalc.Factories;
using BezierGraph.Dependencies.NCalc.Services;

namespace BezierGraph.Dependencies.NCalc.DependencyInjection;

public class NCalcServiceBuilder(IServiceCollection services)
{
    public IServiceCollection Services { get; } = services;

    public NCalcServiceBuilder WithExpressionFactory<TExpressionFactory>()
        where TExpressionFactory : class, IExpressionFactory
    {
        Services.ReplaceScoped<IExpressionFactory, TExpressionFactory>();
        return this;
    }

    public NCalcServiceBuilder WithAsyncExpressionFactory<TAsyncExpressionFactory>()
        where TAsyncExpressionFactory : class, IAsyncExpressionFactory
    {
        Services.ReplaceScoped<IAsyncExpressionFactory, TAsyncExpressionFactory>();
        return this;
    }

    public NCalcServiceBuilder WithCache<TCache>() where TCache : class, ILogicalExpressionCache
    {
        Services.ReplaceSingleton<ILogicalExpressionCache, TCache>();
        return this;
    }

    public NCalcServiceBuilder WithLogicalExpressionFactory<TLogicalExpressionFactory>()
        where TLogicalExpressionFactory : class, ILogicalExpressionFactory
    {
        Services.ReplaceSingleton<ILogicalExpressionFactory, TLogicalExpressionFactory>();
        return this;
    }

    public NCalcServiceBuilder WithEvaluationService<TEvaluationService>()
        where TEvaluationService : class, IEvaluationService
    {
        Services.ReplaceTransient<IEvaluationService, TEvaluationService>();
        return this;
    }

    public NCalcServiceBuilder WithAsyncEvaluationService<TAsyncEvaluationService>()
        where TAsyncEvaluationService : class, IAsyncEvaluationService
    {
        Services.ReplaceTransient<IAsyncEvaluationService, TAsyncEvaluationService>();
        return this;
    }
}