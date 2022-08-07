using System.Numerics;

namespace MorseChessCS
{
    internal class Pawn : Piece
    {
        public Pawn(PieceColor color)
        {
            pointValue = 1;
            Color = color;
            Type = PieceType.Pawn;
            Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()];
        }

        public override object Clone()
        {
            return new Pawn(Color)
            {
                pointValue = 1,
                Color = Color,
                Type = PieceType.Pawn,
                Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()]
            };
        }

        public override List<Vector2> GetPossibleMoves(Vector2 mousePosition)
        {
            int fieldLength = GameManager.FieldLength;
            List<Vector2> possibleMoves = new();

            int x = (int)mousePosition.X / fieldLength;
            int y = (int)mousePosition.Y / fieldLength;
            int count = (Color == PieceColor.White && y == 6) || (Color == PieceColor.Black && y == 1) ? 2 : 1;
            int correct = count == 2 ? 3 : 2;
            switch (Color)
            {
                case PieceColor.White:
                {
                    while (count > 0)
                    {
                        if (board.pieces[x,y-Math.Abs(count - correct)] is not null || y == 0)
                        {
                          break;        
                        }
                        possibleMoves.Add(new Vector2(x, y - Math.Abs(count - correct)));
                        count--;
                    }
                    if (x != 7)
                    {
                        if (board.IsFieldOccupied(x + 1, y - 1) && board.pieces[x, y].Color != board.pieces[x + 1, y - 1].Color)
                        {
                            possibleMoves.Add(new Vector2(x + 1, y - 1));
                        }
                    }
                    if (x != 0)
                    {
                        if (board.IsFieldOccupied(x - 1, y - 1) && board.pieces[x, y].Color != board.pieces[x - 1, y - 1].Color)
                        {
                            possibleMoves.Add(new Vector2(x - 1, y - 1));
                        }
                    }
                    break;
                }
                case PieceColor.Black:
                {
                 
                    while (count > 0)
                    {
                        if (board.pieces[x, y + Math.Abs(count - correct)] is not null || y == 7)
                        {
                            break;
                        }
                        possibleMoves.Add(new Vector2(x, y + Math.Abs(count - correct)));
                        count--;
                    }
                        if (x != 7)
                        {
                            if (board.IsFieldOccupied(x + 1, y + 1) && board.pieces[x, y].Color != board.pieces[x + 1, y + 1].Color)
                            {
                                possibleMoves.Add(new Vector2(x + 1, y + 1));
                            }
                        }
                        if (x != 0)
                        {
                            if (board.IsFieldOccupied(x - 1, y + 1) && board.pieces[x, y].Color != board.pieces[x - 1, y + 1].Color)
                            {
                                possibleMoves.Add(new Vector2(x - 1, y + 1));
                            }
                        }
                        break;
                }
            }
            return possibleMoves;
        }

    }
}
