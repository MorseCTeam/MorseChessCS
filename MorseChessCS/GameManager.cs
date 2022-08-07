using Raylib_cs;
using System.Numerics;

namespace MorseChessCS
{
    public static class GameManager
    {
        public static int GameWidth { get; set; } = 800;
        public static int GameHeight { get; set; } = 800;
        public static int BoardLength { get => (GameWidth > GameHeight ? GameHeight : GameWidth); }
        public static int FieldLength { get => BoardLength / 8; }
        public static Board Board { get; set; }
        public static Dictionary<string, Texture2D> PieceTextures { get; set; } = new();


        public static void LoadPieceTextures()
        {
            foreach (string color in Enum.GetNames(typeof(Piece.PieceColor)))
            {
                foreach (string name in Enum.GetNames(typeof(Piece.PieceType)))
                {
                    Image image = Raylib.LoadImage($"./assets/{color}{name}.png");
                    Raylib.ImageResize(ref image, FieldLength, FieldLength);
                    PieceTextures.Add($"{color}{name}", Raylib.LoadTextureFromImage(image));
                    Raylib.UnloadImage(image);
                }
            }

        }

        public static Vector2 FieldToScreenPosition(Vector2 vector)
        {
            return new Vector2(vector.X * FieldLength, vector.Y * FieldLength);
        }

        public static Vector2 FieldToCircleScreenPosition(Vector2 vector)
        {
            return new Vector2(vector.X * FieldLength + FieldLength / 2, vector.Y * FieldLength + FieldLength / 2);
        }
    }
}
