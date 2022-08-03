using Raylib_cs;
using System.Numerics;

namespace MorseChessCS
{
    class Board : IDrawable
    {
        public Color PrimaryColor { get; set; } = Color.BLACK;
        public Color SecondaryColor { get; set; } = Color.WHITE;

        public Piece[,] pieces = new Piece[8, 8];

        public Board()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 2; y < 6; y++)
                {
                    pieces[x, y] = null;
                }
            }
            SetPieces();
        }

        public void SetPieces()
        {
            for (int x = 0; x < 8; x++)
            {
                pieces[x, 1] = new Pawn(Piece.PieceColor.White);
                pieces[x, 6] = new Pawn(Piece.PieceColor.White);
            }
        }

        public bool IsFieldOccupied(Vector2 vector)
        {
            return pieces[(int)vector.X, (int)vector.Y] is not null;
        }

        public Vector2 GetClickedField()
        {
            Vector2 vector = new();
            vector.X = Raylib.GetMouseX() / 100;
            vector.Y = Math.Abs(Raylib.GetMouseY() - 800) / 100;
            return vector;
        }

        public void Draw()
        {
            int boardLength = GameManager.BoardLength;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Color fieldColor = ((x + y * 9) % 2 == 0 ? PrimaryColor : SecondaryColor);
                    Raylib.DrawRectangle(boardLength / 8 * x, boardLength / 8 * y, boardLength / 8, boardLength / 8, fieldColor);
                }
            }
        }
    }
}
