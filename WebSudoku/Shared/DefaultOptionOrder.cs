namespace WebSudoku.Shared
{
    public class DefaultOptionOrder<T> : IOptionOrder<T>
    {
        public IEnumerable<T> Order(IEnumerable<T> sequence)
        {
            return sequence;
        }
    }
}
