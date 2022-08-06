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

        public override List<Vector2> GetPossibleMoves(Vector2 mousePosition)
        {
            throw new NotImplementedException();
        }
    }
}
