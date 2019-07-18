using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bir_Kelime_Bir_Islem.Forms.List
{
    public partial class lister : Form
    {

        silentPrePreparedGameHandler ppg = new silentPrePreparedGameHandler();
        DataGridViewCellStyle green = new DataGridViewCellStyle();
        int indexer = 0;
        public lister()
        {
            InitializeComponent();
        }

        public lister(string path)
        {
            InitializeComponent();
            openFileDialog1.FileName = path;
            textBox1.Text = path;
        }

        public lister(string path, int index)
        {
            InitializeComponent();      
            openFileDialog1.FileName = path;
            indexer = index;
            textBox1.Text = path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == DialogResult.Cancel) return;
            textBox1.Text = openFileDialog1.FileName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(textBox1.Text)) return;
            if (Path.GetExtension(textBox1.Text) != ".bkbi") return;

            green.BackColor = Color.Green;
            green.ForeColor = Color.White;

            ppg.loadGame(textBox1.Text);

            for (int i = 1; i <= ppg.max; i++)
            {
                ppg.setPlace((uint)i);
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                if (ppg.selectedItem.Type.Equals(gameType.Word))
                {
                    row.SetValues(new object[] { i.ToString(), "Kelime", ppg.selectedItem.Value, "" });
                }
                else
                {
                    string[] s = ppg.selectedItem.Value as string[];
                    row.SetValues(new object[] { i.ToString(), "İşlem", s[0], string.Join(",", s.Skip(1).ToArray()) });
                }
                if (i == indexer) row.DefaultCellStyle = green;
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
