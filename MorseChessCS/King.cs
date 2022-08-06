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

        public override List<Vector2> GetPossibleMoves(Vector2 mousePosition)
        {
            throw new NotImplementedException();
        }
    }
}
