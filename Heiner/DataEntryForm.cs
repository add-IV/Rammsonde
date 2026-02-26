using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Versioning;

namespace Heiner
{
    [SupportedOSPlatform("windows")]
    public partial class DataEntryForm : Form
    {
        private const int DepthStepCm = 10;
        private readonly SortedDictionary<int, int> _data = [];

        public DataEntryForm()
        {
            InitializeComponent();
        }

        private void DataEntryForm_Load(object sender, EventArgs e)
        {
            depthTextBox.Text = DepthStepCm.ToString();
            saveFileDialog.InitialDirectory = Properties.Settings.Default.FilePath;
        }

        private void AddEntryButton_Click(object sender, EventArgs e)
        {
            int depthCm = (entriesDataGridView.Rows.Count + 1) * DepthStepCm;
            int seconds = (int)speedNumericUpDown.Value;
            entriesDataGridView.Rows.Add(depthCm, seconds);
            _data[depthCm] = seconds;
            depthTextBox.Text = (depthCm + DepthStepCm).ToString();
            entriesDataGridView.FirstDisplayedScrollingRowIndex = entriesDataGridView.Rows.Count - 1;
            speedNumericUpDown.Select();
            speedNumericUpDown.Select(0, speedNumericUpDown.Text.Length);
            PlotRequested?.Invoke(this, new MeasurementEventArgs(_data));
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (entriesDataGridView.Rows.Count == 0)
                return;
            int lastIndex = entriesDataGridView.Rows.Count - 1;
            int depthCm = (lastIndex + 1) * DepthStepCm;
            _data.Remove(depthCm);
            entriesDataGridView.Rows.RemoveAt(lastIndex);
            depthTextBox.Text = entriesDataGridView.Rows.Count > 0
                ? (entriesDataGridView.Rows.Count * DepthStepCm + DepthStepCm).ToString()
                : DepthStepCm.ToString();
            PlotRequested?.Invoke(this, new MeasurementEventArgs(_data));
        }

        private void EntriesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 || e.RowIndex < 0) return;
            int depthCm = (e.RowIndex + 1) * DepthStepCm;
            if (int.TryParse(entriesDataGridView.Rows[e.RowIndex].Cells[1].Value?.ToString(), out int seconds))
                _data[depthCm] = seconds;
        }

        private void EntriesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
                PlotRequested?.Invoke(this, new MeasurementEventArgs(_data));
        }

        public void PromptReset()
        {
            if (MessageBox.Show("Alle Einträge löschen?", "Neu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                entriesDataGridView.Rows.Clear();
                _data.Clear();
                depthTextBox.Text = DepthStepCm.ToString();
            }
        }

        public void PromptSaveTxt()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using var writer = new StreamWriter(saveFileDialog.FileName);
                foreach (DataGridViewRow row in entriesDataGridView.Rows)
                    writer.WriteLine(row.Cells[0].Value + " " + row.Cells[1].Value);
            }
        }

        private void SpeedNumericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.Handled = e.SuppressKeyPress = true;
        }

        private void SpeedNumericUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                AddEntryButton_Click(sender, e);
            }
        }

        private void DataEntryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        public void SetData(SortedDictionary<int, int> data)
        {
            entriesDataGridView.Rows.Clear();
            _data.Clear();
            foreach (var (depth, value) in data)
            {
                entriesDataGridView.Rows.Add(depth, value);
                _data[depth] = value;
            }
            if (entriesDataGridView.Rows.Count > 0)
                entriesDataGridView.FirstDisplayedScrollingRowIndex = entriesDataGridView.Rows.Count - 1;
            depthTextBox.Text = _data.Count > 0
                ? (_data.Keys.Last() + DepthStepCm).ToString()
                : DepthStepCm.ToString();
            PlotRequested?.Invoke(this, new MeasurementEventArgs(_data));
        }

        public void TriggerPlot() => PlotRequested?.Invoke(this, new MeasurementEventArgs(_data));

        public event EventHandler<MeasurementEventArgs> PlotRequested;
    }

    public class MeasurementEventArgs(SortedDictionary<int, int> data) : EventArgs
    {
        public SortedDictionary<int, int> Data { get; } = data;
    }
}
