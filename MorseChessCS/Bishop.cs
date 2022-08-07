using System.Numerics;

namespace MorseChessCS
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color)
        {
            pointValue = 3;
            Color = color;
            Type = PieceType.Bishop;
            Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()];
        }

        public override object Clone()
        {
            return new Bishop(Color)
            {
                pointValue = 3,
                Color = Color,
                Type = PieceType.Bishop,
                Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()]
            };
        }

        public override List<Vector2> GetPossibleMoves(Vector2 mousePosition)
        {
            List<Vector2> possibleMoves = new();

            int fieldLength = GameManager.FieldLength;

            int x = (int)mousePosition.X / fieldLength;
            int y = (int)mousePosition.Y / fieldLength;

            for (int i = 1; i < 7; i++)
            {
                if (x + i > 7 || y + i > 7)
                {
                    break;
                }
                if (board.IsFieldOccupied(x + i, y + i) && board.pieces[x + i, y + i].Color != board.pieces[x, y].Color)
                {
                    possibleMoves.Add(new Vector2(x + i, y + i));
                    break;
                }
                if (board.IsFieldOccupied(x + i, y + i) && board.pieces[x + i, y + i].Color == board.pieces[x, y].Color)
                {
                    break;
                }
                possibleMoves.Add(new Vector2(x + i, y + i));
            }

            for (int i = 1; i < 7; i++)
            {
                if (x + i > 7 || y - i < 0)
                {
                    break;
                }
                if (board.IsFieldOccupied(x + i, y - i) && board.pieces[x + i, y - i].Color != board.pieces[x, y].Color)
                {
                    possibleMoves.Add(new Vector2(x + i, y - i));
                    break;
                }
                if (board.IsFieldOccupied(x + i, y - i) && board.pieces[x + i, y - i].Color == board.pieces[x, y].Color)
                {
                    break;
                }
                possibleMoves.Add(new Vector2(x + i, y - i));
            }

            for (int i = 1; i < 7; i++)
            {
                if (x - i < 0 || y + i > 7)
                {
                    break;
                }
                if (board.IsFieldOccupied(x - i, y + i) && board.pieces[x - i, y + i].Color != board.pieces[x, y].Color)
                {
                    possibleMoves.Add(new Vector2(x - i, y + i));
                    break;
                }
                if (board.IsFieldOccupied(x - i, y + i) && board.pieces[x - i, y + i].Color == board.pieces[x, y].Color)
                {
                    break;
                }
                possibleMoves.Add(new Vector2(x - i, y + i));
            }

            for (int i = 1; i < 7; i++)
            {
                if (x - i < 0 || y - i < 0)
                {
                    break;
                }
                if (board.IsFieldOccupied(x - i, y - i) && board.pieces[x - i, y - i].Color != board.pieces[x, y].Color)
                {
                    possibleMoves.Add(new Vector2(x - i, y - i));
                    break;
                }
                if (board.IsFieldOccupied(x - i, y - i) && board.pieces[x - i, y - i].Color == board.pieces[x, y].Color)
                {
                    break;
                }
                possibleMoves.Add(new Vector2(x - i, y - i));
            }

            return possibleMoves;
        }
    }
}
