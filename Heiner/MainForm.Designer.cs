namespace Heiner
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
            chartPictureBox = new System.Windows.Forms.PictureBox();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            chartTitleTextBox = new System.Windows.Forms.TextBox();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)chartPictureBox).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // chartPictureBox
            // 
            chartPictureBox.Location = new System.Drawing.Point(0, 28);
            chartPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chartPictureBox.Name = "chartPictureBox";
            chartPictureBox.Size = new System.Drawing.Size(381, 303);
            chartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            chartPictureBox.TabIndex = 0;
            chartPictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(444, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { importToolStripMenuItem, newDataToolStripMenuItem, saveTxtToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            fileToolStripMenuItem.Text = "Datei";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            importToolStripMenuItem.Text = "Öffnen";
            importToolStripMenuItem.Click += ImportToolStripMenuItem_Click;
            // 
            // newDataToolStripMenuItem
            // 
            newDataToolStripMenuItem.Name = "newDataToolStripMenuItem";
            newDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            newDataToolStripMenuItem.Text = "Neu";
            newDataToolStripMenuItem.Click += NewDataToolStripMenuItem_Click;
            // 
            // saveTxtToolStripMenuItem
            // 
            saveTxtToolStripMenuItem.Name = "saveTxtToolStripMenuItem";
            saveTxtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            saveTxtToolStripMenuItem.Text = "Speichern (TXT)";
            saveTxtToolStripMenuItem.Click += SaveTxtToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            saveToolStripMenuItem.Text = "Speichern (PNG)";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            optionsToolStripMenuItem.Text = "Optionen";
            optionsToolStripMenuItem.Click += OptionsToolStripMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // saveFileDialog
            // 
            saveFileDialog.DefaultExt = "png";
            saveFileDialog.FileName = "save.png";
            saveFileDialog.Filter = "PNG-Dateien (*.png)|*.png|Alle Dateien (*.*)|*.*";
            // 
            // chartTitleTextBox
            // 
            chartTitleTextBox.Location = new System.Drawing.Point(232, 0);
            chartTitleTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chartTitleTextBox.Name = "chartTitleTextBox";
            chartTitleTextBox.Size = new System.Drawing.Size(32, 23);
            chartTitleTextBox.TabIndex = 2;
            chartTitleTextBox.Text = "R1";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            openToolStripMenuItem.Text = "Öffnen";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(444, 377);
            Controls.Add(chartTitleTextBox);
            Controls.Add(chartPictureBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Diagramm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)chartPictureBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        private System.Windows.Forms.PictureBox chartPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTxtToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox chartTitleTextBox;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}
