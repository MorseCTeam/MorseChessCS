using Raylib_cs;
using System.Numerics;

namespace MorseChessCS
{
    public abstract class Piece
    {
        protected int pointValue;
        public PieceColor Color { get; protected set; }
        public PieceType Type { get; protected set; }
        public Texture2D Texture{ get; protected set; }

     public enum PieceColor
        {
            White,
            Black
        }
     
        public enum PieceType
        {
            Pawn,
            Rook,
            Knight,
            Bishop,
            Queen,
            King
        }

        
        public abstract List<Vector2> GetPossibleMoves(Vector2 mousePosition);

    }

}
