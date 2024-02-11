using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Xml.Linq;

namespace secform
{
    public partial class Form1 : Form
    {

        private SoundPlayer waitSoundPlayer;
        private SoundPlayer winSoundPlayer;

        public Form1()
        {
            InitializeComponent();
            InitializeSoundPlayers();
        }

        private void InitializeSoundPlayers()
        {
            waitSoundPlayer = new SoundPlayer();
            string waitDizin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wait.wav");
            waitSoundPlayer.SoundLocation = waitDizin;

            winSoundPlayer = new SoundPlayer();
            string winDizin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "win.wav");
            winSoundPlayer.SoundLocation = winDizin;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }




        private Random random = new Random();

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                PlayWaitSound();

                for (int i = 1; i <= 10; i++)
                {
                    UpdateLabels(i);
                    await Task.Delay(150);
                }

                for (int i = 10; i >= 1; i--)
                {
                    UpdateLabels(i);
                    await Task.Delay(150);
                }


                PlayWinSound();

                //SoundPlayer ses = new SoundPlayer();
                //string dizin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "win.wav");
                //ses.SoundLocation = dizin;
                //ses.Play();

            });
        }


        public static class Globals
        {
            public class Kisi
            {
                public string Name { get; set; }
                public int Number { get; set; }
                public int Note { get; set; }
                public int UNote { get; set; }
                public int Note3 { get; set; }
                public int Note4 { get; set; }
                public int Note5 { get; set; }
                public int Note6 { get; set; }
                public int Note7 { get; set; }
                public int Note8 { get; set; }
                public int Note9 { get; set; }
                public int Note10 { get; set; }
                public int arti { get; set; }
                public int eksi { get; set; }

                public override string ToString()
                {
                    return $"{Name} - {Number} - {Note} - {UNote} - {Note3} - {Note4} - {Note5} - {Note6} - {Note7} - {Note8} - {Note9} - {Note10} - {arti} - {eksi}";
                }
            }

            public static Kisi[] People;

            static Globals()
            {
                InitializeData();
            }

            public static void InitializeData()
            {
                try
                {
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data_note.txt");

                    if (File.Exists(filePath))
                    {
                        string[] lines = File.ReadAllLines(filePath);
                        People = new Kisi[lines.Length];

                        for (int i = 0; i < lines.Length; i++)
                        {
                            string[] parts = lines[i].Split(',');

                            if (parts.Length == 14)
                            {
                                People[i] = new Kisi { Name = parts[0], Number = int.Parse(parts[1]),Note = int.Parse(parts[2]),UNote = int.Parse(parts[3]), Note3 = int.Parse(parts[4]), Note4 = int.Parse(parts[5]), Note5 = int.Parse(parts[6]), Note6 = int.Parse(parts[7]), Note7 = int.Parse(parts[8]), Note8 = int.Parse(parts[9]), Note9 = int.Parse(parts[10]), Note10 = int.Parse(parts[11]), arti = int.Parse(parts[12]), eksi = int.Parse(parts[13]) };
                            }
                            else
                            {
                                MessageBox.Show($"Dosya formatı hatalı. Satır: {lines[i]}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veri dosyası bulunamadı. Lütfen Data_Note.txt nin olduğundan emin olunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                        //             People = new Kisi[]
                        //             {
                        //               new Kisi { Name = "Yiğit Demirkaya", Number = 1485 },
                        //  new Kisi { Name = "Mehmet Salih Gemici", Number = 1709 },
                        //    new Kisi { Name = "Enes Adıgüzel", Number = 1720 },
                        //   new Kisi { Name = "Bedirhan Altın", Number = 1733 },
                        //               new Kisi { Name = "Abdullah Ardıç", Number = 1738 },
                        //              new Kisi { Name = "Ayşenaz Eski", Number = 1759 },
                        //new Kisi { Name = "Abdullah Tursun", Number = 1760 },
                        //                 new Kisi { Name = "Emre Karaca", Number = 1826 },
                        //                 new Kisi { Name = "E. Kılıçer", Number = 1840 },
                        //     new Kisi { Name = "Muhammed Talha Üğüdücü", Number = 1853 },
                        //                 new Kisi { Name = "Hüseyin Efe Uysal", Number = 1862 },
                        //     new Kisi { Name = "Arda Parabaş", Number = 1932 },
                        //  new Kisi { Name = "Semih İlbasmış", Number = 1943 },
                        //     new Kisi { Name = "Enes İlter", Number = 1944 },
                        //      new Kisi { Name = "Irmak Nur Polat", Number = 2466 },
                        //      new Kisi { Name = "Ömer Faruk Özdemir", Number = 2489 },
                        //     new Kisi { Name = "Taha Seçgin", Number = 3006 },
                        //    new Kisi { Name = "Hüseyin Emre Yurtsever", Number = 3095 },
                        // new Kisi { Name = "Muhammet İçten", Number = 3096 },
                        //  new Kisi { Name = "İsmail Kırca", Number = 3119 },
                        //  new Kisi { Name = "Ehad Efe Algül", Number = 3190 }
                        //              };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri dosyasından okuma hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public static void SaveData()
            {
                try
                {
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data_note.txt");

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var person in People)
                        {
                            writer.WriteLine($"{person.Name},{person.Number},{person.Note},{person.UNote},{person.Note3},{person.Note4},{person.Note5},{person.Note6},{person.Note7},{person.Note8},{person.Note9},{person.Note10},{person.arti},{person.eksi}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Veri dosyasına yazma hatası: {ex.Message}");

                }
            }





        }



        private void UpdateLabels(int value)
        {
            Globals.InitializeData();

            if (label1.InvokeRequired)
            {

                int toplamOgrenciSayisi = Globals.People.Length;
                int secilmisKisi = random.Next(0, toplamOgrenciSayisi);

                Globals.Kisi secilen1 = Globals.People[secilmisKisi];

                



                string arti = "Artı : " + Convert.ToString(secilen1.arti);
                string eksi = "Eksi : " + Convert.ToString(secilen1.eksi);
                string secilenisim = secilen1.Name;
                int secilen = secilen1.Number;

                int[] haneler = secilen.ToString().Select(x => int.Parse(x.ToString())).ToArray();

                int a = random.Next(1, 9);
                int b = random.Next(1, 9);
                int c = random.Next(1, 9);
                int d = random.Next(1, 9);

                label1.Invoke(new Action(() => label1.Text = (d - value).ToString()));
                Task.Delay(400);
                label1.Invoke(new Action(() => label1.Text = haneler[0].ToString()));
                Task.Delay(400);
                label2.Invoke(new Action(() => label2.Text = (a - value).ToString()));
                Task.Delay(400);
                label2.Invoke(new Action(() => label2.Text = haneler[1].ToString()));
                Task.Delay(400);
                label3.Invoke(new Action(() => label3.Text = (b - value).ToString()));
                Task.Delay(400);
                label3.Invoke(new Action(() => label3.Text = haneler[2].ToString()));
                Task.Delay(400);
                label4.Invoke(new Action(() => label4.Text = (c - value).ToString()));
                Task.Delay(400);
                label4.Invoke(new Action(() => label4.Text = haneler[3].ToString()));
                Task.Delay(400);


                label5.Invoke(new Action(() => label5.Text = secilenisim.ToString()));
                label7.Invoke(new Action(() => label7.Text = arti.ToString()));
                label8.Invoke(new Action(() => label8.Text = eksi.ToString()));



            }
            else
            {
                label1.Text = (value).ToString();
                label2.Text = (value).ToString();
                label3.Text = (value).ToString();
                label4.Text = (value).ToString();
            }
        }

        private void PlayWaitSound()
        {
            waitSoundPlayer.Play();
        }

        private void PlayWinSound()
        {
            waitSoundPlayer.Stop(); // wait.wav çalma durduruluyor
            winSoundPlayer.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Basla menu = new Basla();
            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.InvokeRequired)
            {
                label1.Invoke(new Action(() => label1.Text = "0"));
                label2.Invoke(new Action(() => label2.Text = "0"));
                label3.Invoke(new Action(() => label3.Text = "0"));
                label4.Invoke(new Action(() => label4.Text = "0"));
                label4.Invoke(new Action(() => label7.Text = "Artı : "));
                label4.Invoke(new Action(() => label8.Text = "Eksi : "));
                label5.Invoke(new Action(() => label5.Text = "İsim Soyisim"));

            }
            else
            {
                label1.Text = "0";
                label2.Text = "0";
                label3.Text = "0";
                label4.Text = "0";
                label5.Text = "İsim Soyisim";

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
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
    }
}
