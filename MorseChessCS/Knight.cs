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

        public override List<Vector2> GetPossibleMoves(Vector2 mousePosition)
        {
            throw new NotImplementedException();
        }
    }
}
