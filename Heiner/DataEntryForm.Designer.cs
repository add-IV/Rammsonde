namespace Heiner
{
    partial class DataEntryForm
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
            System.Windows.Forms.DataGridViewCellStyle distanceCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.entriesDataGridView = new System.Windows.Forms.DataGridView();
            this.distanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depthTextBox = new System.Windows.Forms.TextBox();
            this.addEntryButton = new System.Windows.Forms.Button();
            this.speedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.entriesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedNumericUpDown)).BeginInit();
            this.SuspendLayout();
            //
            // entriesDataGridView
            //
            this.entriesDataGridView.AllowUserToAddRows = false;
            this.entriesDataGridView.AllowUserToDeleteRows = false;
            this.entriesDataGridView.AllowUserToResizeRows = false;
            this.entriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entriesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.distanceColumn,
            this.secondsColumn});
            this.entriesDataGridView.Location = new System.Drawing.Point(12, 6);
            this.entriesDataGridView.Name = "entriesDataGridView";
            this.entriesDataGridView.RowHeadersVisible = false;
            this.entriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.entriesDataGridView.Size = new System.Drawing.Size(222, 356);
            this.entriesDataGridView.TabIndex = 0;
            this.entriesDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.EntriesDataGridView_CellValueChanged);
            this.entriesDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EntriesDataGridView_CellEndEdit);
            //
            // distanceColumn
            //
            distanceCellStyle.BackColor = System.Drawing.SystemColors.Control;
            distanceCellStyle.ForeColor = System.Drawing.SystemColors.GrayText;
            this.distanceColumn.DefaultCellStyle = distanceCellStyle;
            this.distanceColumn.HeaderText = "[cm]";
            this.distanceColumn.Name = "distanceColumn";
            this.distanceColumn.ReadOnly = true;
            this.distanceColumn.Width = 100;
            //
            // secondsColumn
            //
            this.secondsColumn.HeaderText = "[s]";
            this.secondsColumn.Name = "secondsColumn";
            this.secondsColumn.Width = 100;
            //
            // depthTextBox
            //
            this.depthTextBox.Location = new System.Drawing.Point(12, 368);
            this.depthTextBox.Name = "depthTextBox";
            this.depthTextBox.ReadOnly = true;
            this.depthTextBox.Size = new System.Drawing.Size(108, 20);
            this.depthTextBox.TabIndex = 1;
            //
            // addEntryButton
            //
            this.addEntryButton.Location = new System.Drawing.Point(12, 394);
            this.addEntryButton.Name = "addEntryButton";
            this.addEntryButton.Size = new System.Drawing.Size(108, 37);
            this.addEntryButton.TabIndex = 3;
            this.addEntryButton.Text = "+";
            this.addEntryButton.UseVisualStyleBackColor = true;
            this.addEntryButton.Click += new System.EventHandler(this.AddEntryButton_Click);
            //
            // speedNumericUpDown
            //
            this.speedNumericUpDown.Location = new System.Drawing.Point(126, 368);
            this.speedNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speedNumericUpDown.Name = "speedNumericUpDown";
            this.speedNumericUpDown.Size = new System.Drawing.Size(108, 20);
            this.speedNumericUpDown.TabIndex = 5;
            this.speedNumericUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpeedNumericUpDown_KeyDown);
            this.speedNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SpeedNumericUpDown_KeyUp);
            //
            // deleteButton
            //
            this.deleteButton.Location = new System.Drawing.Point(126, 394);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(108, 37);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "-";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            //
            // saveFileDialog
            //
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.FileName = "save.txt";
            this.saveFileDialog.Filter = "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*";
            //
            // DataEntryForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 443);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.speedNumericUpDown);
            this.Controls.Add(this.addEntryButton);
            this.Controls.Add(this.depthTextBox);
            this.Controls.Add(this.entriesDataGridView);
            this.Name = "DataEntryForm";
            this.Text = "Dateneingabe";
            this.Load += new System.EventHandler(this.DataEntryForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataEntryForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.entriesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView entriesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondsColumn;
        private System.Windows.Forms.TextBox depthTextBox;
        private System.Windows.Forms.Button addEntryButton;
        private System.Windows.Forms.NumericUpDown speedNumericUpDown;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}
