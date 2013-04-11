using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sudoku.Source.Screens
{
    public partial class MainForm : Form
    {
        private static MainForm _instance;
        private Game.SudokuGrid sudokuGrid;


        public MainForm()
        {
            InitializeComponent();
            this.sudokuGrid = new Sudoku.Source.Game.SudokuGrid();
            this.sudokuGrid.Location = new System.Drawing.Point(0, 30);
            this.sudokuGrid.Name = "sudokuGrid";
            this.sudokuGrid.TabIndex = 0;
            this.Controls.Add(this.sudokuGrid);
        }

        public static MainForm GetInstance()
        {
            if (MainForm._instance == null)
            {
                MainForm._instance = new MainForm();
            }
            return MainForm._instance;
        }
    }
}