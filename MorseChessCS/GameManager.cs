using Raylib_cs;
namespace MorseChessCS
{
    public static class GameManager
    {
        public static int GameWidth { get; set; } = 1024;
        public static int GameHeight { get; set; } = 800;
        public static int BoardLength { get => (GameWidth > GameHeight ? GameHeight : GameWidth); }

        public static Dictionary<string, Texture2D> PieceTextures { get; set; } = new();

        public static void LoadPieceTextures()
        {
            foreach (string color in Enum.GetNames(typeof(Piece.PieceColor)))
            {
                foreach (string name in Enum.GetNames(typeof(Piece.PieceName)))
                {
                    PieceTextures.Add($"{color}{name}", Raylib.LoadTexture($"./assets/{color}{name}.png"));
                }
            }

        }
    }
}
