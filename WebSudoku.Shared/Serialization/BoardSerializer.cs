﻿using System.Text.Json;
using WebSudoku.Shared.Sudoku;

namespace WebSudoku.Shared.Serialization
{
    public static class BoardSerializer
    {
        public static Board? DeserializeFromJson(string json)
        {
            return new Board(JsonSerializer.Deserialize<BoardState>(json));
        }

        public static Board DeserializeFromJson(string json, out TimeSpan? timer)
        {
            GameState gameState = JsonSerializer.Deserialize<GameState>(json);
            timer = gameState.Timer;
            return new Board(gameState.Board);
        }

        public static string SerializeToJson(Board board)
        {
            return JsonSerializer.Serialize(board.GetState());
        }

        public static string SerializeToJson(Board board, TimeSpan? timer, string version)
        {
            return JsonSerializer.Serialize(new GameState { Board = board.GetState(), Timer = timer, Version = version });
        }
    }
}
