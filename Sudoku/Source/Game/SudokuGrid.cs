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