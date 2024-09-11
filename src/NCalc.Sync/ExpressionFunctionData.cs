namespace BezierGraph.Dependencies.NCalc;

public class ExpressionFunctionData(Guid id, Expression[] arguments, ExpressionContext context) : IEnumerable<Expression>
{
    public Guid Id { get; } = id;
    private Expression[] Arguments { get; } = arguments;
    public ExpressionContext Context { get; } = context;

    public Expression this[int index]
    {
        get => Arguments[index];
        set => Arguments[index] = value;
    }

    public IEnumerator<Expression> GetEnumerator()
    {
        // return ((IEnumerable<Expression>)Arguments).GetEnumerator();
        return new ExpressionFunctionEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Arguments.GetEnumerator();
    }

            private class ExpressionFunctionEnumerator : IEnumerator<Expression>
        {
            private readonly ExpressionFunctionData _data;
            private int _index = -1;

            public ExpressionFunctionEnumerator(ExpressionFunctionData data)
            {
                _data = data;
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _data.Arguments.Length;
            }

            public void Reset()
            {
                _index = -1;
            }

            public Expression Current => _data.Arguments[_index];

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
}