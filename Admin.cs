using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static secform.Form1.Globals;
using static secform.Form1;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using DataGridViewFromFile;

namespace secform
{
    public partial class Admin : Form
    {

        
        public Admin()
        {
            InitializeComponent();

            button6.MouseEnter += button6_MouseEnter;
            button6.MouseLeave += button6_MouseLeave;

            Kisi[] people = Globals.People;
            checkedListBox1.Items.RemoveAt(0);
            foreach (var person in people)
            {
                checkedListBox1.Items.Add(person.Name + " | " + person.Number.ToString() + " | " + person.arti.ToString() + " | " + person.eksi.ToString());
            }

        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            try 
            {
                int secilenSayisi = checkedListBox1.CheckedIndices.Count;

                if (secilenSayisi > 0)
                {
                    DialogResult result = MessageBox.Show($"Seçilen {secilenSayisi} öğrenciyi silmek istiyor musunuz?", "Öğrenci Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        for (int i = checkedListBox1.CheckedIndices.Count - 1; i >= 0; i--)
                        {
                            int secilenIndex = checkedListBox1.CheckedIndices[i];

                            if (secilenIndex >= 0 && secilenIndex < Globals.People.Length)
                            {
                                Globals.Kisi secilenKisi = Globals.People[secilenIndex];
                                MessageBox.Show($"Silinen Öğrenci : \nİsim: {secilenKisi.Name} \nNumara: {secilenKisi.Number}");

                                RemoveStudent(secilenIndex);
                            }
                        }

                        UpdateCheckedListBox();
                    }
                }
                else
                {
                    MessageBox.Show("En az bir öğrenci seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri dosyasına yazma hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateCheckedListBox();
            }
        }

        private void RemoveStudent(int index)
        {
            if (index >= 0 && index < Globals.People.Length)
            {
                List<Globals.Kisi> peopleList = Globals.People.ToList();
                peopleList.RemoveAt(index);
                Globals.People = peopleList.ToArray();

                SaveData();
            }
        }

        private void UpdateCheckedListBox()
{
            checkedListBox1.Items.Clear();
            foreach (var person in Globals.People)
            {
                checkedListBox1.Items.Add($"{person.Name} | {person.Number} | {person.arti} | {person.eksi}");
            }
}

        private void button2_Click(object sender, EventArgs e)
        {
            Basla menu = new Basla();
            menu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string isim = textBox1.Text;
            int no = Convert.ToInt32(textBox2.Text);
            int not1 = 0;
            int not2 = 0;
            int not3 = 0;
            int not4 = 0;
            int not5 = 0;
            int not6 = 0;
            int not7 = 0;
            int not8 = 0;
            int not9 = 0;
            int not10 = 0;
            int arti = 0;
            int eksi = 0;

            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data_note.txt");
                string newStudentData = $"{isim},{no},{not1},{not2},{not3},{not4},{not5},{not6},{not7},{not8},{not9},{not10},{arti},{eksi}";

                File.AppendAllText(filePath, newStudentData + Environment.NewLine);

                MessageBox.Show($"Öğrenci Başarıyla Eklendi: \nİsim : {isim} \nNumara : {no}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri dosyasına yazma hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                groupBox1.Visible = false;
                textBox1.Clear();
                textBox2.Clear();

                Globals.InitializeData();
                UpdateCheckedListBox();
            }

        }


        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Basla menu = new Basla();
            menu.Show();
            this.Hide();
        }





        private void button8_Click(object sender, EventArgs e)
        {
            NotHesapla menu = new NotHesapla();
            menu.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
            
        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Globals.InitializeData();
            UpdateCheckedListBox();

            textBox1.Clear();
            textBox2.Clear();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }



}
//Kisi[] people = Globals.People;
