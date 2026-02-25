using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Versioning;

namespace Heiner
{
    [SupportedOSPlatform("windows")]
    public partial class MainForm : Form
    {
        private DataEntryForm _dataEntryForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FilePath == "")
            {
                Properties.Settings.Default.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                MessageBox.Show("Bitte Wähle ein Standartverzeichniss in den Optionen", "Verzeichniss setzen", MessageBoxButtons.OK);
            }
            saveFileDialog.InitialDirectory = Properties.Settings.Default.FilePath;
            openFileDialog.InitialDirectory = Properties.Settings.Default.FilePath;

            _dataEntryForm = new DataEntryForm();
            _dataEntryForm.PlotRequested += (_, args) => DrawRammsondeFromData(args.Data);
            _dataEntryForm.Show(this);
        }

        private void DrawRammsonde(List<(int depth, int value)> data, int max)
        {
            int topMargin = 70, bottomMargin = 50, leftMargin = 50, rightMargin = 50, tickSize = 5, pixelsPerUnit = 6, titleY = 20, extraRows = 2, minX = Properties.Settings.Default.MinX;

            if (minX > max)
                max = minX;

            int ToPixelX(int v) => leftMargin + pixelsPerUnit * v;
            int ToPixelY(int row) => topMargin + pixelsPerUnit * row;

            int width = max * pixelsPerUnit + 2 * leftMargin + rightMargin, height = (data.Count + extraRows) * pixelsPerUnit + topMargin + bottomMargin;

            Bitmap bitmap = new(width, height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            using (Pen pen = new(Color.Black, 1))
            using (StringFormat stringFormat = new())
            using (Font font10 = new("Tahoma", 10))
            using (Font font12 = new("Tahoma", 12))
            using (Font font15 = new("Tahoma", 15))
            {
                graphics.DrawLine(pen, leftMargin, topMargin, leftMargin, ToPixelY(data.Count + extraRows));
                graphics.DrawLine(pen, leftMargin, topMargin, ToPixelX(max), topMargin);
                graphics.DrawLine(pen, ToPixelX(data[0].value), topMargin, ToPixelX(data[0].value), ToPixelY(1));

                for (int i = 10; i < data.Count + extraRows + 1; i += 10)
                    graphics.DrawLine(pen, leftMargin - tickSize, ToPixelY(i), leftMargin, ToPixelY(i));

                for (int j = 1; j < data.Count; j++)
                {
                    int i = data[j].depth / 10;
                    int xCurr = data[j].value == 0 ? ToPixelX(data[j].value) + 1 : ToPixelX(data[j].value);
                    graphics.DrawLine(pen, ToPixelX(data[j - 1].value), ToPixelY(i - 1), xCurr, ToPixelY(i - 1));
                    graphics.DrawLine(pen, xCurr, ToPixelY(i - 1), xCurr, ToPixelY(i));
                }

                graphics.DrawLine(pen, ToPixelX(data[^1].value), ToPixelY(data[^1].depth / 10), leftMargin + 1, ToPixelY(data[^1].depth / 10));

                for (int i = 0; i < max; i += 10)
                    graphics.DrawLine(pen, ToPixelX(i), topMargin - tickSize, ToPixelX(i), topMargin);

                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                stringFormat.Alignment = StringAlignment.Far;

                graphics.DrawString("Eindringungswiederstand", font12, Brushes.Black, new PointF(width - rightMargin, titleY), stringFormat);
                stringFormat.Alignment = StringAlignment.Center;
                graphics.DrawString(chartTitleTextBox.Text, font15, Brushes.Black, new PointF(leftMargin, titleY), stringFormat);
                stringFormat.LineAlignment = StringAlignment.Center;
                graphics.DrawString("[s]/[10cm]", font10, Brushes.Black, new PointF(width - rightMargin + pixelsPerUnit, topMargin), stringFormat);
                graphics.DrawString("Endtiefe", font10, Brushes.Black, new PointF(leftMargin, height - bottomMargin + 15), stringFormat);
                graphics.DrawString(((float)data[^1].depth / 100).ToString("n2") + " m", font10, Brushes.Black, new PointF(leftMargin, height - bottomMargin + 30), stringFormat);
                stringFormat.LineAlignment = StringAlignment.Far;

                for (int i = 0; i < max; i += 10)
                    graphics.DrawString(i.ToString(), font10, Brushes.Black, new PointF(ToPixelX(i) + 2, topMargin - tickSize), stringFormat);

                for (int i = 10; i < data.Count + extraRows + 1; i += 10)
                    graphics.DrawString((i / 10).ToString(), font10, Brushes.Black, new PointF(leftMargin - 3 * tickSize, ToPixelY(i) + tickSize * 2), stringFormat);

                graphics.Flush();
            }

            chartPictureBox.Image?.Dispose();
            chartPictureBox.Image = bitmap;
        }

        private void DrawRammsondeFromFile(object sender, EventArgs e)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Datei konnte nicht gelesen werden:\n{ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<(int depth, int value)> data = [];
            int max = 0;
            for (int lineNum = 0; lineNum < lines.Length; lineNum++)
            {
                string[] parts = lines[lineNum].Split(' ');
                if (parts.Length < 2 || !int.TryParse(parts[0], out int depth) || !int.TryParse(parts[1], out int value))
                {
                    MessageBox.Show($"Ungültiges Format in Zeile {lineNum + 1}:\n\"{lines[lineNum]}\"", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (value > max) max = value;
                data.Add((depth, value));
            }
            DrawRammsonde(data, max);
        }

        private void DrawRammsondeFromData(SortedDictionary<int, int> source)
        {
            if (source.Count == 0) return;
            List<(int depth, int value)> data = [];
            int max = 0;
            foreach (KeyValuePair<int, int> entry in source)
            {
                if (entry.Value > max)
                    max = entry.Value;
                data.Add((entry.Key, entry.Value));
            }
            DrawRammsonde(data, max);
        }

        private void NewDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dataEntryForm.PromptReset();
        }

        private void SaveTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dataEntryForm.PromptSaveTxt();
        }

        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DrawRammsondeFromFile(sender, e);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                chartPictureBox.Image.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(openFileDialog.FileName))
            {
                DrawRammsondeFromFile(sender, e);
            }
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new();
            optionsForm.Show();
        }
    }

}
