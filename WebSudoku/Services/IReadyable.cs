namespace apb97.github.io.WebSudoku.Services;

public interface IReadyable
{
    bool IsReady { get; }
    Action OnReady { get; set; }
}
