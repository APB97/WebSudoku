namespace WebSudoku.Shared.General
{
    public interface IOptionOrder<T>
    {
        IEnumerable<T> Order(IEnumerable<T> sequence);
    }
}