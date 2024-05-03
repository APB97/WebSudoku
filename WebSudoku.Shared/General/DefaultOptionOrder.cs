namespace WebSudoku.Shared.General
{
    public class DefaultOptionOrder<T> : IOptionOrder<T>
    {
        public IEnumerable<T> Order(IEnumerable<T> sequence)
        {
            return sequence;
        }
    }
}
