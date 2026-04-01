using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Versioning;

namespace Heiner
{
    [SupportedOSPlatform("windows")]
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            txtFilePath.Text = Properties.Settings.Default.FilePath;
            txtMinX.Text = Properties.Settings.Default.MinX.ToString();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                txtFilePath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMinX.Text, out int minX))
            {
                MessageBox.Show("X-Achse muss eine ganze Zahl sein.", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Properties.Settings.Default.FilePath = txtFilePath.Text;
            Properties.Settings.Default.MinX = minX;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
