
namespace WebSudoku.Shared
{
    public interface IOptionOrder<T>
    {
        IEnumerable<T> Order(IEnumerable<T> sequence);
    }
}