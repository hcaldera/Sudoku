using System;
using System.Collections.Generic;
using Microsoft.SolverFoundation.Services;

namespace Sudoku.Source.Game
{
    public static class SudokuProblem
    {
        private static List<int> problem = new List<int>();
        private static List<int> solution = new List<int>();
        private static int hints = 50;

        public static bool IsSolved(List<int> possibleSolution)
        {
            if (possibleSolution == null)
            {
                return false;
            }
            for (int i = 0; i < possibleSolution.Count; i++)
            {
                if (possibleSolution[i] != SudokuProblem.solution[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static void GenerateSudoku()
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
            SudokuProblem.solution = SudokuProblem.ConvertDecisionsToIntegers(decisionList);
        }

        public static void GenerateProblem()
        {
            SudokuProblem.GenerateSudoku();
            SudokuProblem.hideNumbers();
        }

        public static List<int> GetSolution()
        {
            return SudokuProblem.solution;
        }

        public static List<int> GetProblem()
        {
            return SudokuProblem.problem;
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
            List<int> toHide = Utils.GetUniqueRandomNumbers(0, Constants.BoardSize, Constants.BoardSize - SudokuProblem.hints);
            SudokuProblem.problem = new List<int>();
            SudokuProblem.problem.AddRange(SudokuProblem.solution);
            foreach (int hideMe in toHide)
            {
                SudokuProblem.problem[hideMe] = Constants.PlaceHolder;
            }
        }
    }
}