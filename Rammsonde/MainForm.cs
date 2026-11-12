using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Versioning;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace Heiner
{
    [SupportedOSPlatform("windows")]
    public partial class MainForm : Form
    {
        private DataEntryForm _dataEntryForm;
        private List<(int depth, int value)> _renderData = [];
        private int _renderMax = 0;

        public MainForm()
        {
            InitializeComponent();
            DrawRammsondeFromData([]);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (Properties.Settings.Default.FilePath == "")
            {
                Properties.Settings.Default.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                MessageBox.Show("Bitte wähle ein Standardverzeichnis in den Optionen", "Verzeichnis setzen", MessageBoxButtons.OK);
            }
            saveFileDialog.InitialDirectory = Properties.Settings.Default.FilePath;
            openFileDialog.InitialDirectory = Properties.Settings.Default.FilePath;

            _dataEntryForm = new DataEntryForm();
            _dataEntryForm.PlotRequested += (_, args) => DrawRammsondeFromData(args.Data);
            _dataEntryForm.TopLevel = false;
            _dataEntryForm.FormBorderStyle = FormBorderStyle.None;
            _dataEntryForm.Dock = DockStyle.Fill;
            dataEntryPanel.Controls.Add(_dataEntryForm);
            _dataEntryForm.Show();
        }

        private Bitmap RenderBitmap(List<(int depth, int value)> data, int max, int scale)
        {
            int ppu = 6 * scale;
            int topMargin = 70 * scale, bottomMargin = 50 * scale, leftMargin = 50 * scale, rightMargin = 50 * scale;
            int tickSize = 5 * scale, titleY = 20 * scale, extraRows = 2;
            int minX = Properties.Settings.Default.MinX;

            if (minX > max)
                max = minX;

            int ToPixelX(int v) => leftMargin + ppu * v;
            int ToPixelY(int row) => topMargin + ppu * row;

            int width = max * ppu + 2 * leftMargin + rightMargin, height = (data.Count + extraRows) * ppu + topMargin + bottomMargin;

            Bitmap bitmap = new(width, height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            using (Pen pen = new(Color.Black, scale))
            using (StringFormat stringFormat = new())
            using (Font font10 = new("Tahoma", 10 * scale))
            using (Font font12 = new("Tahoma", 12 * scale))
            using (Font font15 = new("Tahoma", 15 * scale))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                graphics.DrawLine(pen, leftMargin, topMargin, leftMargin, ToPixelY(data.Count + extraRows));
                graphics.DrawLine(pen, leftMargin, topMargin, ToPixelX(max), topMargin);
                if (data.Count > 0)
                {
                    graphics.DrawLine(pen, ToPixelX(data[0].value), topMargin, ToPixelX(data[0].value), ToPixelY(1));

                    for (int i = 10; i < data.Count + extraRows + 1; i += 10)
                        graphics.DrawLine(pen, leftMargin - tickSize, ToPixelY(i), leftMargin, ToPixelY(i));

                    for (int j = 1; j < data.Count; j++)
                    {
                        int i = data[j].depth / 10;
                        int xCurr = data[j].value == 0 ? ToPixelX(data[j].value) + scale : ToPixelX(data[j].value);
                        graphics.DrawLine(pen, ToPixelX(data[j - 1].value), ToPixelY(i - 1), xCurr, ToPixelY(i - 1));
                        graphics.DrawLine(pen, xCurr, ToPixelY(i - 1), xCurr, ToPixelY(i));
                    }

                    graphics.DrawLine(pen, ToPixelX(data[^1].value), ToPixelY(data[^1].depth / 10), leftMargin + scale, ToPixelY(data[^1].depth / 10));
                }
                for (int i = 0; i < max; i += 10)
                    graphics.DrawLine(pen, ToPixelX(i), topMargin - tickSize, ToPixelX(i), topMargin);

                stringFormat.Alignment = StringAlignment.Far;

                graphics.DrawString("Eindringungswiderstand", font12, Brushes.Black, new PointF(width - rightMargin, titleY), stringFormat);
                stringFormat.Alignment = StringAlignment.Center;
                graphics.DrawString(chartTitleTextBox.Text, font15, Brushes.Black, new PointF(leftMargin, titleY), stringFormat);
                stringFormat.LineAlignment = StringAlignment.Center;
                graphics.DrawString("[s]/[10cm]", font10, Brushes.Black, new PointF(width - rightMargin + ppu, topMargin), stringFormat);
                graphics.DrawString("Endtiefe", font10, Brushes.Black, new PointF(leftMargin, height - bottomMargin + 15 * scale), stringFormat);
                if (data.Count > 0)
                    graphics.DrawString(((float)data[^1].depth / 100).ToString("n2") + " m", font10, Brushes.Black, new PointF(leftMargin, height - bottomMargin + 30 * scale), stringFormat);
                stringFormat.LineAlignment = StringAlignment.Far;

                for (int i = 0; i < max; i += 10)
                    graphics.DrawString(i.ToString(), font10, Brushes.Black, new PointF(ToPixelX(i) + 2 * scale, topMargin - tickSize), stringFormat);

                for (int i = 10; i < data.Count + extraRows + 1; i += 10)
                    graphics.DrawString((i / 10).ToString(), font10, Brushes.Black, new PointF(leftMargin - 3 * tickSize, ToPixelY(i) + tickSize * 2), stringFormat);

                graphics.Flush();
            }

            return bitmap;
        }

        private void DrawRammsonde(List<(int depth, int value)> data, int max)
        {
            chartPictureBox.Image?.Dispose();
            chartPictureBox.Image = RenderBitmap(data, max, 1);
        }

        private void DrawRammsondeFromFile()
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

            SortedDictionary<int, int> data = [];
            for (int lineNum = 0; lineNum < lines.Length; lineNum++)
            {
                string[] parts = lines[lineNum].Split(' ');
                if (parts.Length < 2 || !int.TryParse(parts[0], out int depth) || !int.TryParse(parts[1], out int value))
                {
                    MessageBox.Show($"Ungültiges Format in Zeile {lineNum + 1}:\n\"{lines[lineNum]}\"", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                data[depth] = value;
            }
            _dataEntryForm.SetData(data);
        }

        private void DrawRammsondeFromData(SortedDictionary<int, int> source)
        {
            List<(int depth, int value)> data = [];
            int max = 0;
            foreach (KeyValuePair<int, int> entry in source)
            {
                if (entry.Value > max)
                    max = entry.Value;
                data.Add((entry.Key, entry.Value));
            }
            _renderData = data;
            _renderMax = max;
            DrawRammsonde(data, max);
        }

        private void ChartTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            _dataEntryForm?.TriggerPlot();
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
                DrawRammsondeFromFile();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                chartPictureBox.Image.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        private void CreatePdf(string filePath)
        {
            using var document = new PdfDocument();
            var page = document.AddPage();
            page.Width = XUnit.FromMillimeter(210);
            page.Height = XUnit.FromMillimeter(297);

            // 12 pixels (2x) = 1 mm  =>  1 pixel = 1/12 mm = 72/(12*25.4) points
            double pointsPerPixel = 72.0 / (12.0 * 25.4);
            double margin = XUnit.FromMillimeter(15).Point;

            using var bitmap = RenderBitmap(_renderData, _renderMax, 2);
            using var gfx = XGraphics.FromPdfPage(page);
            using var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            using var xImg = XImage.FromStream(ms);
            gfx.DrawImage(xImg, margin, margin,
                bitmap.Width * pointsPerPixel,
                bitmap.Height * pointsPerPixel);

            document.Save(filePath);
        }

        private void SavePdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dlg = new()
            {
                DefaultExt = "pdf",
                FileName = "save.pdf",
                Filter = "PDF-Dateien (*.pdf)|*.pdf|Alle Dateien (*.*)|*.*",
                InitialDirectory = Properties.Settings.Default.FilePath
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            CreatePdf(dlg.FileName);
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tempFile = Path.Combine(Path.GetTempPath(), $"heiner_print_{Guid.NewGuid()}.pdf");
            try
            {
                CreatePdf(tempFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"PDF konnte nicht erstellt werden:\n{ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Exception ex1, ex2, ex3;

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tempFile)
                {
                    UseShellExecute = true,
                    Verb = "print",
                    WorkingDirectory = "."
                });
                return;
            }
            catch (Exception ex) { ex1 = ex; }

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tempFile)
                {
                    UseShellExecute = true,
                    Verb = "print"
                });
                return;
            }
            catch (Exception ex) { ex2 = ex; }

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tempFile)
                {
                    UseShellExecute = true
                });
                return;
            }
            catch (Exception ex) { ex3 = ex; }

            File.Delete(tempFile);
            MessageBox.Show(
                $"ShellExecute (print, .):\n{ex1}\n\nShellExecute (print):\n{ex2}\n\nShellExecute (open):\n{ex3}",
                "Drucken fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OptionsForm optionsForm = new();
            optionsForm.ShowDialog();
        }
    }

}
