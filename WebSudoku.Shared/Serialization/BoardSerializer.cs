using System.Text.Json;
using WebSudoku.Shared.Sudoku;

namespace WebSudoku.Shared.Serialization
{
    public static class BoardSerializer
    {
        public static Board? DeserializeFromJson(string json, Solver solver)
        {
            return new Board(JsonSerializer.Deserialize<BoardState>(json));
        }

        public static string SerializeToJson(Board board)
        {
            return JsonSerializer.Serialize(board.GetState());
        }
    }
}
