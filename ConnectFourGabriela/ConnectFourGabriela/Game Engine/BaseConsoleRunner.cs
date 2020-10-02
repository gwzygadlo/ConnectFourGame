using System;
using ConnectFourGabriela.GameEngine.Renderer;

namespace ConnectFourGabriela.GameEngine
{
    public abstract class BaseConsoleRunner
    {

        #region Constructors

        public BaseConsoleRunner(IConnectFourGame game, IConnectFourRenderer renderer)
        {
            this.Game = game;
            this.Renderer = renderer;
        }

        #endregion

        #region Properties

        public virtual IConnectFourGame Game { get; set; }
        public virtual IConnectFourRenderer Renderer { get; set; }

        #endregion

        #region Virtual Methods

        public virtual void Run()
        {
            Console.WriteLine("************************************************");
            Console.WriteLine("******* Welcome to the Connect Four Game! ******");
            Console.WriteLine("************************************************");

            this.Renderer.PrintBoard();

            bool isWon = false;
            int userInput;
            while (!isWon)
            {
                isWon = this.Game.CheckIfWon();
                if (!isWon)
                {
                    userInput = this.AskUserForMoves();
                    this.Game.MoveChipMethod(userInput);
                    this.Renderer.PrintBoard();
                }
            }
            Console.WriteLine();
            Console.WriteLine("************************************************");
            Console.WriteLine("************* The game is finished! ************");
            Console.WriteLine("************************************************");
        }

        #endregion

        #region Abstract Methods

        public abstract int AskUserForMoves();

        #endregion

    }
}