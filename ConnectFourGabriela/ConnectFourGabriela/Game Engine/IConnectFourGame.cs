using System;
namespace ConnectFourGabriela.GameEngine
{
    public interface IConnectFourGame
    {

        #region Properties

        public int NumberOfColumns { get; set; }
        public int NumberOfRows { get; set; }
        public int Count { get; set; }

        #endregion

        #region Methods

        public bool CheckIfWon();
        public void MoveChipMethod(int userInput);
        public Chip GetChip(int column, int row);
        public int GetColumnCount();
        public int GetElementCount(int column);

        #endregion

    }
}