using System.Collections.Generic;
using System.Windows.Forms;

namespace Sudoku.Source.Game
{
    public static class GameController
    {
        public static void GenerateNewGame()
        {
            SudokuProblem.GenerateProblem();
        }

        public static List<int> GetSudokuSolution()
        {
            if (SudokuProblem.GetSolution().Count == 0)
            {
                SudokuProblem.GenerateProblem();
            }
            return SudokuProblem.GetSolution();
        }

        public static List<int> GetSudokuProblem()
        {
            if (SudokuProblem.GetProblem().Count == 0)
            {
                SudokuProblem.GenerateProblem();
            }
            return SudokuProblem.GetProblem();
        }

        public static void IsSudokuSolved(List<int> solution)
        {
            if (solution == null)
            {
                return;
            }
            if (!solution.Contains(Constants.PlaceHolder))
            {
                if (SudokuProblem.IsSolved(solution))
                {
                    MessageBox.Show(Sudoku.Source.Screens.MainForm.GetInstance(), "Congratulations!");
                }
            }
        }
    }
}