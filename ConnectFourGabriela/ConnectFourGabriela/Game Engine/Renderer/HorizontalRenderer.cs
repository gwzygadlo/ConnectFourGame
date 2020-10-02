using System;
namespace ConnectFourGabriela.GameEngine.Renderer
{
    public class HorizontalRenderer : IConnectFourRenderer
    {

        #region Constructor

        public HorizontalRenderer(IConnectFourGame game)
        {
            this.Game = game;
        }

        #endregion

        #region Properties

        public IConnectFourGame Game { get; set; }

        #endregion

        #region Methods

        public void PrintBoard()
        {
            Console.WriteLine();
            Console.WriteLine("________________________________");
            for (int i = 0; i < this.Game.NumberOfColumns; i++)
            {
                Console.Write("C: " + i + " || ");
                for (int j = 0; j < this.Game.NumberOfRows; j++)
                {
                    if (this.Game.GetChip(i, j) == null)
                    {

                    }
                    else
                    {
                        Console.Write(this.Game.GetChip(i, j).ChipColor + " | ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("________________________________");
                Console.WriteLine();
                if (i == this.Game.NumberOfColumns - 1)
                {
                    for (int k = 0; k < this.Game.NumberOfRows; k++)
                    {
                        if (k == 0)
                        {
                            Console.Write("Row: || ");
                        }
                        Console.Write(k + " | ");
                    }
                }
            }
            Console.WriteLine();
        }

        #endregion

    }
}