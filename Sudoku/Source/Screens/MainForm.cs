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

        public MainForm()
        {
            InitializeComponent();
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