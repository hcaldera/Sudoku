using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sudoku.Source.Solver;
using Sudoku.Source.Game;

namespace Sudoku.Source.Screens
{
    public partial class MainForm : Form
    {
        private static MainForm _instance;
        private SudokuGrid sudokuGrid;
        private GeneticAlgorithm gA;

        private List<int> defaultProblem;
        private List<int> defaultSolution;
        private bool solving;

        private MainForm()
        {
            InitializeComponent();
            this.solving = false;
            this.sudokuGrid = new SudokuGrid();
            this.sudokuGrid.Location = new System.Drawing.Point(0, 30);
            this.sudokuGrid.Name = "sudokuGrid";
            this.sudokuGrid.TabIndex = 0;
            this.Controls.Add(this.sudokuGrid);

            this.defaultProblem = new List<int>(new int[81] { 0, 1, 0, 0, 0, 0, 0, 0, 0,
                                                              0, 2, 4, 6, 3, 0, 0, 0, 0,
                                                              0, 3, 0, 0, 0, 0, 8, 6, 2,
                                                              0, 0, 0, 0, 0, 7, 0, 5, 0,
                                                              0, 0, 0, 0, 0, 9, 0, 4, 0,
                                                              0, 4, 2, 5, 8, 0, 7, 3, 1,
                                                              0, 0, 1, 0, 0, 0, 0, 0, 0,
                                                              0, 0, 0, 9, 0, 0, 0, 0, 0,
                                                              0, 5, 3, 7, 6, 0, 0, 0, 0 });

            this.defaultSolution = new List<int>(new int[81] { 8, 1, 6, 2, 9, 5, 4, 7, 3,
                                                               7, 2, 4, 6, 3, 8, 1, 9, 5,
                                                               5, 3, 9, 1, 7, 4, 8, 6, 2,
                                                               3, 6, 8, 4, 1, 7, 2, 5, 9,
                                                               1, 7, 5, 3, 2, 9, 6, 4, 8,
                                                               9, 4, 2, 5, 8, 6, 7, 3, 1,
                                                               6, 9, 1, 8, 4, 3, 5, 2, 7,
                                                               4, 8, 7, 9, 5, 2, 3, 1, 6,
                                                               2, 5, 3, 7, 6, 1, 9, 8, 4 });
            //this.sudokuGrid.GenerateSudoku(15);
            this.sudokuGrid.GenerateSudoku(this.defaultProblem, this.defaultSolution);
            gA = new GeneticAlgorithm(0.90, 0.05, 22, 10000, 66);
            gA.FitnessFunction = this.getFitness;
            gA.SolutionFunction = this.solutionFound;
            gA.CrossoverFunction = this.sudokuGrid.Crossover;
            gA.Elitism = true;
        } 

        public static MainForm GetInstance()
        {
            if (MainForm._instance == null)
            {
                MainForm._instance = new MainForm();
            }
            return MainForm._instance;
        }



        private double getFitness(double[] values)
        {
            List<int> intValues = new List<int>();
            for (int i = 0; i < values.Length; i++)
            {
                intValues.Add((int)(9 * values[i]) + 1);
            }

            return this.sudokuGrid.GetAttemptFitness(intValues);
        }

        private void buttonStartSolver_Click(object sender, EventArgs e)
        {
            if (!solving)
            {
                this.solving = true;
                new System.Threading.Thread(() => this.gA.Start()).Start();
            }
        }

        private void solutionFound(bool finished)
        {
            double[] bestDoubleValues;
            List<int> bestIntegerValues = new List<int>();
            bestDoubleValues = this.gA.BestGenome;
            for (int i = 0; i < bestDoubleValues.Length; i++)
            {
                bestIntegerValues.Add((int)(9 * bestDoubleValues[i]) + 1);
            }
            this.sudokuGrid.SetPossibleSolution(bestIntegerValues);
            this.solving = !finished;
            this.Invoke(new MethodInvoker(() =>
            {
                this.labelInfo.Text = "Fitness: " + gA.BestFitness.ToString();
            }));
        }

        private void toolStripButtonGenerate_Click(object sender, EventArgs e)
        {
            if (!solving)
            {
                this.sudokuGrid.GenerateSudoku(15);
            }
        }

        private void toolStripButtonDefault_Click(object sender, EventArgs e)
        {
            if (!solving)
            {
                this.sudokuGrid.GenerateSudoku(this.defaultProblem, this.defaultSolution);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this.solving;
        }
    }
}