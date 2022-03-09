namespace WebSudoku.Shared
{
    public class RandomOptionOrder<T> : IOptionOrder<T>
    {
        public IEnumerable<T> Order(IEnumerable<T> sequence)
        {
            if (sequence == null)
                return Enumerable.Empty<T>();
            return sequence.OrderBy(_ => Random.Shared.NextDouble());
        }
    }
}
