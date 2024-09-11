#nullable disable
using System.Reflection;

namespace BezierGraph.Dependencies.NCalc.Helpers;

public readonly struct MathMethodInfo
{
    public required MethodInfo MethodInfo { get; init; }
    public required int ArgumentCount { get; init; }
}