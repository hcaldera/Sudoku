using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku.Source.Game
{
    public partial class SudokuSquare : UserControl
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int CorrectValue { get; set; }
        private int startSquarePositionX = Constants.StartSquareX;
        private int startSquarePositionY = Constants.StartSquareY;

        public SudokuSquare()
        {
            InitializeComponent();
        }

        public SudokuSquare(int value, int correctVlue, int row, int column)
        {
            InitializeComponent();
            this.SudokuTextBox.Text = value.ToString();
            this.CorrectValue = correctVlue;
            this.Row = row;
            this.Column = column;
            this.drawSquare();
        }

        private void drawSquare()
        {
            this.positionSquareIntoRegions();
            int x = this.startSquarePositionX + this.Row * (int)this.mainRectangle.Width;
            int y = this.startSquarePositionY + this.Column * (int)this.mainRectangle.Height;
            this.Left = x;
            this.Top = y;
            if (this.SudokuTextBox.Text.Equals(Constants.PlaceHolder.ToString()))
            {
                this.SudokuTextBox.Enabled = true;
                this.SudokuTextBox.Text = String.Empty;
            }
            else
            {
                this.SudokuTextBox.Enabled = false;
            }
            this.SudokuTextBox.TextChanged += SudokuTextBox_TextChanged;
        }

        private void SudokuTextBox_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (!int.TryParse(this.SudokuTextBox.Text, out i))
            {
                this.SudokuTextBox.Text = String.Empty;
                this.mainRectangle.FillGradientColor = Color.MediumBlue;
                this.mainRectangle.BorderColor = Color.MediumBlue;
                return;
            }

            if (this.SudokuTextBox.Text.Equals(this.CorrectValue.ToString()))
            {
                this.mainRectangle.FillGradientColor = Color.Green;
                this.mainRectangle.BorderColor = Color.Green;
            }
            else
            {
                this.mainRectangle.FillGradientColor = Color.Red;
                this.mainRectangle.BorderColor = Color.Red;
            }
        }

        private void positionSquareIntoRegions()
        {
            this.startSquarePositionX += (this.Row / 3) * Constants.SpaceBetweenRegions;
            this.startSquarePositionY += (this.Column / 3) * Constants.SpaceBetweenRegions;
        }

        private void mainRectangle_Click(object sender, EventArgs e)
        {
            this.SudokuTextBox.Focus();
        }

        private void centerRectangle_Click(object sender, EventArgs e)
        {
            this.SudokuTextBox.Focus();
        }
    }
}
