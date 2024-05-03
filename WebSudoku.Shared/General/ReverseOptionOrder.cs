namespace WebSudoku.Shared.General
{
    public class ReverseOptionOrder<T> : IOptionOrder<T>
    {
        public IEnumerable<T> Order(IEnumerable<T> sequence)
        {
            if (sequence == null)
                return Enumerable.Empty<T>();
            return sequence.Reverse();
        }
    }
}
