using System;
using ConnectFourGabriela.GameEngine;
using ConnectFourGabriela.GameEngine.Renderer;

namespace ConnectFourGabriela.GameEngine.Runner
{
    public class ConsoleRunner : BaseConsoleRunner
    {

        #region Constructors

        public ConsoleRunner(IConnectFourGame game, IConnectFourRenderer renderer)
            : base(game, renderer)
        {
            this.Game = game;
            this.Renderer = renderer;
        }

        #endregion

        #region Abstract Methods

        public override int AskUserForMoves()
        {
            int userChoice = 0;

            bool isInt = false;
            while (!isInt)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the column to move the chip to: ");
                string input = Console.ReadLine();
                try
                {
                    int columnToPlace = Int32.Parse(input);
                    if (columnToPlace < 0 || columnToPlace >= this.Game.NumberOfColumns)
                    {
                        Console.WriteLine($"This is an invalid input: '{input}'.");
                        isInt = false;
                    }
                    else
                    {
                        userChoice = columnToPlace;
                        this.Game.Count++;
                        isInt = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"This is an invalid input: '{input}'.");
                }
            }
            return userChoice;
        }

        #endregion

    }
}