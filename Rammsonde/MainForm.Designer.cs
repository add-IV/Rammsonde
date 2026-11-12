namespace Rammsonde
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
            dataEntryPanel = new System.Windows.Forms.Panel();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            oeffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            exportierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportPngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            druckenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            chartTitleTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)chartPictureBox).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            //
            // chartPictureBox
            //
            chartPictureBox.Location = new System.Drawing.Point(291, 28);
            chartPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chartPictureBox.MinimumSize = new System.Drawing.Size(300, 300);
            chartPictureBox.Name = "chartPictureBox";
            chartPictureBox.Size = new System.Drawing.Size(300, 300);
            chartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            chartPictureBox.TabIndex = 0;
            chartPictureBox.TabStop = false;
            //
            // dataEntryPanel
            //
            dataEntryPanel.Location = new System.Drawing.Point(0, 24);
            dataEntryPanel.Name = "dataEntryPanel";
            dataEntryPanel.Size = new System.Drawing.Size(287, 511);
            dataEntryPanel.TabIndex = 3;
            //
            // menuStrip1
            //
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { dateiToolStripMenuItem, optionsToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(444, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            //
            // dateiToolStripMenuItem
            //
            dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                neuToolStripMenuItem,
                oeffnenToolStripMenuItem,
                speichernToolStripMenuItem,
                toolStripSeparator1,
                exportierenToolStripMenuItem,
                druckenToolStripMenuItem,
                toolStripSeparator2,
                beendenToolStripMenuItem
            });
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            dateiToolStripMenuItem.Text = "Datei";
            //
            // neuToolStripMenuItem
            //
            neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            neuToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            neuToolStripMenuItem.Text = "Neu";
            neuToolStripMenuItem.Click += NewDataToolStripMenuItem_Click;
            //
            // oeffnenToolStripMenuItem
            //
            oeffnenToolStripMenuItem.Name = "oeffnenToolStripMenuItem";
            oeffnenToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            oeffnenToolStripMenuItem.Text = "Öffnen";
            oeffnenToolStripMenuItem.Click += ImportToolStripMenuItem_Click;
            //
            // speichernToolStripMenuItem
            //
            speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            speichernToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            speichernToolStripMenuItem.Text = "Speichern";
            speichernToolStripMenuItem.Click += SaveTxtToolStripMenuItem_Click;
            //
            // toolStripSeparator1
            //
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            //
            // exportierenToolStripMenuItem
            //
            exportierenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                exportPngToolStripMenuItem,
                exportPdfToolStripMenuItem
            });
            exportierenToolStripMenuItem.Name = "exportierenToolStripMenuItem";
            exportierenToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            exportierenToolStripMenuItem.Text = "Exportieren";
            //
            // exportPngToolStripMenuItem
            //
            exportPngToolStripMenuItem.Name = "exportPngToolStripMenuItem";
            exportPngToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            exportPngToolStripMenuItem.Text = "PNG";
            exportPngToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            //
            // exportPdfToolStripMenuItem
            //
            exportPdfToolStripMenuItem.Name = "exportPdfToolStripMenuItem";
            exportPdfToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            exportPdfToolStripMenuItem.Text = "PDF";
            exportPdfToolStripMenuItem.Click += SavePdfToolStripMenuItem_Click;
            //
            // druckenToolStripMenuItem
            //
            druckenToolStripMenuItem.Name = "druckenToolStripMenuItem";
            druckenToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            druckenToolStripMenuItem.Text = "Drucken";
            druckenToolStripMenuItem.Click += PrintToolStripMenuItem_Click;
            //
            // toolStripSeparator2
            //
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            //
            // beendenToolStripMenuItem
            //
            beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            beendenToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            beendenToolStripMenuItem.Text = "Beenden";
            beendenToolStripMenuItem.Click += BeendenToolStripMenuItem_Click;
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
            chartTitleTextBox.Location = new System.Drawing.Point(292, 0);
            chartTitleTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chartTitleTextBox.Name = "chartTitleTextBox";
            chartTitleTextBox.Size = new System.Drawing.Size(51, 23);
            chartTitleTextBox.TabIndex = 2;
            chartTitleTextBox.Text = "R1";
            chartTitleTextBox.TextChanged += ChartTitleTextBox_TextChanged;
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
            Controls.Add(dataEntryPanel);
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

        private System.Windows.Forms.Panel dataEntryPanel;
        private System.Windows.Forms.PictureBox chartPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oeffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem druckenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox chartTitleTextBox;
    }
}
