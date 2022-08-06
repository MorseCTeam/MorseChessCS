using Raylib_cs;

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

            board.pieces[6, 2] = new Rook(Piece.PieceColor.White);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
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
