namespace apb97.github.io.WebSudoku.Shared.General;

public class ReverseOptionOrder<T> : IOptionOrder<T>
{
    public IEnumerable<T> Order(IEnumerable<T> sequence)
    {
        if (sequence == null)
            return [];
        return sequence.Reverse();
    }
}
