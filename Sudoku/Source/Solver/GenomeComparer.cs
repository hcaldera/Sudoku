using System;
using System.Collections.Generic;
using System.IO;

namespace Sudoku.Source.Solver
{
    public sealed class GenomeComparer : IComparer<Genome>
    {
        public GenomeComparer()
        {

        }

        public int Compare(Genome x, Genome y)
        {
            if (x.Fitness > y.Fitness)
            {
                return 1;
            }
            if (x.Fitness == y.Fitness)
            {
                return 0;
            }

            return -1;
        }
    }
}