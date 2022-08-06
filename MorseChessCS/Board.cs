using Raylib_cs;
using System.Numerics;

namespace MorseChessCS
{
    public class Board : IDrawable
    {
        private Color PrimaryColor { get; set; } = Color.BROWN;
        private Color SecondaryColor { get; set; } = Color.WHITE;
        private Color SelectedColor { get; set; } = new(0, 255, 0, 80);
        private Color FreeSpaceColor { get; set; } = new(0, 0, 255, 80);
        private Color OccupiedSpaceColor { get; set; } = new(255, 0, 0, 80);

        public Piece[,] pieces = new Piece[8, 8];

        public Piece selectedPiece = null;
        public Vector2 selectedPiecePosition = Vector2.Zero;

        public Vector2[] selectedFields = null;

        public Vector2 size = new(100, 100);

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
            Piece.PieceColor WHITE = Piece.PieceColor.White;
            Piece.PieceColor BLACK = Piece.PieceColor.Black;
            for (int x = 0; x < 8; x++)
            {
                pieces[x, 6] = new Pawn(WHITE);
                pieces[x, 1] = new Pawn(BLACK);
            }

            pieces[0, 7] = new Rook(WHITE);
            pieces[7, 7] = new Rook(WHITE);
            pieces[0, 0] = new Rook(BLACK);
            pieces[7, 0] = new Rook(BLACK);

            pieces[1, 7] = new Knight(WHITE);
            pieces[6, 7] = new Knight(WHITE);
            pieces[1, 0] = new Knight(BLACK);
            pieces[6, 0] = new Knight(BLACK);

            pieces[2, 7] = new Bishop(WHITE);
            pieces[5, 7] = new Bishop(WHITE);
            pieces[2, 0] = new Bishop(BLACK);
            pieces[5, 0] = new Bishop(BLACK);

            pieces[3, 0] = new Queen(BLACK);
            pieces[3, 7] = new Queen(WHITE);

            pieces[4, 0] = new King(BLACK);
            pieces[4, 7] = new King(WHITE);
        }

        public Piece? GetClickedPiece()
        {
            int x = Raylib.GetMouseX() / 100;
            int y = Raylib.GetMouseY() / 100;
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return null;
            }
            else
            {
                return pieces[x, y];
            }
        }

        public void SelectPiece()
        {
            if (Raylib.IsMouseButtonPressed(0))
            {
                if (GetClickedPiece() != null && ReferenceEquals(selectedPiece, GetClickedPiece()))
                {
                    selectedPiece = null;
                    selectedPiecePosition = Vector2.Zero;
                }
                else if (GetClickedPiece() != null && !ReferenceEquals(selectedPiece, GetClickedPiece()))
                {
                    selectedPiece = GetClickedPiece();
                    selectedPiecePosition = Raylib.GetMousePosition();
                } else
                {
                    selectedPiece = null;
                    selectedPiecePosition = Vector2.Zero;
                }
            }
        }

        public bool IsFieldOccupied(int x, int y)
        {
            return pieces[x, y] is not null;
        }

        public void Draw()
        {
            int fieldLength = GameManager.FieldLength;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Color fieldColor = ((x + y * 9 + 1) % 2 == 0 ? PrimaryColor : SecondaryColor);
                    Raylib.DrawRectangle(fieldLength * x, fieldLength * y, fieldLength, fieldLength, fieldColor);
                }
            }

            if (selectedPiece != null)
            {
                foreach(Vector2 vector in selectedPiece.GetPossibleMoves(selectedPiecePosition))
                {
                    if (pieces[(int)vector.X, (int)vector.Y] is not null)
                    {
                        Raylib.DrawRectangleV(GameManager.FieldToScreenPosition(vector), size, OccupiedSpaceColor);
                    }
                    else
                    {
                        Raylib.DrawRectangleV(GameManager.FieldToScreenPosition(vector), size, FreeSpaceColor);
                    }
                }
            }

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (pieces[x, y] != null)
                    {
                        if (ReferenceEquals(pieces[x, y], selectedPiece))
                        {
                            Raylib.DrawRectangle(x * 100, y * 100, 100, 100, SelectedColor);
                        }
                        Texture2D texture = pieces[x, y].Texture;
                        Raylib.DrawTexture(texture, fieldLength * x, fieldLength * y, Color.WHITE);
                    }
                }
            }

        }
    }
}
