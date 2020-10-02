using System;
namespace ConnectFourGabriela.GameEngine
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ConnectFourGameWithLists : IConnectFourGame
    {

        #region Constructors

        public ConnectFourGameWithLists(int column, int row)
        {
            this.NumberOfColumns = column;
            this.NumberOfRows = row;
            List<List<Chip>> temp = new List<List<Chip>>();
            for (int i = 0; i < NumberOfColumns; i++)
            {
                List<Chip> temp2 = new List<Chip>();
                temp.Add(temp2);
            }
            this.GameBoard = temp;
            this.Count = 0;
        }

        #endregion

        #region Properties

        public int NumberOfColumns { get; set; }
        public int NumberOfRows { get; set; }
        public List<List<Chip>> GameBoard { get; set; }
        public int Count { get; set; }

        #endregion

        #region Methods

        public Chip GetChip(int column, int row)
        {
            if (column >= GameBoard.Count || row >= GameBoard[column].Count
                || column < 0 || row < 0)
            {
                return null;
            }
            return this.GameBoard[column][row];
        }

        public bool CompareColors(Chip a, Chip b)
        {
            bool isEqual = false;
            if (a == null || b == null)
            {
                isEqual = false;
                return isEqual;
            }
            string chipColorA = a.ChipColor;
            string chipColorB = b.ChipColor;
            if (chipColorA.Equals(chipColorB))
            {
                isEqual = true;
                return isEqual;
            }
            return isEqual;
        }

        public bool RowCheck(int column, int row)
        {
            int counter = 0;
            bool isWon = false;
            for (int i = column; i < GameBoard.Count; i++)
            {
                if (counter >= 3)
                {
                    isWon = true;
                    return isWon;
                }
                if (CompareColors(GetChip(i, row), GetChip(i + 1, row)))
                {
                    counter++;
                }
                else if (!CompareColors(GetChip(i, row), GetChip(i + 1, row)))
                {
                    isWon = false;
                    break;
                }
            }
            return isWon;
        }

        public bool ColumnCheck(int column, int row)
        {
            int counter = 0;
            bool isWon = false;
            for (int i = row; i < GameBoard[column].Count; i++)
            {
                if (counter >= 3)
                {
                    isWon = true;
                    return isWon;
                }
                if (CompareColors(GetChip(column, i), GetChip(column, i + 1)))
                {
                    counter++;
                }
                else if (!CompareColors(GetChip(column, i), GetChip(column, i + 1)))
                {
                    isWon = false;
                    break;
                }
            }
            return isWon;
        }

        public bool RightDiagonalCheck(int column, int row)
        {
            int counter = 0;
            bool isWon = false;
            for (int i = row; i < GameBoard[column].Count; i++)
            {
                if (CompareColors(GetChip(column, i), GetChip(column + 1, i + 1)))
                {
                    counter++;
                    if (counter >= 3)
                    {
                        isWon = true;
                        return isWon;
                    }
                }
                else if (!CompareColors(GetChip(column, i), GetChip(column + 1, i + 1)))
                {
                    isWon = false;
                    break;
                }
            }
            return isWon;
        }

        public bool LeftDiagonalCheck(int column, int row)
        {
            int counter = 0;
            bool isWon = false;
            for (int i = row; i < GameBoard[column].Count; i++)
            {
                if (CompareColors(GetChip(column, i), GetChip(column + 1, i - 1)))
                {
                    counter++;
                    if (counter >= 3)
                    {
                        isWon = true;
                        return isWon;
                    }
                }
                else if (!CompareColors(GetChip(column, i), GetChip(column + 1, i - 1)))
                {
                    isWon = false;
                    break;
                }
            }
            return isWon;
        }

        public bool CheckIfWon()
        {
            bool isWon = false;
            for (int column = 0; column < GameBoard.Count; column++)
            {
                for (int row = 0; row < GameBoard[column].Count; row++)
                {
                    //row bool return method
                    if (CompareColors(GetChip(column, row), GetChip(column + 1, row)))
                    {
                        isWon = RowCheck(column, row);
                        if (isWon == true)
                        {
                            return isWon;
                        }
                    }

                    //column bool return method
                    if (CompareColors(GetChip(column, row), GetChip(column, row + 1)))
                    {
                        isWon = ColumnCheck(column, row);
                        if (isWon == true)
                        {
                            return isWon;
                        }
                    }
                    
                    //diagonal right bool return method
                    if (CompareColors(GetChip(column, row), GetChip(column + 1, row + 1)))
                    {
                        isWon = RightDiagonalCheck(column, row);
                        if (isWon == true)
                        {
                            return isWon;
                        }
                    }

                    //diagonal left bool return method
                    if (CompareColors(GetChip(column, row), GetChip(column + 1, row - 1)))
                    {
                        isWon = LeftDiagonalCheck(column, row);
                        if (isWon == true)
                        {
                            return isWon;
                        }
                    }
                }
            }
            return isWon;
        }

        public void MoveChipMethod(int userInput)
        {
            Chip tempC = new Chip();
            if (Count % 2 == 0)
            {
                tempC.ChipColor = "R";
            }
            else
            {
                tempC.ChipColor = "Y";
            }
            this.GameBoard[userInput].Add(tempC);
        }

        public int GetColumnCount()
        {
            return this.GameBoard.Count;
        }
        public int GetElementCount(int column)
        {
            return this.GameBoard[column].Count;
        }

        #endregion

    }
}