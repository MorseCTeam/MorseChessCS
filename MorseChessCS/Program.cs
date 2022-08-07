using Raylib_cs;
using System.Linq;
using System.Numerics;

namespace MorseChessCS
{
    public class Program
    {
        static void Main()
        {
            List<IDrawable> drawables = new();

            Raylib.InitWindow(GameManager.GameWidth, GameManager.GameHeight, "MorseChessCS");
            Raylib.SetTargetFPS(60);
            GameManager.LoadPieceTextures();
            Board board = new();
            GameManager.Board = board;
            drawables.Add(board);
            board.SetPieces();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                if (board.selectedPiece is not null && Raylib.IsMouseButtonPressed(0) && board.selectedPiece.GetPossibleMoves(board.selectedPiecePosition).Contains(new Vector2((int)Raylib.GetMouseX() / GameManager.FieldLength, (int)Raylib.GetMouseY() / GameManager.FieldLength)))
                {
                    board.MoveSelectedPiece();
                }
                if (Raylib.IsMouseButtonPressed(0))
                {
                    board.SelectPiece();
                }
                board.Draw();
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
