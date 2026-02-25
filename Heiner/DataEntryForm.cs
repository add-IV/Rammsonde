using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Versioning;

namespace Heiner
{
    [SupportedOSPlatform("windows")]
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "10";
            saveFileDialog1.InitialDirectory = Properties.Settings.Default.FilePath;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int im = int.Parse(textBox1.Text);
            String m = im.ToString(), s = numericUpDown1.Text;
            ListViewItem list1 = new ListViewItem();
            list1.Name = m;
            list1.SubItems.Add(m);
            list1.SubItems.Add(s);
            if (!listView1.Items.ContainsKey(m))
            {
                listView1.Items.Add(list1);
            }
            else
            {
                listView1.Items[listView1.Items.IndexOfKey(m)].SubItems[2].Text = s;
            }
            textBox1.Text = (im + 10).ToString();
            listView1.Items[listView1.Items.IndexOfKey(m)].EnsureVisible();
            numericUpDown1.Select();
            numericUpDown1.Select(0, numericUpDown1.Text.Length);

            if (!MyGlobals.data1.ContainsKey(im))
            {
                MyGlobals.data1.Add(im, (int)numericUpDown1.Value);
            }
            else
            {
                MyGlobals.data1[im] = (int)numericUpDown1.Value;
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                }
            }
            if (listView1.Items.Count > 0)
            {
                textBox1.Text = (int.Parse(listView1.Items[listView1.Items.Count - 1].Name) + 10).ToString();
            }
            else
            {
                textBox1.Text = "10";
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Alle Einträge löschen?", "New", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                listView1.Items.Clear();
                textBox1.Text = "10";
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                using (var tw = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        tw.WriteLine(item.SubItems[1].Text + " " + item.SubItems[2].Text);
                    }
                }
            }
        }

        private void NumericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void NumericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                Button1_Click(sender, e);
            }

        }

        public event EventHandler Button3Click;

        private void button3_Click_1(object sender, EventArgs e)
        {
            EventHandler handler = Button3Click;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
