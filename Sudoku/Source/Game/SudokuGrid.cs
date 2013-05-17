using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku.Source.Game
{
    public partial class SudokuGrid : UserControl
    {
        private List<SudokuSquare> sudokuSquares = new List<SudokuSquare>();
        private List<int> solution = new List<int>();
        private List<int> attempt = new List<int>();
        private List<int> problem = new List<int>();
        private List<Point> positionList = new List<Point>();
        private bool squaresDrawed;

        public int Hints { get { return SudokuProblem.Hints; } set { SudokuProblem.Hints = value; } }

        public SudokuGrid()
        {
            InitializeComponent();
            this.squaresDrawed = false;
        }

        public void GenerateSudoku(int hints)
        {
            this.Hints = hints;
            GameController.GenerateNewGame();
            this.solution = GameController.GetSudokuSolution();
            this.problem = GameController.GetSudokuProblem();
            if (!squaresDrawed)
            {
                this.drawSquares();
            }
            else
            {
                for (int i = 0; i < this.problem.Count; i++)
                {
                    this.sudokuSquares[i].ChangeSquare(this.problem[i], this.solution[i]);
                }
            }
        }

        public void GenerateSudoku(List<int> newProblem, List<int> newSolution)
        {
            if (newProblem.Count == newSolution.Count)
            {
                this.problem = new List<int>(newProblem);
                this.solution = new List<int>(newSolution);
                SudokuProblem.Solution = new List<int>(newProblem);
                SudokuProblem.Solution = new List<int>(newSolution);
                if (!squaresDrawed)
                {
                    this.drawSquares();
                }
                else
                {
                    for (int i = 0; i < newProblem.Count; i++)
                    {
                        this.sudokuSquares[i].ChangeSquare(newProblem[i], newSolution[i]);
                    }
                }
            }
        }

        public void SetPossibleSolution(List<int> values)
        {
            int index = 0;
            for (int i = 0; i < this.problem.Count; i++)
            {
                if (problem[i] == Constants.PlaceHolder)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        this.sudokuSquares[i].SudokuTextBox.Text = values[index++].ToString();
                    }));
                }
            }
        }

        public double GetAttemptFitness(List<int> values)
        {
            //int totalRepeated;
            //List<int> indexes;
            //List<int> possibleValues = new List<int>(new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            //List<int> possibleValuesTemp;
            //int j = 0;
            //this.attempt = new List<int>();
            //for (int i = 0; i < this.problem.Count; i++)
            //{
            //    if (problem[i] == Constants.PlaceHolder)
            //    {
            //        this.attempt.Add(values[j++]);
            //    }
            //    else
            //    {
            //        this.attempt.Add(this.problem[i]);
            //    }
            //}

            //totalRepeated = 0;
            //for (int i = 0; i < 9; i++)
            //{
            //    // Rows.
            //    indexes = new List<int>(Grid.GetRow(i));
            //    possibleValuesTemp = new List<int>(possibleValues);
            //    foreach (int index in indexes)
            //    {
            //        possibleValuesTemp.Remove(attempt[index]);
            //    }
            //    totalRepeated += possibleValuesTemp.Count;
            //    // Columns.
            //    indexes = new List<int>(Grid.GetColumn(i));
            //    possibleValuesTemp = new List<int>(possibleValues);
            //    foreach (int index in indexes)
            //    {
            //        possibleValuesTemp.Remove(attempt[index]);
            //    }
            //    totalRepeated += possibleValuesTemp.Count;
            //    // Regions.
            //    indexes = new List<int>(Grid.GetRegion(i));
            //    possibleValuesTemp = new List<int>(possibleValues);
            //    foreach (int index in indexes)
            //    {
            //        possibleValuesTemp.Remove(attempt[index]);
            //    }
            //    totalRepeated += possibleValuesTemp.Count;
            //}

            //// Return fitness.
            //return 1 - totalRepeated / 243.00;

            double totalWrong = 0.0;

            int j = 0;
            this.attempt = new List<int>();
            for (int i = 0; i < Constants.BoardSize; i++)
            {
                if (problem[i] == Constants.PlaceHolder)
                {
                    this.attempt.Add(values[j++]);
                }
                else
                {
                    this.attempt.Add(this.problem[i]);
                }
            }

            for (int i = 0; i < Constants.BoardSize; i++)
            {
                if (this.attempt[i] != this.solution[i])
                {
                    totalWrong++;
                }
            }
            return 1 - (totalWrong / Constants.BoardSize);
        }

        public void Crossover(double[] p1, double[] p2, double[] c1, double[] c2, double crossPoint)
        {
            double[] parent1 = new double[Constants.BoardSize];
            double[] parent2 = new double[Constants.BoardSize];
            double[] child1 = new double[Constants.BoardSize];
            double[] child2 = new double[Constants.BoardSize];
            List<int> indexes;

            int idx = 0;
            for (int i = 0; i < Constants.BoardSize; i++)
            {
                if (this.problem[i] == Constants.PlaceHolder)
                {
                    parent1[i] = p1[idx];
                    parent2[i] = p2[idx++];
                }
            }

            int iCrossPoint = (int)(9 * crossPoint) + 1;
            for (int i = 0; i < iCrossPoint; i++)
            {
                indexes = Grid.GetRegion(i);
                foreach (int index in indexes)
                {
                    child1[index] = parent1[index];
                    child2[index] = parent2[index];
                }
            }
            for (int i = 5; i < 9; i++)
            {
                indexes = Grid.GetRegion(i);
                foreach (int index in indexes)
                {
                    child1[index] = parent2[index];
                    child2[index] = parent1[index];
                }

            }

            idx = 0;
            for (int i = 0; i < Constants.BoardSize; i++)
            {
                if (this.problem[i] == Constants.PlaceHolder)
                {
                    c1[idx] = child1[i];
                    c2[idx++] = child2[i];
                }
            }
        }

        private void getPossibleSolution()
        {
            this.attempt = new List<int>();
            int input = 0;
            foreach (SudokuSquare square in this.sudokuSquares)
            {
                Int32.TryParse((square.SudokuTextBox.Text), out input);
                attempt.Add(input);
            }
        }

        private void drawSquares()
        {
            SudokuSquare sudokuSquare;
            int squareNumber = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    sudokuSquare = new SudokuSquare(this.problem[squareNumber], this.solution[squareNumber], row, column);
                    sudokuSquare.SudokuTextBox.TextChanged += new EventHandler(TextChange);
                    this.sudokuSquares.Add(sudokuSquare);
                    this.Controls.Add(sudokuSquare);
                    squareNumber++;
                }
            }
            this.squaresDrawed = true;
        }

        private void TextChange(object sender, EventArgs e)
        {
            if (!(sender as TextBox).Text.Equals(String.Empty))
            {
                this.getPossibleSolution();
                GameController.IsSudokuSolved(attempt);
            }
        }
    }
}