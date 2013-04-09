using System.Collections.Generic;
using Microsoft.SolverFoundation.Services;
namespace Sudoku.Source.Game
{
    public static class DecisionFactory
    {
        private static readonly List<Decision> Decisions = new List<Decision>(9);
        private static Domain domain = Domain.IntegerRange(1, 9);

        static DecisionFactory()
        {
            DecisionFactory.Initialize();
        }

        private static void Initialize()
        {
            if (DecisionFactory.Decisions.Count == 0)
            {
                for (int i = 0; i < 81; i++)
                {
                    DecisionFactory.Decisions.Add(new Decision(domain, Constants.StringAffix + i));
                }
            }
        }

        public static List<Decision> BuildDecisions(List<int> squares)
        {
            if (squares == null || squares.Count == 0)
            {
                return new List<Decision>();
            }

            DecisionFactory.Decisions.Clear();

            foreach (int i in squares)
            {
                DecisionFactory.Decisions.Add(new Decision(DecisionFactory.domain, Constants.StringAffix + i));
            }
            return DecisionFactory.Decisions;
        }
    }
}