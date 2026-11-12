namespace Rammsonde
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            entriesDataGridView = new System.Windows.Forms.DataGridView();
            distanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            secondsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            depthTextBox = new System.Windows.Forms.TextBox();
            addEntryButton = new System.Windows.Forms.Button();
            speedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            deleteButton = new System.Windows.Forms.Button();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)entriesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)speedNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // entriesDataGridView
            // 
            entriesDataGridView.AllowUserToAddRows = false;
            entriesDataGridView.AllowUserToDeleteRows = false;
            entriesDataGridView.AllowUserToResizeRows = false;
            entriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            entriesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { distanceColumn, secondsColumn });
            entriesDataGridView.Location = new System.Drawing.Point(14, 7);
            entriesDataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            entriesDataGridView.Name = "entriesDataGridView";
            entriesDataGridView.RowHeadersVisible = false;
            entriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            entriesDataGridView.Size = new System.Drawing.Size(259, 411);
            entriesDataGridView.TabIndex = 0;
            entriesDataGridView.CellEndEdit += EntriesDataGridView_CellEndEdit;
            entriesDataGridView.CellValueChanged += EntriesDataGridView_CellValueChanged;
            // 
            // distanceColumn
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.GrayText;
            distanceColumn.DefaultCellStyle = dataGridViewCellStyle1;
            distanceColumn.HeaderText = "[cm]";
            distanceColumn.Name = "distanceColumn";
            distanceColumn.ReadOnly = true;
            // 
            // secondsColumn
            // 
            secondsColumn.HeaderText = "[s]";
            secondsColumn.Name = "secondsColumn";
            // 
            // depthTextBox
            // 
            depthTextBox.Location = new System.Drawing.Point(14, 425);
            depthTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            depthTextBox.Name = "depthTextBox";
            depthTextBox.ReadOnly = true;
            depthTextBox.Size = new System.Drawing.Size(125, 23);
            depthTextBox.TabIndex = 1;
            // 
            // addEntryButton
            // 
            addEntryButton.Location = new System.Drawing.Point(14, 455);
            addEntryButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            addEntryButton.Name = "addEntryButton";
            addEntryButton.Size = new System.Drawing.Size(126, 43);
            addEntryButton.TabIndex = 3;
            addEntryButton.Text = "+";
            addEntryButton.UseVisualStyleBackColor = true;
            addEntryButton.Click += AddEntryButton_Click;
            // 
            // speedNumericUpDown
            // 
            speedNumericUpDown.Location = new System.Drawing.Point(147, 425);
            speedNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            speedNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            speedNumericUpDown.Name = "speedNumericUpDown";
            speedNumericUpDown.Size = new System.Drawing.Size(126, 23);
            speedNumericUpDown.TabIndex = 5;
            speedNumericUpDown.KeyDown += SpeedNumericUpDown_KeyDown;
            speedNumericUpDown.KeyUp += SpeedNumericUpDown_KeyUp;
            // 
            // deleteButton
            // 
            deleteButton.Location = new System.Drawing.Point(147, 455);
            deleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new System.Drawing.Size(126, 43);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "-";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // saveFileDialog
            // 
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = "save.txt";
            saveFileDialog.Filter = "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*";
            // 
            // DataEntryForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(287, 511);
            Controls.Add(deleteButton);
            Controls.Add(speedNumericUpDown);
            Controls.Add(addEntryButton);
            Controls.Add(depthTextBox);
            Controls.Add(entriesDataGridView);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "DataEntryForm";
            Text = "Dateneingabe";
            FormClosing += DataEntryForm_FormClosing;
            Load += DataEntryForm_Load;
            ((System.ComponentModel.ISupportInitialize)entriesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)speedNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
