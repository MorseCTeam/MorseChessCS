using System.Numerics;

namespace MorseChessCS
{
    internal class King : Piece
    {
        public King(PieceColor color)
        {
            pointValue = 0;
            Color = color;
            Type = PieceType.King;
            Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()];
        }

        public override object Clone()
        {
            return new King(Color)
            {
                pointValue = 0,
                Color = Color,
                Type = PieceType.King,
                Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()]
            };
        }

        public override List<Vector2> GetPossibleMoves(Vector2 mousePosition)
        {
            List<Vector2> possibleMoves = new();

            Board board = GameManager.Board;
            int x = (int)mousePosition.X / 100;
            int y = (int)mousePosition.Y / 100;

            if (x != 7 && (!board.IsFieldOccupied(x + 1, y) || board.pieces[x + 1, y].Color != board.pieces[x, y].Color))
            {
                possibleMoves.Add(new Vector2(x + 1, y));
            }
            if (x != 0 && (!board.IsFieldOccupied(x - 1, y) || board.pieces[x - 1, y].Color != board.pieces[x, y].Color))
            {
                possibleMoves.Add(new Vector2(x - 1, y));
            }
            if (y != 7 && (!board.IsFieldOccupied(x, y + 1) || board.pieces[x, y + 1].Color != board.pieces[x, y].Color))
            {
                possibleMoves.Add(new Vector2(x, y + 1));
            }
            if (y != 0 && (!board.IsFieldOccupied(x, y - 1) || board.pieces[x, y - 1].Color != board.pieces[x, y].Color))
            {
                possibleMoves.Add(new Vector2(x, y - 1));
            }
            if (x != 7 && y != 7 && (!board.IsFieldOccupied(x + 1, y + 1) || board.pieces[x + 1, y + 1].Color != board.pieces[x, y].Color))
            {
                possibleMoves.Add(new Vector2(x + 1, y + 1));
            }
            if (x != 7 && y != 0 && (!board.IsFieldOccupied(x + 1, y - 1) || board.pieces[x + 1, y - 1].Color != board.pieces[x, y].Color))
            {
                possibleMoves.Add(new Vector2(x + 1, y - 1));
            }
            if (x != 0 && y != 7 && (!board.IsFieldOccupied(x - 1, y + 1) || board.pieces[x - 1, y + 1].Color != board.pieces[x, y].Color))
            {
                possibleMoves.Add(new Vector2(x - 1, y + 1));
            }
            if (x != 0 && y != 0 && (!board.IsFieldOccupied(x - 1, y - 1) || board.pieces[x - 1, y - 1].Color != board.pieces[x, y].Color))
            {
                possibleMoves.Add(new Vector2(x - 1, y - 1));
            }

            return possibleMoves;
        }
    }
}
