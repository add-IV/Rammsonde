using System;
using System.Windows.Forms;
using System.Runtime.Versioning;

namespace Heiner
{
    [SupportedOSPlatform("windows")]
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.FilePath;
            textBox2.Text = Properties.Settings.Default.MinX.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FilePath = textBox1.Text;
            Properties.Settings.Default.MinX = int.Parse(textBox2.Text);
            Properties.Settings.Default.Save();
        }
    }
}
