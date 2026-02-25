using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;


namespace Heiner

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FilePath == "")
            {
                Properties.Settings.Default.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                MessageBox.Show("Bitte Wähle ein Standartverzeichniss in den Optionen","Verzeichniss setzen",MessageBoxButtons.OK);
            }
            saveFileDialog1.InitialDirectory = Properties.Settings.Default.FilePath;
            openFileDialog1.InitialDirectory = Properties.Settings.Default.FilePath;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.FormClosing += Frm2_Form2Closing;
            frm.Button3Click += Frm2_Form2Closing;
            frm.Show();
        }

        private void Frm2_Form2Closing(object sender, EventArgs e)
        {
            CreateRammsonde2(this,e);
        }
        private void DrawRammsonde(List<List<int>> data,int max,object sender, EventArgs e)
        {

            int od = 70, ud = 50, ld = 50, rd = 50, ks = 5, delta = 6, td = 20, ex = 2, MinX = Properties.Settings.Default.MinX;

            if (MinX > max)
            {
                max = MinX;
            }

            int width = max * delta + 2 * ld + rd, height = (data.Count + ex) * delta + od + ud;

            Bitmap bmp = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(bmp);

            Pen pen1 = new Pen(Color.Black, 1);

            g.DrawLine(pen1, ld, od, ld, od + (data.Count + ex) * delta);
            g.DrawLine(pen1, ld, od, ld + max * delta, od);
            g.DrawLine(pen1, ld + delta * data[0][1], od, ld + delta * data[0][1], od + delta);

            for (int i = 10; i < data.Count + ex + 1; i += 10)
            {
                g.DrawLine(pen1, ld - ks, od + delta * i, ld, od + delta * i);
            }

            for (int j = 1; j < data.Count; j++)
            {
                int i = data[j][0] / 10;
                if (data[j][1] == 0)
                {
                    g.DrawLine(pen1, ld + delta * data[j - 1][1], od + delta * (i - 1), ld + delta * data[j][1] + 1, od + delta * (i - 1));
                    g.DrawLine(pen1, ld + delta * data[j][1] + 1, od + delta * (i - 1), ld + delta * data[j][1] + 1, od + delta * i);
                    continue;
                }
                g.DrawLine(pen1, ld + delta * data[j - 1][1], od + delta * (i - 1), ld + delta * data[j][1], od + delta * (i - 1));
                g.DrawLine(pen1, ld + delta * data[j][1], od + delta * (i - 1), ld + delta * data[j][1], od + delta * i);
            }

            g.DrawLine(pen1, ld + delta * data[data.Count - 1][1], od + delta * (data[data.Count - 1][0] / 10), ld + 1, od + delta * (data[data.Count - 1][0] / 10));

            for (int i = 0; i < max; i += 10)
            {
                g.DrawLine(pen1, ld + delta * i, od - ks, ld + delta * i, od);
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Far
            };

            g.DrawString("Eindringungswiederstand", new Font("Tahoma", 12), Brushes.Black, new PointF(width - rd, td), sf);
            sf.Alignment = StringAlignment.Center;
            g.DrawString(textBox1.Text, new Font("Tahoma", 15), Brushes.Black, new PointF(ld, td), sf);
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString("[s]/[10cm]", new Font("Tahoma", 10), Brushes.Black, new PointF(width - rd + delta, od), sf);
            g.DrawString("Endtiefe", new Font("Tahoma", 10), Brushes.Black, new PointF(ld, height - ud + 15), sf);
            g.DrawString(((float)data[data.Count - 1][0] / 100).ToString("n2") + " m", new Font("Tahoma", 10), Brushes.Black, new PointF(ld, height - ud + 30), sf);
            sf.LineAlignment = StringAlignment.Far;

            for (int i = 0; i < max; i += 10)
            {
                g.DrawString(i.ToString(), new Font("Tahoma", 10), Brushes.Black, new PointF(ld + delta * i + 2, od - ks), sf);
            }
            for (int i = 10; i < data.Count + ex + 1; i += 10)
            {
                g.DrawString((i / 10).ToString(), new Font("Tahoma", 10), Brushes.Black, new PointF(ld - 3 * ks, od + delta * i + ks * 2), sf);
            }

            g.Flush();

            pictureBox1.Image = bmp;

        }

        private void CreateRammsonde(object sender, EventArgs e)
        {
            List<List<int>> data = new List<List<int>>();
            String[] lines = File.ReadAllLines(openFileDialog1.FileName);
            int max = 0;
            foreach (String line in lines)
            {
                List<int> temp = new List<int>
                {
                    int.Parse(line.Split(' ')[0]),
                    int.Parse(line.Split(' ')[1])
                };
                if (int.Parse(line.Split(' ')[1]) > max)
                {
                    max = int.Parse(line.Split(' ')[1]);
                }
                data.Add(temp);
            }
            DrawRammsonde(data,max,this,e);
        }

        private void CreateRammsonde2(object sender, EventArgs e)
        {
            List<List<int>> data = new List<List<int>>();
            int max = 0;
            foreach (KeyValuePair<int,int> el in MyGlobals.data1)
            {
                List<int> temp = new List<int>
                {
                    el.Key,
                    el.Value
                };
                if (el.Value > max)
                {
                    max = el.Value;
                }
                data.Add(temp);
            }
            if(data.Count != 0)DrawRammsonde(data, max, this, e);
        }

        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CreateRammsonde(sender, e);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName, ImageFormat.Png);
            }
        }

        private void AktualisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != "openFileDialog1")
            {
                CreateRammsonde(sender, e);
            }
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }
    }
}

public static class MyGlobals
{
    public static SortedDictionary<int, int> data1 = new SortedDictionary<int, int>();
}