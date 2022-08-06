using System.Numerics;

namespace MorseChessCS
{
    internal class Bishop : Piece
    {
        public Bishop(PieceColor color)
        {
            pointValue = 3;
            Color = color;
            Type = PieceType.Bishop;
            Texture = GameManager.PieceTextures[Color.ToString() + Type.ToString()];
        }

        public override List<Vector2> GetPossibleMoves(Vector2 mousePosition)
        {
            throw new NotImplementedException();
        }
    }
}
