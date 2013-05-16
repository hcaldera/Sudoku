using System;
using System.Collections.Generic;
using Microsoft.SolverFoundation.Services;

namespace Sudoku.Source.Game
{
    internal static class SudokuProblem
    {
        private static List<int> _problem = new List<int>();
        private static List<int> _solution = new List<int>();
        private static int _hints;

        internal static List<int> Problem { get { return SudokuProblem._problem; } }
        internal static List<int> Solution { get { return SudokuProblem._solution; } }
        internal static int Hints { get { return SudokuProblem._hints; } set { SudokuProblem._hints = value; } }

        internal static bool IsSolved(List<int> possibleSolution)
        {
            if ((possibleSolution == null) || possibleSolution.Contains(Constants.PlaceHolder))
            {
                return false;
            }
            for (int i = 0; i < possibleSolution.Count; i++)
            {
                if (possibleSolution[i] != SudokuProblem._solution[i])
                {
                    return false;
                }
            }
            return true;
        }

        internal static void GenerateSudoku()
        {
            SolverContext context = SolverContext.GetContext();
            Model model = context.CreateModel();

            List<Decision> decisionList = DecisionFactory.BuildDecisions(Grid.GetAllSquares());
            model.AddDecisions(decisionList.ToArray());

            // Add constraints to model.
            for (int j = 0; j < 9; j++)
            {
                model.AddConstraints("constraint_" + j,
                    Model.AllDifferent(SudokuProblem.getDecision(decisionList, Grid.GetRow(j))),
                    Model.AllDifferent(SudokuProblem.getDecision(decisionList, Grid.GetColumn(j))),
                    Model.AllDifferent(SudokuProblem.getDecision(decisionList, Grid.GetRegion(j)))
                  );
            }

            // Add seeds to model.
            List<int> seedValues = Utils.GetUniqueRandomNumbers(1, 10, 9);
            for (int i = 0; i < 9; i++)
            {
                model.AddConstraints("seed_" + i.ToString(), decisionList[i] == seedValues[i]);
            }

            context.Solve(new ConstraintProgrammingDirective());
            SudokuProblem._solution = SudokuProblem.ConvertDecisionsToIntegers(decisionList);
        }

        internal static void GenerateProblem()
        {
            SudokuProblem.GenerateSudoku();
            SudokuProblem.hideNumbers();
        }

        private static List<int> ConvertDecisionsToIntegers(List<Decision> decisionList)
        {
            List<int> results = new List<int>();
            foreach (Decision decision in decisionList)
            {
                results.Add(Convert.ToInt32(decision.ToString()));
            }
            return results;
        }

        private static Term[] getDecision(List<Decision> decisionList, List<int> indexes)
        {
            Term[] results = new Term[9];
            int i = 0;
            foreach (int index in indexes)
            {
                results[i] = decisionList[index];
                i++;
            }
            return results;
        }

        private static void hideNumbers()
        {
            List<int> toHide = Utils.GetUniqueRandomNumbers(0, Constants.BoardSize, Constants.BoardSize - SudokuProblem._hints);
            SudokuProblem._problem = new List<int>();
            SudokuProblem._problem.AddRange(SudokuProblem._solution);
            foreach (int hideMe in toHide)
            {
                SudokuProblem._problem[hideMe] = Constants.PlaceHolder;
            }
        }
    }
}