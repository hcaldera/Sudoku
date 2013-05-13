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

        public SudokuGrid()
        {
            InitializeComponent();
            this.solution = GameController.GetSudokuSolution();
            this.problem = GameController.GetSudokuProblem();
            this.drawSquare();
        }

        public void SetPossibleSolution(List<int> values)
        {
            int index = 0;
            for (int i = 0; i < this.problem.Count; i++)
            {
                if (problem[i] == Constants.PlaceHolder)
                {
                    this.sudokuSquares[i].SudokuTextBox.Text = values[index++].ToString();
                }
            }
        }

        public double GetAttemptFitness(List<int> values)
        {
            int totalRepeated;
            List<int> indexes;
            List<int> possibleValues = new List<int>(new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            List<int> possibleValuesTemp;
            int j = 0;
            this.attempt = new List<int>();
            for (int i = 0; i < this.problem.Count; i++)
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

            totalRepeated = 0;
            for (int i = 0; i < 9; i++)
            {
                // Rows.
                indexes = new List<int>(Grid.GetRow(i));
                possibleValuesTemp = new List<int>(possibleValues);
                foreach (int index in indexes)
                {
                    possibleValuesTemp.Remove(attempt[index]);
                }
                totalRepeated += possibleValuesTemp.Count;
                // Columns.
                indexes = new List<int>(Grid.GetColumn(i));
                possibleValuesTemp = new List<int>(possibleValues);
                foreach (int index in indexes)
                {
                    possibleValuesTemp.Remove(attempt[index]);
                }
                totalRepeated += possibleValuesTemp.Count;
                // Regions.
                indexes = new List<int>(Grid.GetRegion(i));
                possibleValuesTemp = new List<int>(possibleValues);
                foreach (int index in indexes)
                {
                    possibleValuesTemp.Remove(attempt[index]);
                }
                totalRepeated += possibleValuesTemp.Count;
            }

            // Return fitness.
            return 1 - totalRepeated / 243.00;
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

        private void drawSquare()
        {
            int squareNumber = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    SudokuSquare sudokuSquare = new SudokuSquare(this.problem[squareNumber], this.solution[squareNumber], row, column);
                    sudokuSquare.SudokuTextBox.TextChanged += new EventHandler(TextChange);
                    this.sudokuSquares.Add(sudokuSquare);
                    this.Controls.Add(sudokuSquare);
                    squareNumber++;
                }
            }
        }

        private void TextChange(object sender, EventArgs e)
        {
            this.getPossibleSolution();
            GameController.IsSudokuSolved(attempt);
        }
    }
}