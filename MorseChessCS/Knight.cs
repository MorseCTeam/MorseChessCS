using System.Numerics;

namespace MorseChessCS
{
    internal class Knight : Piece
    {
        public Knight(PieceColor color)
        {
            pointValue = 3;
            Color = color;
            Type = PieceType.Knight;
            Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()];
        }

        public override object Clone()
        {
            return new Knight(Color)
            {
                pointValue = 3,
                Color = this.Color,
                Type = PieceType.Knight,
                Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()]
            };
        }

        public override List<Vector2> GetPossibleMoves(Vector2 mousePosition)
        {
            int fieldLength = GameManager.FieldLength;
            List<Vector2> possibleMoves = new();

            int x = (int)mousePosition.X / fieldLength;
            int y = (int)mousePosition.Y / fieldLength;


            if (x < 7 && y > 1 && (board.pieces[x + 1, y - 2] is null || board.pieces[x + 1, y - 2].Color != Color))
            { 
                possibleMoves.Add(new Vector2(x + 1, y - 2));
            }
            if (x < 6 && y > 0 && (board.pieces[x + 2, y - 1] is null || board.pieces[x + 2, y - 1].Color != Color))
            {
                possibleMoves.Add(new Vector2(x + 2, y - 1));
            }

            if (x > 1 && y < 7 && (board.pieces[x - 2, y + 1] is null || board.pieces[x - 2, y + 1].Color != Color))
            {
                possibleMoves.Add(new Vector2(x - 2, y + 1));
            }
            if (x > 0 && y < 6 && (board.pieces[x - 1, y + 2] is null || board.pieces[x - 1, y + 2].Color != Color))
            {
                possibleMoves.Add(new Vector2(x - 1, y + 2));
            }

            if (x > 0 && y > 1 && (board.pieces[x-1,y-2] is null || board.pieces[x - 1, y - 2].Color != Color))
            {
                possibleMoves.Add(new Vector2(x - 1, y - 2));
            }
            if (x > 1 && y > 0 && (board.pieces[x - 2, y - 1] is null || board.pieces[x - 2, y - 1].Color != Color))
            {
                possibleMoves.Add(new Vector2(x - 2, y - 1));
            }

            if (x < 6 && y < 7 && (board.pieces[x + 2, y + 1] is null || board.pieces[x + 2, y + 1].Color != Color))
            {
                possibleMoves.Add(new Vector2(x + 2, y + 1));
            }
            if (x < 7 && y < 6 && (board.pieces[x + 1, y + 2] is null || board.pieces[x + 1, y + 2].Color != Color))
            {
                possibleMoves.Add(new Vector2(x + 1, y + 2));
            }

            return possibleMoves; 
        }
    }
}
