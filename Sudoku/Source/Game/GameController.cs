using System.Collections.Generic;
using System.Windows.Forms;

namespace Sudoku.Source.Game
{
    internal static class GameController
    {
        internal static void GenerateNewGame()
        {
            SudokuProblem.GenerateProblem();
        }

        internal static List<int> GetSudokuSolution()
        {
            if (SudokuProblem.Solution.Count == 0)
            {
                SudokuProblem.GenerateProblem();
            }
            return SudokuProblem.Solution;
        }

        internal static List<int> GetSudokuProblem()
        {
            if (SudokuProblem.Problem.Count == 0)
            {
                SudokuProblem.GenerateProblem();
            }
            return SudokuProblem.Problem;
        }

        internal static void IsSudokuSolved(List<int> solution)
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