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

        private MainForm()
        {
            InitializeComponent();
            this.sudokuGrid = new SudokuGrid();
            this.sudokuGrid.Location = new System.Drawing.Point(0, 30);
            this.sudokuGrid.Name = "sudokuGrid";
            this.sudokuGrid.TabIndex = 0;
            this.Controls.Add(this.sudokuGrid);
            this.sudokuGrid.Hints = 15;
            gA = new GeneticAlgorithm(0.90, 0.05, 21, 10000, 66);
            gA.FitnessFunction = this.getFitness;
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
            double[] bestDoubleValues;
            List<int> bestIntegerValues = new List<int>();
            this.gA.Start();
            bestDoubleValues = this.gA.BestGenome;
            for (int i = 0; i < bestDoubleValues.Length; i++)
            {
                bestIntegerValues.Add((int)(9 * bestDoubleValues[i]) + 1);
            }
            this.sudokuGrid.SetPossibleSolution(bestIntegerValues);
        }
    }
}