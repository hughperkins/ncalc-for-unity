using BezierGraph.Dependencies.NCalc.Visitors;

namespace BezierGraph.Dependencies.NCalc.Domain;

public sealed class LogicalExpressionList : LogicalExpression, IList<LogicalExpression>
{
    private readonly List<LogicalExpression> _list;

    public LogicalExpressionList()
    {
        _list = [];
    }

    public LogicalExpressionList(IEnumerable<LogicalExpression> values)
    {
        _list = values.ToList();
    }

    public int Count => _list.Count;
    public bool IsReadOnly => false;

    public LogicalExpression this[int index]
    {
        get => _list[index];
        set => _list[index] = value;
    }

    // public IEnumerator<LogicalExpression> GetEnumerator()
    // {
    //     return _list.GetEnumerator();
    // }

        public IEnumerator<LogicalExpression> GetEnumerator()
        {
            return new LogicalExpressionEnumerator(this);
        }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(LogicalExpression item)
    {
        _list.Add(item);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public bool Contains(LogicalExpression item)
    {
        return _list.Contains(item);
    }

    public void CopyTo(LogicalExpression[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }

    public bool Remove(LogicalExpression item)
    {
        return _list.Remove(item);
    }

    public int IndexOf(LogicalExpression item)
    {
        return _list.IndexOf(item);
    }

    public void Insert(int index, LogicalExpression item)
    {
        _list.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
    }

    public override T Accept<T>(ILogicalExpressionVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }

          private class LogicalExpressionEnumerator : IEnumerator<LogicalExpression>
        {
            private readonly LogicalExpressionList _list;
            private int _index = -1;

            public LogicalExpressionEnumerator(LogicalExpressionList list)
            {
                _list = list;
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _list.Count;
            }

            public void Reset() => _index = -1;

            public LogicalExpression Current => _list[_index];

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
}