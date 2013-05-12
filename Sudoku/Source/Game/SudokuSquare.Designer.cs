namespace Sudoku.Source.Game
{
    partial class SudokuSquare
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.centerRectangle = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.mainRectangle = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.SudokuTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.centerRectangle,
            this.mainRectangle});
            this.shapeContainer1.Size = new System.Drawing.Size(41, 38);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // centerRectangle
            // 
            this.centerRectangle.BackColor = System.Drawing.Color.White;
            this.centerRectangle.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.centerRectangle.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.centerRectangle.CornerRadius = 6;
            this.centerRectangle.Location = new System.Drawing.Point(8, 7);
            this.centerRectangle.Name = "centerRectangle";
            this.centerRectangle.Size = new System.Drawing.Size(25, 24);
            this.centerRectangle.Click += new System.EventHandler(this.centerRectangle_Click);
            // 
            // mainRectangle
            // 
            this.mainRectangle.BackColor = System.Drawing.Color.Transparent;
            this.mainRectangle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mainRectangle.CornerRadius = 8;
            this.mainRectangle.FillColor = System.Drawing.Color.Transparent;
            this.mainRectangle.FillGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mainRectangle.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Horizontal;
            this.mainRectangle.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.mainRectangle.Location = new System.Drawing.Point(0, 0);
            this.mainRectangle.Name = "mainRectangle";
            this.mainRectangle.Size = new System.Drawing.Size(40, 37);
            this.mainRectangle.Click += new System.EventHandler(this.mainRectangle_Click);
            // 
            // SudokuTextBox
            // 
            this.SudokuTextBox.BackColor = System.Drawing.Color.White;
            this.SudokuTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SudokuTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SudokuTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SudokuTextBox.Location = new System.Drawing.Point(11, 11);
            this.SudokuTextBox.MaxLength = 1;
            this.SudokuTextBox.Name = "SudokuTextBox";
            this.SudokuTextBox.Size = new System.Drawing.Size(18, 19);
            this.SudokuTextBox.TabIndex = 2;
            this.SudokuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SudokuSquare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.SudokuTextBox);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "SudokuSquare";
            this.Size = new System.Drawing.Size(41, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape mainRectangle;
        public System.Windows.Forms.TextBox SudokuTextBox;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape centerRectangle;
    }
}