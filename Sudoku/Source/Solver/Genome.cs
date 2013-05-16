using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Source.Solver
{
    public class Genome
    {
        private double[] _genes;
        private static double _crossoverRate;
        private static double _mutationRate;
        private int _length;
        private double _fitness;

        private static Random random = new Random();

        public double[] Genes { get { return this._genes; } set { this._genes = value; } }
        public double Fitness { get { return this._fitness; } set { this._fitness = value; } }
        public static double CrossoverRate { get { return Genome._crossoverRate; } set { Genome._crossoverRate = value; } }
        public static double MutationRate { get { return Genome._mutationRate; } set { Genome._mutationRate = value; } }
        public int Length { get { return this._length; } set { this._length = value; } }

        public Genome(int length)
        {
            this._length = length;
            this._genes = new double[length];
            this.createGenes();
        }

        public Genome(int length, bool doCreate)
        {
            this._length = length;
            this._genes = new double[length];
            if (doCreate)
            {
                this.createGenes();
            }
        }

        private void createGenes()
        {
            for (int i = 0; i < this.Length; i++)
            {
                this._genes[i] = Genome.random.NextDouble();
            } 
        }

        public void Crossover(Genome genome2, out Genome child1, out Genome child2)
        {
            int  pos;
            double rndPos = Genome.random.NextDouble();

            child1 = new Genome(this._length, false);
            child2 = new Genome(this._length, false);

            if (GeneticAlgorithm.crossoverFunction == null)
            {
                pos = rndPos < Genome._crossoverRate ? Genome.random.Next(this._length) : this._length;
                for (int i = 0; i < this._length; i++)
                {
                    if (i < pos)
                    {
                        child1.Genes[i] = this.Genes[i];
                        child2.Genes[i] = genome2.Genes[i];
                    }
                    else
                    {
                        child1.Genes[i] = genome2.Genes[i];
                        child2.Genes[i] = this.Genes[i];
                    }
                }
            }
            else
            {
                if (rndPos < Genome._crossoverRate)
                {
                    GeneticAlgorithm.crossoverFunction(this._genes, genome2._genes, child1._genes, child2._genes, 0.5);
                }
                else
                {
                    GeneticAlgorithm.crossoverFunction(this._genes, genome2._genes, child1._genes, child2._genes, 0.99);
                }
            }
        }

        public void Mutate()
        {
            for (int pos = 0; pos < this._length; pos++)
            {
                if (Genome.random.NextDouble() < Genome._mutationRate)
                {
                    this._genes[pos] = Genome.random.NextDouble();
                }
            }
        }
    }
}