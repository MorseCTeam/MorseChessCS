using Raylib_cs;

namespace MorseChessCS
{
    internal class Program
    {
        static void Main()
        {
            List<IDrawable> drawables = new();

            Raylib.InitWindow(GameManager.GameWidth, GameManager.GameHeight, "MorseChessCS");
            Raylib.SetTargetFPS(60);
            GameManager.LoadPieceTextures();
            Board board = new();

            drawables.Add(board);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                foreach (IDrawable drawable in drawables)
                {
                    drawable.Draw();
                }
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
