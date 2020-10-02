using System;
namespace ConnectFourGabriela.GameEngine
{
    public interface IConnectFourRenderer
    {

        #region Properties

        public IConnectFourGame Game { get; set; }

        #endregion

        #region Methods

        public void PrintBoard();

        #endregion

    }
}