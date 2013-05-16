namespace Sudoku.Source.Screens
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonStartSolver = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDefault = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGenerate = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 398);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(385, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelInfo
            // 
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonStartSolver,
            this.toolStripSeparator1,
            this.toolStripButtonGenerate,
            this.toolStripButtonDefault});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(385, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonStartSolver
            // 
            this.buttonStartSolver.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonStartSolver.Image = global::Sudoku.Properties.Resources.cog_go;
            this.buttonStartSolver.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStartSolver.Name = "buttonStartSolver";
            this.buttonStartSolver.Size = new System.Drawing.Size(23, 22);
            this.buttonStartSolver.Text = "Start";
            this.buttonStartSolver.Click += new System.EventHandler(this.buttonStartSolver_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDefault
            // 
            this.toolStripButtonDefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDefault.Image = global::Sudoku.Properties.Resources.arrow_refresh_small;
            this.toolStripButtonDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDefault.Name = "toolStripButtonDefault";
            this.toolStripButtonDefault.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDefault.Text = "Default Problem";
            this.toolStripButtonDefault.Click += new System.EventHandler(this.toolStripButtonDefault_Click);
            // 
            // toolStripButtonGenerate
            // 
            this.toolStripButtonGenerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGenerate.Image = global::Sudoku.Properties.Resources.application_view_tile;
            this.toolStripButtonGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGenerate.Name = "toolStripButtonGenerate";
            this.toolStripButtonGenerate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonGenerate.Text = "Generate New Sudoku";
            this.toolStripButtonGenerate.Click += new System.EventHandler(this.toolStripButtonGenerate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(385, 420);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sudoku";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonStartSolver;
        private System.Windows.Forms.ToolStripStatusLabel labelInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDefault;
        private System.Windows.Forms.ToolStripButton toolStripButtonGenerate;
    }
}