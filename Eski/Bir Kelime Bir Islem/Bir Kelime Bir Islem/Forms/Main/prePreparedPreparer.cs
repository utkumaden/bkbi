using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Bir_Kelime_Bir_Islem
{
    public partial class prePreparedPreparer : Form
    {
        //Variables
        bool useSettings = false;
        bool useArduino = false;
        string arduinoPort;
        string P1name;
        string P2name;
        string P3name;
        int P1points = 0;
        int P2points = 0;
        int P3points = 0;
        string filepath;

        public prePreparedPreparer()
        {
            InitializeComponent();
        }

        private void useSettingsCheckboxEvent(object sender, EventArgs e)
        {
            if (useSettingsCheckbox.Checked)
            {
                useSettings = true;
                tabControl1.Enabled = true;
            }
            else
            {
                useSettings = false;
                tabControl1.Enabled = false;
            }
        }

        private void useArduinoCheckBoxEvent(object sender, EventArgs e)
        {
            if (useArduinoCheckbox.Checked)
            {
                useArduino = true;
                portBox.Enabled = true;
            }
            else
            {
                useArduino = false;
                portBox.Enabled = false;
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            DialogResult s = saveDialog.ShowDialog();
            if (s == DialogResult.Cancel) return;
            filepath = saveDialog.FileName;
            if (!check()) return;
            XmlDocument xml = new XmlDocument();
            xml.AppendChild(xml.CreateElement("prePreparedGame"));
            #region settings
            if (useSettings)
            {
                xml.SelectSingleNode("prePreparedGame").AppendChild(xml.CreateElement("settings"));
                if (useArduino)
                {
                    XmlElement ard = xml.CreateElement("arduino");
                    ard.SetAttribute("port", portBox.Text);
                    xml.SelectSingleNode("prePreparedGame/settings").AppendChild(ard);
                }
                XmlElement player1 = xml.CreateElement("player");
                XmlElement player2 = xml.CreateElement("player");
                XmlElement player3 = xml.CreateElement("player");
                player1.SetAttribute("who", "P1");
                player2.SetAttribute("who", "P2");
                player3.SetAttribute("who", "P3");
                player1.SetAttribute("name", P1name);
                player2.SetAttribute("name", P2name);
                player3.SetAttribute("name", P3name);
                player1.SetAttribute("points", P1points.ToString());
                player2.SetAttribute("points", P2points.ToString());
                player3.SetAttribute("points", P3points.ToString());
                xml.SelectSingleNode("prePreparedGame/settings").AppendChild(player1);
                xml.SelectSingleNode("prePreparedGame/settings").AppendChild(player2);
                xml.SelectSingleNode("prePreparedGame/settings").AppendChild(player3);
            }
            #endregion
            #region creator
            XmlElement word = xml.CreateElement("word");
            XmlElement equation = xml.CreateElement("equation");
            equation.SetAttribute("sum", "0");
            xml.SelectSingleNode("prePreparedGame").AppendChild(xml.CreateElement("game"));
            for(int i = 0; i < (table.Rows.Count - 1); i++)
            {
                if(table.Rows[i].Cells[0].Value as string == string.Empty)
                {
                    MessageBox.Show("Tablonun " + (i + 1).ToString() + ". satırının 1. sütunu boş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (table.Rows[i].Cells[0].Value as string == "Kelime")
                {
                    if((table.Rows[i].Cells[1].Value as string).Length < 8)
                    {
                        MessageBox.Show("Tablonun " + (i + 1).ToString() + ". satırının 2. sütunundaki kelime çok kısa,  olmalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    if ((table.Rows[i].Cells[1].Value as string).Length > 8)
                    {
                        MessageBox.Show("Tablonun " + (i + 1).ToString() + ". satırının 2. sütunundaki kelime çok uzun,  olmalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    word.InnerText = table.Rows[i].Cells[1].Value as string;
                    xml.SelectSingleNode("prePreparedGame/game").AppendChild(word.Clone());
                }
                if (table.Rows[i].Cells[0].Value as string == "İşlem")
                {
                    int errorlevel = 0;
                    if (table.Rows[i].Cells[1].Value as string == string.Empty)
                    {
                        errorlevel++;
                    }
                    if(table.Rows[i].Cells[2].Value as string == string.Empty)
                    {
                        errorlevel = errorlevel + 2;
                    }
                    if (errorlevel == 1)
                    {
                        MessageBox.Show("Tablonun " + (i + 1).ToString() + ". satırının 2. sütunu boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if(errorlevel == 2)
                    {
                        MessageBox.Show("Tablonun " + (i + 1).ToString() + ". satırının 3. sütunu boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (errorlevel == 3)
                    {
                        MessageBox.Show("Tablonun " + (i + 1).ToString() + ". satırının 2. ve 3. sütunu boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if ((table.Rows[i].Cells[2].Value as string).Split(" ".ToCharArray()).Length != 6)
                    {
                        MessageBox.Show("Tablonun " + (i + 1).ToString() + ". satırının 3. sütununda yeterli sayı yok, bu sayı 6 olmalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        equation.SetAttribute("sum", table.Rows[i].Cells[1].Value as string);
                        equation.InnerText = string.Join(",", (table.Rows[i].Cells[2].Value as string).Split(" ".ToCharArray()));
                        xml.SelectSingleNode("prePreparedGame/game").AppendChild(equation.Clone());
                    }
                    catch
                    {
                        MessageBox.Show("Tablonun " + (i + 2).ToString() + ". satırının 2. veya 3. satırında bir sorun var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                }
                
            }
            
            xml.Save(filepath);
            #endregion
        }
        private bool check()
        {
            bool toReturn = true;
            bool errors = false;

            if (useSettings)
            {
                if (P1nameBox.Text.Length == 0)
                {
                    P1nameBox.ForeColor = Color.White;
                    P1nameBox.BackColor = Color.Maroon;
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                    toReturn = false;
                    errors = true;   
                }
                else
                {
                    P1nameBox.ForeColor = SystemColors.ControlText;
                    P1nameBox.BackColor = SystemColors.Window;
                    P1name = P1nameBox.Text;
                }
                if (P2nameBox.Text.Length == 0)
                {
                    P2nameBox.ForeColor = Color.White;
                    P2nameBox.BackColor = Color.Maroon;
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                    toReturn = false;
                    errors = true;
                }
                else
                {
                    P2nameBox.ForeColor = SystemColors.ControlText;
                    P2nameBox.BackColor = SystemColors.Window;
                    P2name = P2nameBox.Text;
                }
                if (P3nameBox.Text.Length == 0)
                {
                    P3nameBox.ForeColor = Color.White;
                    P3nameBox.BackColor = Color.Maroon;
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                    toReturn = false;
                    errors = true;
                }
                else
                {
                    P3nameBox.ForeColor = SystemColors.ControlText;
                    P3nameBox.BackColor = SystemColors.Window;
                    P3name = P3nameBox.Text;
                }
                if(P1pointsBox.Text.Length == 0)
                {
                    P1points = 0;
                }
                else
                {
                    try
                    {
                        P1pointsBox.ForeColor = SystemColors.ControlText;
                        P1pointsBox.BackColor = SystemColors.Window;
                        P1points = Int32.Parse(P1pointsBox.Text);
                    }
                    catch
                    {
                        P1pointsBox.ForeColor = Color.White;
                        P1pointsBox.BackColor = Color.Maroon;
                        MessageBox.Show("Oyuncu 1'in Puan kutusu hatalı (Sayı yerine Harf girilmiş olablilir)");
                        toReturn = false;
                    }
                }
                if (P2pointsBox.Text.Length == 0)
                {
                    P2points = 0;
                }
                else
                {
                    try
                    {

                        P2pointsBox.ForeColor = SystemColors.ControlText;
                        P2pointsBox.BackColor = SystemColors.Window;
                        P2points = Int32.Parse(P2pointsBox.Text);
                    }
                    catch
                    {
                        P2pointsBox.ForeColor = Color.White;
                        P2pointsBox.BackColor = Color.Maroon;
                        MessageBox.Show("Oyuncu 2'in Puan kutusu hatalı (Sayı yerine Harf girilmiş olablilir)");
                        toReturn = false;
                    }
                }
                if (P3pointsBox.Text.Length == 0)
                {
                    P3points = 0;
                }
                else
                {
                    try
                    {

                        P3pointsBox.ForeColor = SystemColors.ControlText;
                        P3pointsBox.BackColor = SystemColors.Window;
                        P3points = Int32.Parse(P3pointsBox.Text);
                    }
                    catch
                    {
                        P3pointsBox.ForeColor = Color.White;
                        P3pointsBox.BackColor = Color.Maroon;
                        MessageBox.Show("Oyuncu 3'in Puan kutusu hatalı (Sayı yerine Harf girilmiş olablilir)");
                        toReturn = false;
                    }
                }

                if (useArduino)
                {
                    if (portBox.Text.Length == 0)
                    {
                        portBox.ForeColor = Color.White;
                        portBox.BackColor = Color.Maroon;
                        tabControl1.SelectedTab = tabControl1.TabPages[1];
                        toReturn = false;
                        errors = true;
                    }
                    else
                    {
                        portBox.ForeColor = SystemColors.ControlText;
                        portBox.BackColor = SystemColors.Window;
                        arduinoPort = portBox.Text;
                    }
                }
            }
            if (errors)
            {
                MessageBox.Show("Kırmızı haneler dolu olmak zorunda!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return toReturn;
        }
    }
}
