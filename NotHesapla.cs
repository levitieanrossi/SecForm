using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using secform;

namespace DataGridViewFromFile
{
    public partial class NotHesapla : Form
    {
        private List<Person> people;

        public NotHesapla()
        {
            InitializeComponent();

            DataGridView DataGridView = dataGridView2;

            LoadDataFromFile("data_note.txt");

            dataGridView2.CellEndEdit += DataGridView2_CellEndEdit;
        }


        private bool mouseDown;
        private Point lastLocation;

        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TitlePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void TitlePanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void LoadDataFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                people = new List<Person>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 14)
                    {
                        int no, not1, not2, not3, not4, not5, not6, not7, not8, not9, not10, arti, eksi;
                        double toplam;

                        string isims = parts[0];
                        int.TryParse(parts[1], out no);
                        int.TryParse(parts[2], out not1);
                        int.TryParse(parts[3], out not2);
                        int.TryParse(parts[4], out not3);
                        int.TryParse(parts[5], out not4);
                        int.TryParse(parts[6], out not5);
                        int.TryParse(parts[7], out not6);
                        int.TryParse(parts[8], out not7);
                        int.TryParse(parts[9], out not8);
                        int.TryParse(parts[10], out not9);
                        int.TryParse(parts[11], out not10);
                        int.TryParse(parts[12], out arti);
                        int.TryParse(parts[13], out eksi);

                        if (Convert.ToString(not1) != "")
                        {
                            //toplam = (not1 + not2 + not3 + not4 + not5 + not6 + not7 + not8 + not9 + not10) / 10.0;
                            toplam = (not1 + not2 + not3 + not4 + not5 + not6 + not7 + not8 + not9 + not10);
                        }
                        else
                        {
                            toplam = 0;
                        }
                        people.Add(new Person { İsimSoyisim = isims, OkulNo = no, PerformansNot1 = not1, PerformansNot2 = not2, PerformansNot3 = not3, PerformansNot4 = not4, PerformansNot5 = not5, PerformansNot6 = not6, PerformansNot7 = not7, PerformansNot8 = not8, PerformansNot9 = not9, PerformansNot10 = not10, arti = arti, eksi = eksi, toplam = toplam });
                    }
                }


                dataGridView2.DataSource = people;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri okuma hatası: " + ex.Message);
            }
        }

        private void SaveDataToFile(string filePath)
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (Person person in people)
                {
                    string line = $"{person.İsimSoyisim},{person.OkulNo},{person.PerformansNot1},{person.PerformansNot2},{person.PerformansNot3},{person.PerformansNot4},{person.PerformansNot5},{person.PerformansNot6},{person.PerformansNot7},{person.PerformansNot8},{person.PerformansNot9},{person.PerformansNot10},{person.arti},{person.eksi}";
                    lines.Add(line);
                }

                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri kaydetme hatası: " + ex.Message);
            }
        }

        private void DataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SaveDataToFile("data_note.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataFromFile("data_note.txt");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Admin menu = new Admin();
            menu.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin menu = new Admin();
            menu.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class Person
    {
        public string İsimSoyisim { get; set; }
        public int OkulNo { get; set; }
        public int PerformansNot1 { get; set; }
        public int PerformansNot2 { get; set; }
        public int PerformansNot3 { get; set; }
        public int PerformansNot4 { get; set; }
        public int PerformansNot5 { get; set; }
        public int PerformansNot6 { get; set; }
        public int PerformansNot7 { get; set; }
        public int PerformansNot8 { get; set; }
        public int PerformansNot9 { get; set; }
        public int PerformansNot10 { get; set; }
        public int arti { get; set; }
        public int eksi { get; set; }
        public double toplam { get; set; }
    }
}
