using System.Numerics;

namespace MorseChessCS
{
    public class Queen : Piece
    {
        public Queen(PieceColor color)
        {
            pointValue = 9;
            Color = color;
            Type = PieceType.Queen;
            Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()];
        }

        public override object Clone()
        {
            return new Queen(Color)
            {
                pointValue = 9,
                Color = Color,
                Type = PieceType.Queen,
                Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()]
            };
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
