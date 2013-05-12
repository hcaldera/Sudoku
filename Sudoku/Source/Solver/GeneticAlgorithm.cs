/****************************************************************************************************************************
 * 1. [Start] Generate random population of n chromosomes (suitable solutions for the problem)
 * 2. [Fitness] Evaluate the fitness f(x) of each chromosome x in the population
 * 3. [New population] Create a new population by repeating following steps until the new population is complete
 *      a. [Selection] Select two parent chromosomes from a population according to their fitness (the better
 *          fitness, the bigger chance to be selected)
 *      b. [Crossover] With a crossover probability cross over the parents to form a new offspring (children).
 *          If no crossover was performed, offspring is an exact copy of parents.
 *      c. [Mutation] With a mutation probability mutate new offspring at each locus (position in chromosome).
 *      d. [Accepting] Place new offspring in a new population
 * 4. [Replace] Use new generated population for a further run of algorithm
 * 5. [Test] If the end condition is satisfied, stop, and return the best solution in current population
 * 6. [Loop] Go to step 2 
 * 
 * Source: http://www.obitko.com/tutorials/genetic-algorithms/ga-basic-description.php#outline
 ****************************************************************************************************************************/

/****************************************************************************************************************************
 * As you can see, the outline of Basic GA is very general. There are many things that can be implemented differently
 * in various problems.
 * First question is how to create chromosomes, what type of encoding choose. With this is connected crossover and
 * mutation.
 * Next questions is how to select parents for crossover. This can be done in many ways, but the main idea is to select
 * the better parents (in hope that the better parents will produce better offspring). Also you may think, that making
 * new population only by new offspring can cause lost of the best chromosome from the last population. This is true, so
 * so called elitism is often used. This means, that at least one best solution is copied without changes to a new
 * population, so the best solution found can survive to end of run.
 * 
 ****************************************************************************************************************************/

using System;
using System.IO;
using System.Collections.Generic;

namespace Sudoku.Source.Solver
{
    internal delegate double GAFunction(double[] values);

    public class GeneticAlgorithm
    {
        private double mutationRate;
        private double crossoverRate;
        private int populationSize;
        private int generationSize;
        private int genomeSize;
        private double totalFitness;
        private bool _elitism;

        private List<Genome> currentGeneration;
        private List<Genome> nextGeneration;
        private List<double> fitnessTable;

        private static Random random = new Random();
        private static GAFunction getFitness;

        public GAFunction FitnessFunction { get { return getFitness; } set { getFitness = value; } }
        public bool Elitism { get { return this._elitism; } set { this._elitism = value; } }

        public GeneticAlgorithm()
        {
            this._elitism = false;
            this.mutationRate = 0.05;
            this.crossoverRate = 0.80;
            this.populationSize = 100;
            this.generationSize = 2000;
        }

        public GeneticAlgorithm(double crossoverRate, double mutationRate, int populationSize, int generationSize, int genomeSize)
        {
            this._elitism = false;
            this.crossoverRate = crossoverRate;
            this.mutationRate = mutationRate;
            this.populationSize = populationSize;
            this.generationSize = generationSize;
            this.genomeSize = genomeSize;
        }

        public void Start()
        {
            if (this.FitnessFunction == null)
            {
                throw new ArgumentException("Need to supply fitness function");
            }

            this.fitnessTable = new List<double>();
            this.currentGeneration = new List<Genome>(this.generationSize);
            this.nextGeneration = new List<Genome>(this.generationSize);
            Genome.CrossoverRate = this.crossoverRate;
            Genome.MutationRate = this.mutationRate;
            this.createGenomes();
            this.rankPopulation();
            for (int i = 0; i < this.generationSize; i++)
            {
                this.createNextGeneration();
                this.rankPopulation();
            }
        }

        private void createGenomes()
        {
            for (int i = 0; i < this.populationSize; i++)
            {
                this.currentGeneration.Add(new Genome(this.genomeSize));
            }
        }

        private void createNextGeneration()
        {
            int pidx1;
            int pidx2;
            this.nextGeneration.Clear();
            Genome genome = null;
            Genome parent1;
            Genome parent2;
            Genome child1;
            Genome child2;

            if(this._elitism)
            {
                genome = this.currentGeneration[this.populationSize - 1];
            }
            for(int i=0;i<this.populationSize;i+=2)
            {
                pidx1 = this.rouletteSelection();
                pidx2 = this.rouletteSelection();
                parent1 = this.currentGeneration[pidx1];
                parent2 = this.currentGeneration[pidx2];
                parent1.Crossover(parent2, out child1, out child2);
                child1.Mutate();
                child2.Mutate();
                this.nextGeneration.Add(child1);
                this.nextGeneration.Add(child2);
            }
            if (this._elitism)
            {
                this.nextGeneration[0] = genome;
            }
            this.currentGeneration.Clear();
            this.currentGeneration = new List<Genome>(this.nextGeneration);
        }

        private void rankPopulation()
        {
            Genome genome;
            double fitness;
            this.totalFitness = 0;
            for (int i = 0; i < this.populationSize; i++)
            {
                genome = this.currentGeneration[i];
                genome.Fitness = this.FitnessFunction(genome.Genes);
                this.totalFitness += genome.Fitness;
            }

            this.currentGeneration.Sort(new GenomeComparer());

            fitness = 0.0;
            this.fitnessTable.Clear();
            for (int i = 0; i < this.populationSize; i++)
            {
                fitness += this.currentGeneration[i].Fitness;
                this.fitnessTable.Add(fitness);
            }
        }

        private int rouletteSelection()
        {
            double randomFitness = random.NextDouble() * this.totalFitness;
            int idx = -1;
            int mid;
            int first = 0;
            int last = this.populationSize - 1;
            mid = (last - first) / 2;

            while ((idx == -1) && (first <= last))
            {
                if (randomFitness < this.fitnessTable[mid])
                {
                    last = mid;
                }
                else if (randomFitness > this.fitnessTable[mid])
                {
                    first = mid;
                }
                else
                {
                    first = mid - 1;
                    last = mid;
                }
                mid = (first + last) / 2;
                if ((last - first) == 1)
                {
                    idx = last;
                }
            }
            return idx;
        }
    }
}