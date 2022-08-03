namespace MorseChessCS
{
    internal class Pawn : Piece
    {
        public Pawn(PieceColor color)
        {
            piecePointValue = 1;
            pieceColor = color;
            pieceName = PieceName.Pawn;
            pieceKey = stringColor[(int)pieceColor] + stringName[(int)pieceName];
            pieceTexture = GameManager.PieceTextures[pieceKey];
        }

    }
}
