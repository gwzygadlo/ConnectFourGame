using System;
using ConnectFourGabriela.GameEngine;
using ConnectFourGabriela.GameEngine.Renderer;
using ConnectFourGabriela.GameEngine.Runner;

namespace ConnectFourGabriela
{
    class MainClass
    {
        static void Main(string[] args)
        {
            IConnectFourGame game = new ConnectFourGameWithLists(7, 6);
            IConnectFourRenderer renderer = new HorizontalRenderer(game);
            ConsoleRunner runner = new ConsoleRunner(game, renderer);

            runner.Run();
        }
    }
}
