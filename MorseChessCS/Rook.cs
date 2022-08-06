using System.Numerics;

namespace MorseChessCS
{
    public class Rook : Piece
    {
        public Rook(PieceColor color)
        {
            pointValue = 5;
            Color = color;
            Type = PieceType.Rook;
            Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()];
        }

        public override List<Vector2> GetPossibleMoves(Vector2 mousePosition)
        {
            List<Vector2> possibleMoves = new();

            Board board = GameManager.Board;
            int x = (int)mousePosition.X / 100;
            int y = (int)mousePosition.Y / 100;

            for (int i = x + 1; i < 8; i++)
            {
                if (board.IsFieldOccupied(i, y))
                {
                    if (board.pieces[x, y].Color == board.pieces[i, y].Color)
                    {
                        break;
                    }
                    possibleMoves.Add(new Vector2(i, y));
                    break;
                }
                possibleMoves.Add(new Vector2(i, y));
            }

            for (int i = x - 1; i >= 0; i--)
            {
                if (board.IsFieldOccupied(i, y))
                {
                    if (board.pieces[x, y].Color == board.pieces[i, y].Color)
                    {
                        break;
                    }
                    possibleMoves.Add(new Vector2(i, y));
                    break;
                }
                possibleMoves.Add(new Vector2(i, y));
            }

            for (int i = y - 1; i >= 0; i--)
            {
                if (board.IsFieldOccupied(x, i))
                {
                    if (board.pieces[x, y].Color == board.pieces[x, i].Color)
                    {
                        break;
                    }
                    possibleMoves.Add(new Vector2(x, i));
                    break;
                }
                possibleMoves.Add(new Vector2(x, i));
            }

            for (int i = y + 1; i < 8; i++)
            {
                if (board.IsFieldOccupied(x, i))
                {
                    if (board.pieces[x, y].Color == board.pieces[x, i].Color)
                    {
                        break;
                    }
                    possibleMoves.Add(new Vector2(x, i));
                    break;
                }
                possibleMoves.Add(new Vector2(x, i));
            }

            return possibleMoves;
        }
    }
}
