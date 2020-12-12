using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    class Sudoku
    {
        public static bool IsAnswerValid(int row, int column, int answer, TextBox[,] textboxValue)
        {
            bool rowIsValid = IsRowValid(row, column, answer, textboxValue);
            bool columnIsValid = IsColumnValid(row, column, answer, textboxValue);
            bool matrixIsValid = IsMatrixValid(row, column, answer, textboxValue);
            if (rowIsValid && columnIsValid && matrixIsValid)
            {
                return true;
            }
            return false;
        }

        private static bool IsRowValid(int row, int column, int answer, TextBox[,] textboxValue)
        {
            for (int i = 0; i < textboxValue.GetLength(0); i++)
            {
                if (textboxValue[i, column].Text == answer.ToString() && i != row)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsColumnValid(int row, int column, int answer, TextBox[,] textboxValue)
        {
            for (int col = 0; col < textboxValue.GetLength(1); col++)
            {
                if (textboxValue[row, col].Text == answer.ToString() && col != column)
                    return false;
            }
            return true;
        }

        private static bool IsMatrixValid(int row, int column, int answer, TextBox[,] textboxValue)
        {
            int subMatrix = textboxValue.Length / textboxValue.GetLength(0);
            int subMatrixLength = (int)Math.Sqrt((double)subMatrix);
            int subMatrixRow = 0;
            int subMatrixCol = 0;

            GetSubMatrixRowAndColumn(subMatrixLength, row, column, ref subMatrixRow, ref subMatrixCol);

           int subMatrixRowLength = subMatrixLength + subMatrixRow;
           int subMatrixColLength = subMatrixLength + subMatrixCol;
            for (; subMatrixRow < subMatrixRowLength; subMatrixRow++)
            {
                for (int j = subMatrixCol; j < subMatrixColLength; j++)
                {
                    if (textboxValue[subMatrixRow, j].Text == answer.ToString() && (subMatrixRow != row || j != column))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void GetSubMatrixRowAndColumn(int quaterMatrixLength, int row, int column, ref int i, ref int col)
        {
            if (row < quaterMatrixLength && column < quaterMatrixLength)
            {
                i = col = 0;
            }
            else if (row < quaterMatrixLength && column >= quaterMatrixLength)
            {
                i = 0;
                col = 2;
            }
            else if (row >= quaterMatrixLength && column < quaterMatrixLength)
            {
                i = 2;
                col = 0;
            }
            else if (row >= quaterMatrixLength && column >= quaterMatrixLength)
            {
                i = 2;
                col = 2;
            }
        }
    }
}
