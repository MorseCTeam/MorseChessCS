using Raylib_cs;

namespace MorseChessCS
{
    abstract class Piece : IDrawable
    {
        protected int piecePointValue;
        protected PieceColor pieceColor;
        protected PieceName pieceName;
        protected Texture2D pieceTexture;
        protected string pieceKey;


        public enum PieceColor
        {
            White,
            Black
        }

        protected string[] stringColor = { "White", "Black" };

        public enum PieceName
        {
            Pawn,
            Rook,
            Knight,
            Bishop,
            Queen,
            King
        }

        protected string[] stringName = { "Pawn", "Rook", "Knight", "Bishop", "Queen", "King" };

        public PieceColor getPieceColor()
        {
            return pieceColor;
        }

        public void Draw()
        {

        }
    }

}
