using SiliconStudio.Paradox.Engine;

namespace MyGame
{
    class MyGameApp
    {
        static void Main(string[] args)
        {
            // Profiler.EnableAll();
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
