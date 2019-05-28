using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using System.Windows.Media.Animation;
using System.IO;

namespace maxiapp
{
    public partial class Korpatron : Form
    {
        
        
        float cena = 0;
        Timer t1 = new Timer();

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            //Korpatron program = new Korpatron();
            Form3 ucitavanje = new Form3();
            ucitavanje.Close();
            ucitavanje.Hide();



            timer1.Start();
            this.Opacity = 0;
            for (double cont = 0; cont <= 1; cont += 0.5)
            {
                this.Opacity = cont;
                this.Refresh();
                System.Threading.Thread.Sleep(1);
            }
        }

        private void Korpatron_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Opacity = 1;
            for (double cont = 1; cont >= 0; cont -= 0.5)
            {
                this.Opacity = cont;
                this.Refresh();
                System.Threading.Thread.Sleep(1);
            }

        }

        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        
        public Korpatron()
        {
            InitializeComponent();
            player.URL = "muzika.mp3";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private static bool maximized = false;
        private void Korpatron_DoubleClick(object sender, EventArgs e)
        {
            if (maximized == false)
            {
                pictureBox2_Click(sender, e);
            }
            else {              
                pictureBox2_Click(sender, e);          
            }
        WindowState = FormWindowState.Normal;
            
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (maximized)
            {
                WindowState = FormWindowState.Normal;
                maximized = false;
                //vracanje forme
                pictureBox1.Size = new Size(20, 20);
                pictureBox1.Location = new System.Drawing.Point(1000, 4);
                pictureBox2.Size = new Size(20, 20);
                pictureBox2.Location = new System.Drawing.Point(968, 4);
                pictureBox3.Size = new Size(20, 20);
                pictureBox3.Location = new System.Drawing.Point(936, 4);
                pomoc.Location = new System.Drawing.Point(904, 4);
                pomoc.Size = new Size(20, 20);
                pictureBox5.Size = new Size(30, 30);
                korpatrron.Location = new System.Drawing.Point(30, 9);
                korpatrron.Font = new Font("SF Pro Text", 16);
                Korpa.Size = new Size(180, 256);
                Korpa.Location = new System.Drawing.Point(832, 304);
                Korpa.Font = new Font("SF Pro Text", 11);
                label1.Location = new System.Drawing.Point(392, 9);
                label1.Font = new Font("SF Pro Text", 15);
                label3.Location = new System.Drawing.Point(886, 276);
                label3.Font = new Font("SF Pro Text", 15);
                kraj.Size = new Size(180,132);
                kraj.Location = new System.Drawing.Point(830, 52);
                kanta.Size = new Size(75,75);
                kanta.Location = new System.Drawing.Point(823, 199);
                reset.Size = new Size(74,74);
                reset.Location = new System.Drawing.Point(936, 199);
                pictureBox6.Location = new System.Drawing.Point(3,260);
                pictureBox6.Size = new Size(49, 93);
            }
            else 
            {
                WindowState = FormWindowState.Maximized;
                maximized = true;
                //menjanje forme
                pictureBox1.Size = new Size(35, 35);
                pictureBox1.Location = new System.Drawing.Point(ClientRectangle.Width-50, 5);
                pictureBox2.Size = new Size(35, 35);
                pictureBox2.Location = new System.Drawing.Point(ClientRectangle.Width - 100, 5);
                pictureBox3.Size = new Size(35, 35);
                pictureBox3.Location = new System.Drawing.Point(ClientRectangle.Width - 150, 5);
                pomoc.Location = new System.Drawing.Point(ClientRectangle.Width - 200, 5);
                pomoc.Size = new Size(35, 35);
                pictureBox5.Size = new Size(50, 50);
                korpatrron.Location = new System.Drawing.Point(60,9);
                korpatrron.Font = new Font("SF Pro Text", 24);
                Korpa.Size = new Size(360, 512);
                Korpa.Location = new System.Drawing.Point(ClientRectangle.Width-390, ClientRectangle.Height-515);
                Korpa.Font = new Font("SF Pro Text", 20);
                label1.Location= new System.Drawing.Point(ClientRectangle.Width/2-200,10);
                label1.Font = new Font("SF Pro Text",24);
                label3.Location = new System.Drawing.Point(ClientRectangle.Width - 255, 515);
                label3.Font = new Font("SF Pro Text", 24);
                kraj.Size = new Size(360, 264);
                kraj.Location = new System.Drawing.Point(ClientRectangle.Width - 390, 65);
                kanta.Size = new Size(151,151);
                kanta.Location = new System.Drawing.Point(ClientRectangle.Width - 400, 360);
                reset.Size = new Size(147,147);
                reset.Location = new System.Drawing.Point(ClientRectangle.Width - 190, 360);
                kraj.Location = new System.Drawing.Point(ClientRectangle.Width - 390, 65);
                kanta.Size = new Size(151, 151);
                pictureBox6.Location = new System.Drawing.Point(3, ClientRectangle.Height/2-100);
                pictureBox6.Size = new Size(98, 186);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime danas = DateTime.Now;
            label1.Text = Convert.ToString(danas);
            ukupnaCena3.Text=Convert.ToString(cena);
        }

        

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            cena = 0;
            Korpa.Items.Clear();
            //Application.Restart();
        }

        void uKorpu(Button b, string imeProizvoda)
        {
            StreamReader sr = new StreamReader("C:\\Users\\marko\\Desktop\\bosko\\korpatron\\materijal\\cene\\cene.txt");
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                if (s.IndexOf(imeProizvoda) != -1)
                {
                    int c = imeProizvoda.Length + 1;
                    s = s.Substring(c);
                    cena += Convert.ToInt32(s);
                    Korpa.Items.Add(Convert.ToString(imeProizvoda + " " + s));
                    break;
                }   
              
            }



        }

        private void peciva_Click(object sender, EventArgs e)
        {
            //dobrodosli.Visible = false;
            //kraj.Visible = false;
            mproizvodi.Visible = false;
            namirnice.Visible = false;
            voce.Visible = false;
            povrce.Visible = false;
            meso.Visible = false;
            pice.Visible = false;
            pictureBox6.Visible = true;
            hemija.Visible = false;
            
            
            
            hlebb.Visible = true;
            djevrekk.Visible = true;
            kiflaa.Visible = true;
            bagett.Visible = true;
            krofna.Visible = true;
            zuzu.Visible = true;
            minipice.Visible = true;
            burek.Visible = true;
            peciva.Visible = false;
            
        }

        
        private void pictureBox6_Click(object sender, EventArgs e)
        {

            pomocText.Visible = false;
            
            //proizvodi
            hlebb.Visible = false;
            djevrekk.Visible = false;
            kiflaa.Visible = false;
            bagett.Visible = false;
            mleko.Visible = false;
            jogurt.Visible = false;
            pavlaka.Visible = false;
            feta.Visible = false;
            kackavalj.Visible = false;
            eurokrem.Visible = false;
            maslac.Visible = false;
            vocnijog.Visible = false ;
            krofna.Visible = false;
            zuzu.Visible = false;
            minipice.Visible = false;
            burek.Visible = false;
            jaja.Visible = false;
            brasno.Visible = false;
            secer.Visible = false;
            so.Visible = false;
            biber.Visible = false ;
            kecap.Visible = false;
            majonez.Visible = false;
            senf.Visible = false;
            jabuke.Visible = false;
            banane.Visible = false;
            grozdje.Visible = false;
            pomorandze.Visible = false;
            jagode.Visible = false;
            kruske.Visible = false;
            limun.Visible = false;
            kivi.Visible = false; 
            crniluk.Visible = false;
            bkrompir.Visible = false;
            ckrompir.Visible = false;
            sargarepa.Visible = false;
            sampinjoni.Visible = false;
            paradajz.Visible = false;
            krastavac.Visible = false;
            kupus.Visible = false;
            mleveno.Visible = false;
            oslic.Visible = false;
            saran.Visible = false;
            parizer.Visible = false;
            sunka.Visible = false;
            plecka.Visible = false;
            file.Visible = false;
            cevapi.Visible = false;
            voda.Visible = false;
            gazirana.Visible = false;
            pivo.Visible = false;
            vino.Visible = false;
            kola.Visible = false;
            sjabuka.Visible = false;
            sbreskva.Visible = false;
            spomorandza.Visible = false;
            pasta.Visible = false;
            sapun.Visible = false;
            tecnisapun.Visible = false;
            sampon.Visible = false;
            geltusiranje.Visible = false;
            omeksivac.Visible = false;
            prasak.Visible = false;
            deterdz.Visible = false;

            //kraj
            jedan.Visible = false;
            dva.Visible = false;
            tri.Visible = false;
            cetiri.Visible = false;
            pet.Visible = false;
            sest.Visible = false;
            sedam.Visible = false;
            osam.Visible = false;
            devet.Visible = false;
            nula.Visible = false;
            brisi.Visible = false;
            pare.Visible = false;
            krajkupovine.Visible = false;
            kusur.Visible = false;
            kusurlabel.Visible = false;
            greska.Visible = false;
            greska2.Visible = false;
            
            //pocetni meni
            //dobrodosli.Visible = true;
            peciva.Visible = true;
            mproizvodi.Visible = true;
            namirnice.Visible = true;
            //kraj.Visible = true;
            voce.Visible = true;
            povrce.Visible = true;
            meso.Visible = true;
            pice.Visible = true;
            hemija.Visible = true;
            kraj.Visible = true;
            
            pictureBox6.Visible = false;

            labelCena.Location = new Point(213, 284);
            ukupnaCena3.Location = new Point(371, 284);
            label2.Location = new Point(545, 284);
            label2.Visible = true;
            labelCena.Visible = true;
            ukupnaCena3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
        }

        private void hleb_Click(object sender, EventArgs e)
        {
            
            //Korpa.Items.Add("Hleb");
            //cena += 35;
        }

        private void djevrek_Click(object sender, EventArgs e)
        {
            
        }
        private void krofna_Click(object sender, EventArgs e)
        {
            uKorpu(krofna, "Krofna");
        }

        private void kifla_Click(object sender, EventArgs e)
        {

        }

        private void baget_Click(object sender, EventArgs e)
        {
            Korpa.Items.Add("Baget");
            cena += 30;
        }

        private void hlebb_Click(object sender, EventArgs e)
        {
            uKorpu(hlebb, "Hleb");
            
        }

        private void djevrekk_Click(object sender, EventArgs e)
        {
            uKorpu(djevrekk, "Djevrek");
        }

        private void zuzu_Click(object sender, EventArgs e)
        {
            uKorpu(zuzu, "Zuzu");
        }
        private void kiflaa_Click(object sender, EventArgs e)
        {
            uKorpu(kiflaa, "Kifla");
        }

        private void bagett_Click(object sender, EventArgs e)
        {
            uKorpu(bagett, "Baget");
        }
        private void minipice_Click(object sender, EventArgs e)
        {
            uKorpu(minipice, "MiniPizze");
        }

        private void burek_Click(object sender, EventArgs e)
        {
            uKorpu(burek, "Burek");
        }

        private void mproizvodi_Click(object sender, EventArgs e)
        {
            //meni
            //dobrodosli.Visible = false;
            peciva.Visible = false;
            mproizvodi.Visible = false;
            namirnice.Visible = false;
            voce.Visible = false;
            //kraj.Visible = false;
            povrce.Visible = false;
            meso.Visible = false;
            pice.Visible = false;
            hemija.Visible = false;

            //proizvodi
            pictureBox6.Visible = true;
            mleko.Visible = true;
            jogurt.Visible = true;
            pavlaka.Visible = true;
            feta.Visible = true;
            kackavalj.Visible = true;
            eurokrem.Visible = true;
            maslac.Visible = true;
            vocnijog.Visible = true;

        }

        private void mleko_Click(object sender, EventArgs e)
        {
            uKorpu(mleko, "Mleko");
        }

        private void jogurt_Click(object sender, EventArgs e)
        {
            uKorpu(jogurt, "Jogurt");
        }

        private void pavlaka_Click(object sender, EventArgs e)
        {
            uKorpu(pavlaka, "Pavlaka");
        }

        private void feta_Click(object sender, EventArgs e)
        {
            uKorpu(feta, "Feta sir");
        }

        private void kackavalj_Click(object sender, EventArgs e)
        {
            uKorpu(kackavalj, "Kackavalj");
        }

        private void eurokrem_Click(object sender, EventArgs e)
        {
            uKorpu(eurokrem, "Eurokrem");
        }

        private void maslac_Click(object sender, EventArgs e)
        {
            uKorpu(maslac, "Maslac");
        }

        private void vocnijog_Click(object sender, EventArgs e)
        {
            uKorpu(vocnijog, "Vocni jogurt");
        }

        /*private void Korpa_MouseClick(object sender, MouseEventArgs e)
        {
            Korpa.Items.Remove(Korpa.SelectedItem);
            
            
            if (Convert.ToString(Korpa.SelectedItem) == "Hleb")
                {
                    cena -= 35;     
                }
            
        }*/

        private void kraj_Click(object sender, EventArgs e)
        {
            pare.SelectionAlignment = HorizontalAlignment.Center;
            //dobrodosli.Visible = false;
            pictureBox6.Visible = true;
            kraj.Visible = false;
            peciva.Visible = false;
            mproizvodi.Visible = false;
            namirnice.Visible = false;
            voce.Visible = false;
            povrce.Visible = false;
            pice.Visible = false;
            meso.Visible = false;
            hemija.Visible = false;
            jedan.Visible = true;
            dva.Visible = true;
            tri.Visible = true;
            cetiri.Visible = true;
            pet.Visible = true;
            sest.Visible = true;
            sedam.Visible = true;
            osam.Visible = true;
            devet.Visible = true;
            nula.Visible = true;
            brisi.Visible = true;
            pare.Visible = true;
            krajkupovine.Visible = true;
            kusurlabel.Visible = true;
            kusur.Visible = true;

            hlebb.Visible = false;
            djevrekk.Visible = false;
            kiflaa.Visible = false;
            bagett.Visible = false;
            mleko.Visible = false;
            jogurt.Visible = false;
            pavlaka.Visible = false;
            feta.Visible = false;
            kackavalj.Visible = false;
            eurokrem.Visible = false;
            maslac.Visible = false;
            vocnijog.Visible = false;
            krofna.Visible = false;
            zuzu.Visible = false;
            minipice.Visible = false;
            burek.Visible = false;
            jaja.Visible = false;
            brasno.Visible = false;
            secer.Visible = false;
            so.Visible = false;
            biber.Visible = false;
            kecap.Visible = false;
            majonez.Visible = false;
            senf.Visible = false;
            jabuke.Visible = false;
            banane.Visible = false;
            grozdje.Visible = false;
            pomorandze.Visible = false;
            jagode.Visible = false;
            kruske.Visible = false;
            limun.Visible = false;
            kivi.Visible = false;
            crniluk.Visible = false;
            bkrompir.Visible = false;
            ckrompir.Visible = false;
            sargarepa.Visible = false;
            sampinjoni.Visible = false;
            paradajz.Visible = false;
            krastavac.Visible = false;
            kupus.Visible = false;
            mleveno.Visible = false;
            oslic.Visible = false;
            saran.Visible = false;
            parizer.Visible = false;
            sunka.Visible = false;
            plecka.Visible = false;
            file.Visible = false;
            cevapi.Visible = false;
            voda.Visible = false;
            gazirana.Visible = false;
            pivo.Visible = false;
            vino.Visible = false;
            kola.Visible = false;
            sjabuka.Visible = false;
            sbreskva.Visible = false;
            spomorandza.Visible = false;
            pasta.Visible = false;
            sapun.Visible = false;
            tecnisapun.Visible = false;
            sampon.Visible = false;
            geltusiranje.Visible = false;
            omeksivac.Visible = false;
            prasak.Visible = false;
            deterdz.Visible = false;

            pictureBox4.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            labelCena.Location = new Point(639, 122);
            ukupnaCena3.Location = new Point(644, 178);
            
            label2.Visible = false;

        }

        private void jedan_Click(object sender, EventArgs e)
        {
            pare.Text += 1;
            pare.SelectionAlignment = HorizontalAlignment.Center;
           


        }

        private void dva_Click(object sender, EventArgs e)
        {
            pare.Text += 2;
            pare.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void tri_Click(object sender, EventArgs e)
        {
            pare.Text += 3;
            pare.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void cetiri_Click(object sender, EventArgs e)
        {
            pare.Text += 4;
            pare.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void pet_Click(object sender, EventArgs e)
        {
            pare.Text += 5;
            pare.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void sest_Click(object sender, EventArgs e)
        {
            pare.Text += 6;
            pare.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void sedam_Click(object sender, EventArgs e)
        {
            pare.Text += 7;
            pare.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void osam_Click(object sender, EventArgs e)
        {
            pare.Text += 8;
            pare.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void devet_Click(object sender, EventArgs e)
        {
            pare.Text += 9;
            pare.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void nula_Click(object sender, EventArgs e)
        {
            pare.Text += 0;
            pare.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void brisi_Click(object sender, EventArgs e)
        {
            if (pare.Text.Length > 1)
            {
                pare.Text = pare.Text.Substring(0, pare.Text.Length - 1);
            }
            else
            {
                pare.Text = "";
            }
        }

        private void krajkupovine_Click(object sender, EventArgs e)
        {
            if (pare.Text == "")
            {
                kusur.Visible = false;
                greska2.Visible = true;
                return;
            }
            else
            {
                int x = Convert.ToInt32(pare.Text);
                if (cena == 0) kusur.Text = "Korpa je prazna";
                if (x - cena < 0)
                {
                    kusur.Visible = false;
                    greska.Visible = true;
                }
                else kusur.Text = "     " + Convert.ToString(x - cena);
            }
        }

        private void namirnice_Click(object sender, EventArgs e)
        {
            //dobrodosli.Visible = false;
            peciva.Visible = false;
            mproizvodi.Visible = false;
            namirnice.Visible = false;
            voce.Visible = false;
            //kraj.Visible = false;
            povrce.Visible = false;
            meso.Visible = false;
            pice.Visible = false;
            hemija.Visible = false;
            pictureBox6.Visible = true;

            jaja.Visible = true;
            brasno.Visible = true;
            secer.Visible = true;
            so.Visible = true;
            biber.Visible = true;
            kecap.Visible = true;
            majonez.Visible = true;
            senf.Visible = true;
        }

        private void jaja_Click(object sender, EventArgs e)
        {
            uKorpu(jaja, "Jaja");
        }

        private void brasno_Click(object sender, EventArgs e)
        {
            uKorpu(brasno, "Brasno");
        }

        private void secer_Click(object sender, EventArgs e)
        {
            uKorpu(secer, "Secer");
        }

        private void so_Click(object sender, EventArgs e)
        {
            uKorpu(so, "So");
        }

        private void biber_Click(object sender, EventArgs e)
        {
            uKorpu(biber, "Biber");
        }

        private void kecap_Click(object sender, EventArgs e)
        {
            uKorpu(kecap, "Kecap");
        }

        private void majonez_Click(object sender, EventArgs e)
        {
            uKorpu(majonez, "Majonez");
        }

        private void senf_Click(object sender, EventArgs e)
        {
            uKorpu(senf, "Senf");
        }

        private void voce_Click(object sender, EventArgs e)
        {
            //dobrodosli.Visible = false;
            peciva.Visible = false;
            mproizvodi.Visible = false;
            namirnice.Visible = false;
            voce.Visible = false;
            povrce.Visible = false;
            //kraj.Visible = false;
            meso.Visible = false;
            pice.Visible = false;
            hemija.Visible = false;
            pictureBox6.Visible = true;
            jabuke.Visible = true;
            banane.Visible = true;
            grozdje.Visible = true;
            pomorandze.Visible = true;
            jagode.Visible = true;
            kruske.Visible = true;
            limun.Visible = true;
            kivi.Visible = true;
        }

        private void jabuke_Click(object sender, EventArgs e)
        {
            uKorpu(jabuke, "Jabuke");
        }

        private void kruske_Click(object sender, EventArgs e)
        {
            uKorpu(kruske, "Kruske");
        }

        private void jagode_Click(object sender, EventArgs e)
        {
            uKorpu(jagode, "Jagode");
        }

        private void pomorandze_Click(object sender, EventArgs e)
        {
            uKorpu(pomorandze, "Pomorandze");
        }

        private void limun_Click(object sender, EventArgs e)
        {
            uKorpu(limun, "Limun");
        }

        private void banane_Click(object sender, EventArgs e)
        {
            uKorpu(banane, "Banane");
        }

        private void grozdje_Click(object sender, EventArgs e)
        {
            uKorpu(grozdje, "Grozdje");
        }

        private void kivi_Click(object sender, EventArgs e)
        {
            uKorpu(kivi, "Kivi");
        }


        private void povrce_Click(object sender, EventArgs e)
        {
            //dobrodosli.Visible = false;
            peciva.Visible = false;
            mproizvodi.Visible = false;
            namirnice.Visible = false;
            voce.Visible = false;
            povrce.Visible = false;
            meso.Visible = false;
            //kraj.Visible = false;
            pice.Visible = false;
            hemija.Visible = false;
            pictureBox6.Visible = true;

            crniluk.Visible = true;
            bkrompir.Visible = true;
            ckrompir.Visible = true;
            sargarepa.Visible = true;
            sampinjoni.Visible = true;
            paradajz.Visible = true;
            krastavac.Visible = true;
            kupus.Visible = true;
        }

        private void bkrompir_Click(object sender, EventArgs e)
        {
            uKorpu(bkrompir, "Krompir beli");
        }

        private void ckrompir_Click(object sender, EventArgs e)
        {
            uKorpu(ckrompir, "Krompir crveni");
        }

        private void paradajz_Click(object sender, EventArgs e)
        {
            uKorpu(paradajz, "Paradajz");
        }

        private void krastavac_Click(object sender, EventArgs e)
        {
            uKorpu(krastavac, "Krastavac");
        }

        private void kupus_Click(object sender, EventArgs e)
        {
            uKorpu(kupus, "Kupus");
        }

        private void sargarepa_Click(object sender, EventArgs e)
        {
            uKorpu(sargarepa, "Sargarepa");
        }

        private void sampinjoni_Click(object sender, EventArgs e)
        {
            uKorpu(sampinjoni, "Sampinjoni");
        }

        private void crniluk_Click(object sender, EventArgs e)
        {
            uKorpu(crniluk, "Crni Luk");
        }

        private void meso_Click(object sender, EventArgs e)
        {
            //dobrodosli.Visible = false;
            peciva.Visible = false;
            mproizvodi.Visible = false;
            namirnice.Visible = false;
            voce.Visible = false;
            povrce.Visible = false;
            //kraj.Visible = false;
            meso.Visible = false;
            pice.Visible = false;
            pictureBox6.Visible = true;
            hemija.Visible = false;

            mleveno.Visible = true;
            oslic.Visible = true;
            saran.Visible = true;
            parizer.Visible = true;
            sunka.Visible = true;
            plecka.Visible = true;
            file.Visible = true;
            cevapi.Visible = true;
        }

        private void pice_Click(object sender, EventArgs e)
        {
            //dobrodosli.Visible = false;
            peciva.Visible = false;
            mproizvodi.Visible = false;
            namirnice.Visible = false;
            voce.Visible = false;
            povrce.Visible = false;
            //kraj.Visible = false;
            meso.Visible = false;
            pice.Visible = false;
            hemija.Visible = false;
            pictureBox6.Visible = true;

            voda.Visible = true;
            gazirana.Visible = true;
            pivo.Visible = true;
            vino.Visible = true;
            kola.Visible = true;
            sjabuka.Visible = true;
            sbreskva.Visible = true;
            spomorandza.Visible = true;
        }

        private void mleveno_Click(object sender, EventArgs e)
        {
            uKorpu(mleveno, "Mleveno meso");
        }

        private void cevapi_Click(object sender, EventArgs e)
        {
            uKorpu(cevapi, "Cevapi");
        }

        private void plecka_Click(object sender, EventArgs e)
        {
            uKorpu(plecka, "Plecka");
        }

        private void file_Click(object sender, EventArgs e)
        {
            uKorpu(file, "Pileci file");
        }

        private void sunka_Click(object sender, EventArgs e)
        {
            uKorpu(sunka, "Sunka");
        }

        private void parizer_Click(object sender, EventArgs e)
        {
            uKorpu(parizer, "Parizer");
        }

        private void oslic_Click(object sender, EventArgs e)
        {
            uKorpu(oslic, "Oslic");
        }

        private void saran_Click(object sender, EventArgs e)
        {
            uKorpu(saran, "Saran");
        }

        private void voda_Click(object sender, EventArgs e)
        {
            uKorpu(voda, "Voda");
        }

        private void gazirana_Click(object sender, EventArgs e)
        {
            uKorpu(gazirana, "Gazirana Voda");
        }

        private void pivo_Click(object sender, EventArgs e)
        {
            uKorpu(pivo, "Pivo");
        }

        private void vino_Click(object sender, EventArgs e)
        {
            uKorpu(vino, "Vino");
        }

        private void kola_Click(object sender, EventArgs e)
        {
            uKorpu(kola, "Kola");
        }

        private void spomorandza_Click(object sender, EventArgs e)
        {
            uKorpu(spomorandza, "Sok Pomorandza");
        }

        private void sjabuka_Click(object sender, EventArgs e)
        {
            uKorpu(sjabuka, "Sok Jabuka");
        }

        private void sbreskva_Click(object sender, EventArgs e)
        {
            uKorpu(sbreskva, "Sok Breskva");
        }

        private void Korpa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Convert.ToString(Korpa.SelectedItem) == "Hleb 35")
            {
                cena -= 35;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Djevrek 30")
            {
                cena -= 30;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Krofna 50")
            {
                cena -= 50;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kifla 15")
            {
                cena -= 15;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Baget 30")
            {
                cena -= 30;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Zuzu 50")
            {
                cena -= 50;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "MiniPizze 60")
            {
                cena -= 60;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Burek 100")
            {
                cena -= 100;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Mleko 120")
            {
                cena -= 120;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Jogurt 130")
            {
                cena -= 130;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Maslac 169")
            {
                cena -= 169;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Pavlaka 115")
            {
                cena -= 115;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Feta sir 165")
            {
                cena -= 165;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kackavalj 1200")
            {
                cena -= 1200;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Vocni jogurt 82")
            {
                cena -= 82;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Eurokrem 230")
            {
                cena -= 230;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Jaja 10")
            {
                cena -= 10;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Brasno 60")
            {
                cena -= 60;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Secer 64")
            {
                cena -= 64;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "So 45")
            {
                cena -= 45;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Biber 115")
            {
                cena -= 115;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kecap 89")
            {
                cena -= 89;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Majonez 109")
            {
                cena -= 109;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Senf 112")
            {
                cena -= 112;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Jabuke 69")
            {
                cena -= 69;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kruske 125")
            {
                cena -= 125;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Jagode 250")
            {
                cena -= 250;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Pomorandze 99")
            {
                cena -= 99;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Limun 109")
            {
                cena -= 109;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Banane 125")
            {
                cena -= 125;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Grozdje 99")
            {
                cena -= 99;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kivi 139")
            {
                cena -= 139;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Krompir beli 79")
            {
                cena -= 79;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Krompir crveni 79")
            {
                cena -= 79;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Paradajz 199")
            {
                cena -= 199;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Krastavac 259")
            {
                cena -= 259;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kupus 65")
            {
                cena -= 65;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sargarepa 59")
            {
                cena -= 59;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sampinjoni 119")
            {
                cena -= 119;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Crni Luk 99")
            {
                cena -= 99;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Mleveno meso 799")
            {
                cena -= 799;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Cevapi 339")
            {
                cena -= 339;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Plecka 379")
            {
                cena -= 379;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Pileci file 480")
            {
                cena -= 480;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sunka 389")
            {
                cena -= 389;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Parizer 399")
            {
                cena -= 399;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Oslic 367")
            {
                cena -= 367;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Saran 469")
            {
                cena -= 469;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Voda 59")
            {
                cena -= 59;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Gazirana Voda 39")
            {
                cena -= 39;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Pivo 55")
            {
                cena -= 55;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Vino 849")
            {
                cena -= 849;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kola 125")
            {
                cena -= 125;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sok Pomorandza 110")
            {
                cena -= 110;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sok Jabuka 105")
            {
                cena -= 105;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sok Breskva 115")
            {
                cena -= 115;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }
            if(Convert.ToString(Korpa.SelectedItem) == "Pasta 189")
            {
                cena -= 189;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }
            if (Convert.ToString(Korpa.SelectedItem) == "Sapun 79")
            {
                cena -= 79;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Tecni sapun 169")
            {
                cena -= 169;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Gel 289")
            {
                cena -= 289;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Deterdzent 229")
            {
                cena -= 229;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Omeksivac 259")
            {
                cena -= 259;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Prasak 599")
            {
                cena -= 599;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sampon 319")
            {
                cena -= 319;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

        }

        private void kanta_Click(object sender, EventArgs e)
        {

            if (Convert.ToString(Korpa.SelectedItem) == "Hleb 35")
            {
                cena -= 35;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Djevrek 30")
            {
                cena -= 30;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Krofna 50")
            {
                cena -= 50;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kifla 15")
            {
                cena -= 15;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Baget 30")
            {
                cena -= 30;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Zuzu 50")
            {
                cena -= 50;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "MiniPizze 60")
            {
                cena -= 60;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Burek 100")
            {
                cena -= 100;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Mleko 120")
            {
                cena -= 120;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Jogurt 130")
            {
                cena -= 130;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Maslac 169")
            {
                cena -= 169;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Pavlaka 115")
            {
                cena -= 115;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Feta sir 165")
            {
                cena -= 165;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kackavalj 1200")
            {
                cena -= 1200;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Vocni jogurt 82")
            {
                cena -= 82;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Eurokrem 230")
            {
                cena -= 230;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Jaja 10")
            {
                cena -= 10;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Brasno 60")
            {
                cena -= 60;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Secer 64")
            {
                cena -= 64;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "So 45")
            {
                cena -= 45;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Biber 115")
            {
                cena -= 115;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kecap 89")
            {
                cena -= 89;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Majonez 109")
            {
                cena -= 109;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Senf 112")
            {
                cena -= 112;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Jabuke 69")
            {
                cena -= 69;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kruske 125")
            {
                cena -= 125;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Jagode 250")
            {
                cena -= 250;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Pomorandze 99")
            {
                cena -= 99;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Limun 109")
            {
                cena -= 109;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Banane 125")
            {
                cena -= 125;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Grozdje 99")
            {
                cena -= 99;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kivi 139")
            {
                cena -= 139;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Krompir beli 79")
            {
                cena -= 79;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Krompir crveni 79")
            {
                cena -= 79;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Paradajz 199")
            {
                cena -= 199;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Krastavac 259")
            {
                cena -= 259;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kupus 65")
            {
                cena -= 65;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sargarepa 59")
            {
                cena -= 59;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sampinjoni 119")
            {
                cena -= 119;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Crni Luk 99")
            {
                cena -= 99;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Mleveno meso 799")
            {
                cena -= 799;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Cevapi 339")
            {
                cena -= 339;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Plecka 379")
            {
                cena -= 379;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Pileci file 480")
            {
                cena -= 480;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sunka 389")
            {
                cena -= 389;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Parizer 399")
            {
                cena -= 399;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Oslic 367")
            {
                cena -= 367;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Saran 469")
            {
                cena -= 469;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Voda 59")
            {
                cena -= 59;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Gazirana Voda 39")
            {
                cena -= 39;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Pivo 55")
            {
                cena -= 55;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Vino 849")
            {
                cena -= 849;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Kola 125")
            {
                cena -= 125;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sok Pomorandza 110")
            {
                cena -= 110;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sok Jabuka 105")
            {
                cena -= 105;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sok Breskva 115")
            {
                cena -= 115;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }
            if (Convert.ToString(Korpa.SelectedItem) == "Pasta 189")
            {
                cena -= 189;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }
            if (Convert.ToString(Korpa.SelectedItem) == "Sapun 79")
            {
                cena -= 79;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Tecni sapun 169")
            {
                cena -= 169;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Gel 289")
            {
                cena -= 289;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Deterdzent 229")
            {
                cena -= 229;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Omeksivac 259")
            {
                cena -= 259;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Prasak 599")
            {
                cena -= 599;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }

            if (Convert.ToString(Korpa.SelectedItem) == "Sampon 319")
            {
                cena -= 319;
                Korpa.Items.Remove(Korpa.SelectedItem);
            }
        }

        void ml(Button b)
        {
            met.Enabled = false;
            mel.Enabled = true;
            int x = b.Size.Width;
            int y = b.Size.Height;
            b.Size = new Size(x - 10, y - 10);
        }

        void me(Button b)
        {
            int r;
            mel.Enabled = false;
            met.Enabled = true;

            int x = b.Size.Width;
            int y = b.Size.Height;
            
            b.Size = new Size(x + 10, y + 10);
    
        }

        private void peciva_MouseEnter(object sender, EventArgs e)
        {

            me(peciva);
       
         }

        private void peciva_MouseLeave(object sender, EventArgs e)
        {
            ml(peciva);
        }

        private void mproizvodi_MouseEnter(object sender, EventArgs e)
        {
            me(mproizvodi);
        }

        private void mproizvodi_MouseLeave(object sender, EventArgs e)
        {
            ml(mproizvodi);
        }

        private void namirnice_MouseEnter(object sender, EventArgs e)
        {
            me(namirnice);
        }

        private void namirnice_MouseLeave(object sender, EventArgs e)
        {
            ml(namirnice);
        }

        private void voce_MouseEnter(object sender, EventArgs e)
        {
            me(voce);
        }

        private void voce_MouseLeave(object sender, EventArgs e)
        {
            ml(voce);
        }

        private void povrce_MouseEnter(object sender, EventArgs e)
        {
            me(povrce);
        }

        private void povrce_MouseLeave(object sender, EventArgs e)
        {
            ml(povrce);
        }

        private void meso_MouseEnter(object sender, EventArgs e)
        {
            me(meso);
        }

        private void meso_MouseLeave(object sender, EventArgs e)
        {
            ml(meso);
        }

        private void pice_MouseEnter(object sender, EventArgs e)
        {
            me(pice);
        }

        private void pice_MouseLeave(object sender, EventArgs e)
        {
            ml(pice);
        }

        private void kraj_MouseEnter(object sender, EventArgs e)
        {
            me(kraj);
        }

        private void kraj_MouseLeave(object sender, EventArgs e)
        {
            ml(kraj);
        }

        private void hlebb_MouseEnter(object sender, EventArgs e)
        {
            me(hlebb);
        }

        private void hlebb_MouseLeave(object sender, EventArgs e)
        {
            ml(hlebb);
        }

        private void djevrekk_MouseEnter(object sender, EventArgs e)
        {
            me(djevrekk);
        }

        private void djevrekk_MouseLeave(object sender, EventArgs e)
        {
            ml(djevrekk);
        }

        private void krofna_MouseEnter(object sender, EventArgs e)
        {
            me(krofna);
        }

        private void krofna_MouseLeave(object sender, EventArgs e)
        {
            ml(krofna);
        }

        private void kiflaa_MouseEnter(object sender, EventArgs e)
        {
            me(kiflaa);
        }

        private void kiflaa_MouseLeave(object sender, EventArgs e)
        {
            ml(kiflaa);
        }

        private void bagett_MouseEnter(object sender, EventArgs e)
        {
            me(bagett);
        }

        private void bagett_MouseLeave(object sender, EventArgs e)
        {
            ml(bagett);
        }

        private void zuzu_MouseEnter(object sender, EventArgs e)
        {
            me(zuzu);
        }

        private void zuzu_MouseLeave(object sender, EventArgs e)
        {
            ml(zuzu);
        }

        private void minipice_MouseEnter(object sender, EventArgs e)
        {
            me(minipice);
        }

        private void minipice_MouseLeave(object sender, EventArgs e)
        {
            ml(minipice);
        }

        private void burek_MouseEnter(object sender, EventArgs e)
        {
            me(burek);
        }

        private void burek_MouseLeave(object sender, EventArgs e)
        {
            ml(burek);
        }

        private void mleko_MouseEnter(object sender, EventArgs e)
        {
            me(mleko);
        }

        private void mleko_MouseLeave(object sender, EventArgs e)
        {
            ml(mleko);
        }

        private void jogurt_MouseEnter(object sender, EventArgs e)
        {
            me(jogurt);
        }

        private void jogurt_MouseLeave(object sender, EventArgs e)
        {
            ml(jogurt);
        }

        private void maslac_MouseEnter(object sender, EventArgs e)
        {
            me(maslac);
        }

        private void maslac_MouseLeave(object sender, EventArgs e)
        {
            ml(maslac);
        }

        private void pavlaka_MouseEnter(object sender, EventArgs e)
        {
            me(pavlaka);
        }

        private void pavlaka_MouseLeave(object sender, EventArgs e)
        {
            ml(pavlaka);
        }

        private void feta_MouseEnter(object sender, EventArgs e)
        {
            me(feta);
        }

        private void feta_MouseLeave(object sender, EventArgs e)
        {
            ml(feta);
        }

        private void kackavalj_MouseEnter(object sender, EventArgs e)
        {
            me(kackavalj);
        }

        private void kackavalj_MouseLeave(object sender, EventArgs e)
        {
            ml(kackavalj);
        }

        private void vocnijog_MouseEnter(object sender, EventArgs e)
        {
            me(vocnijog);
        }

        private void vocnijog_MouseLeave(object sender, EventArgs e)
        {
            ml(vocnijog);
        }

        private void eurokrem_MouseEnter(object sender, EventArgs e)
        {
            me(eurokrem);
        }

        private void eurokrem_MouseLeave(object sender, EventArgs e)
        {
            ml(eurokrem);
        }

        private void jaja_MouseEnter(object sender, EventArgs e)
        {
            me(jaja);
        }

        private void jaja_MouseLeave(object sender, EventArgs e)
        {
            ml(jaja);
        }

        private void brasno_MouseEnter(object sender, EventArgs e)
        {
            me(brasno);
        }

        private void brasno_MouseLeave(object sender, EventArgs e)
        {
            ml(brasno);
        }

        private void secer_MouseEnter(object sender, EventArgs e)
        {
            me(secer);
        }

        private void secer_MouseLeave(object sender, EventArgs e)
        {
            ml(secer);
        }

        private void so_MouseEnter(object sender, EventArgs e)
        {
            me(so);
        }

        private void so_MouseLeave(object sender, EventArgs e)
        {
            ml(so);
        }

        private void biber_MouseEnter(object sender, EventArgs e)
        {
            me(biber);
        }

        private void biber_MouseLeave(object sender, EventArgs e)
        {
            ml(biber);
        }

        private void kecap_MouseEnter(object sender, EventArgs e)
        {
            me(kecap);
        }

        private void kecap_MouseLeave(object sender, EventArgs e)
        {
            ml(kecap);
        }

        private void majonez_MouseEnter(object sender, EventArgs e)
        {
            me(majonez);
        }

        private void majonez_MouseLeave(object sender, EventArgs e)
        {
            ml(majonez);
        }

        private void senf_MouseEnter(object sender, EventArgs e)
        {
            me(senf);
        }

        private void senf_MouseLeave(object sender, EventArgs e)
        {
            ml(senf);
        }

        private void jabuke_MouseEnter(object sender, EventArgs e)
        {
            me(jabuke);
        }

        private void jabuke_MouseLeave(object sender, EventArgs e)
        {
            ml(jabuke);
        }

        private void kruske_MouseEnter(object sender, EventArgs e)
        {
            me(kruske);
        }

        private void kruske_MouseLeave(object sender, EventArgs e)
        {
            ml(kruske);
        }

        private void jagode_MouseEnter(object sender, EventArgs e)
        {
            me(jagode);
        }

        private void jagode_MouseLeave(object sender, EventArgs e)
        {
            ml(jagode);
        }

        private void pomorandze_MouseEnter(object sender, EventArgs e)
        {
            me(pomorandze);
        }

        private void pomorandze_MouseLeave(object sender, EventArgs e)
        {
            ml(pomorandze);
        }

        private void limun_MouseEnter(object sender, EventArgs e)
        {
            me(limun);
        }

        private void limun_MouseLeave(object sender, EventArgs e)
        {
            ml(limun);
        }

        private void banane_MouseEnter(object sender, EventArgs e)
        {
            me(banane);
        }

        private void banane_MouseLeave(object sender, EventArgs e)
        {
            ml(banane);
        }

        private void grozdje_MouseEnter(object sender, EventArgs e)
        {
            me(grozdje);
        }

        private void grozdje_MouseLeave(object sender, EventArgs e)
        {
            ml(grozdje);
        }

        private void kivi_MouseEnter(object sender, EventArgs e)
        {
            me(kivi);
        }

        private void kivi_MouseLeave(object sender, EventArgs e)
        {
            ml(kivi);
        }

        private void bkrompir_MouseEnter(object sender, EventArgs e)
        {
            me(bkrompir);
        }

        private void bkrompir_MouseLeave(object sender, EventArgs e)
        {
            ml(bkrompir);
        }

        private void ckrompir_MouseEnter(object sender, EventArgs e)
        {
            me(ckrompir);
        }

        private void ckrompir_MouseLeave(object sender, EventArgs e)
        {
            ml(ckrompir);
        }

        private void paradajz_MouseEnter(object sender, EventArgs e)
        {
            me(paradajz);
        }

        private void paradajz_MouseLeave(object sender, EventArgs e)
        {
            ml(paradajz);
        }

        private void krastavac_MouseEnter(object sender, EventArgs e)
        {
            me(krastavac);
        }

        private void krastavac_MouseLeave(object sender, EventArgs e)
        {
            ml(krastavac);
        }

        private void kupus_MouseEnter(object sender, EventArgs e)
        {
            me(kupus);
        }

        private void kupus_MouseLeave(object sender, EventArgs e)
        {
            ml(kupus);
        }

        private void sargarepa_MouseEnter(object sender, EventArgs e)
        {
            me(sargarepa);
        }

        private void sargarepa_MouseLeave(object sender, EventArgs e)
        {
            ml(sargarepa);
        }

        private void sampinjoni_MouseEnter(object sender, EventArgs e)
        {
            me(sampinjoni);
        }

        private void sampinjoni_MouseLeave(object sender, EventArgs e)
        {
            ml(sampinjoni);
        }

        private void crniluk_MouseEnter(object sender, EventArgs e)
        {
            me(crniluk);
        }

        private void crniluk_MouseLeave(object sender, EventArgs e)
        {
            ml(crniluk);
        }

        private void mleveno_MouseEnter(object sender, EventArgs e)
        {
            me(mleveno);
        }

        private void mleveno_MouseLeave(object sender, EventArgs e)
        {
            ml(mleveno);
        }

        private void cevapi_MouseEnter(object sender, EventArgs e)
        {
            me(cevapi);
        }

        private void cevapi_MouseLeave(object sender, EventArgs e)
        {
            ml(cevapi);
        }

        private void plecka_MouseEnter(object sender, EventArgs e)
        {
            me(plecka);
        }

        private void plecka_MouseLeave(object sender, EventArgs e)
        {
            ml(plecka);
        }

        private void file_MouseEnter(object sender, EventArgs e)
        {
            me(file);
        }

        private void file_MouseLeave(object sender, EventArgs e)
        {
            ml(file);
        }

        private void sunka_MouseEnter(object sender, EventArgs e)
        {
            me(sunka);
        }

        private void sunka_MouseLeave(object sender, EventArgs e)
        {
            ml(sunka);
        }

        private void parizer_MouseEnter(object sender, EventArgs e)
        {
            me(parizer);
        }

        private void parizer_MouseLeave(object sender, EventArgs e)
        {
            ml(parizer);
        }

        private void oslic_MouseEnter(object sender, EventArgs e)
        {
            me(oslic);
        }

        private void oslic_MouseLeave(object sender, EventArgs e)
        {
            ml(oslic);
        }

        private void saran_MouseEnter(object sender, EventArgs e)
        {
            me(saran);
        }

        private void saran_MouseLeave(object sender, EventArgs e)
        {
            ml(saran);
        }

        private void voda_MouseEnter(object sender, EventArgs e)
        {
            me(voda);
        }

        private void voda_MouseLeave(object sender, EventArgs e)
        {
            ml(voda);
        }

        private void gazirana_MouseEnter(object sender, EventArgs e)
        {
            me(gazirana);
        }

        private void gazirana_MouseLeave(object sender, EventArgs e)
        {
            ml(gazirana);
        }

        private void pivo_MouseEnter(object sender, EventArgs e)
        {
            me(pivo);
        }

        private void pivo_MouseLeave(object sender, EventArgs e)
        {
            ml(pivo);
        }

        private void vino_MouseEnter(object sender, EventArgs e)
        {
            me(vino);
        }

        private void vino_MouseLeave(object sender, EventArgs e)
        {
            ml(vino);
        }

        private void kola_MouseEnter(object sender, EventArgs e)
        {
            me(kola);
        }

        private void kola_MouseLeave(object sender, EventArgs e)
        {
            ml(kola);
        }

        private void spomorandza_MouseEnter(object sender, EventArgs e)
        {
            me(spomorandza);
        }

        private void spomorandza_MouseLeave(object sender, EventArgs e)
        {
            ml(spomorandza);
        }

        private void sjabuka_MouseEnter(object sender, EventArgs e)
        {
            me(sjabuka);
        }

        private void sjabuka_MouseLeave(object sender, EventArgs e)
        {
            ml(sjabuka);
        }

        private void sbreskva_MouseEnter(object sender, EventArgs e)
        {
            me(sbreskva);
        }

        private void sbreskva_MouseLeave(object sender, EventArgs e)
        {
            ml(sbreskva);
        }

        private void hemija_MouseEnter(object sender, EventArgs e)
        {
            me(hemija);
        }

        private void hemija_MouseLeave(object sender, EventArgs e)
        {
            ml(hemija);
        }
        private void pasta_MouseEnter(object sender, EventArgs e)
        {
            me(pasta);
        }

        private void pasta_MouseLeave(object sender, EventArgs e)
        {
            ml(pasta);
        }

        private void sapun_MouseEnter(object sender, EventArgs e)
        {
            me(sapun);
        }

        private void sapun_MouseLeave(object sender, EventArgs e)
        {
            ml(sapun);
        }

        private void tecnisapun_MouseEnter(object sender, EventArgs e)
        {
            me(tecnisapun);
        }

        private void tecnisapun_MouseLeave(object sender, EventArgs e)
        {
            ml(tecnisapun);
        }

        private void geltusiranje_MouseEnter(object sender, EventArgs e)
        {
            me(geltusiranje);
        }

        private void geltusiranje_MouseLeave(object sender, EventArgs e)
        {
            ml(geltusiranje);
        }

        private void deterdz_MouseEnter(object sender, EventArgs e)
        {
            me(deterdz);
        }

        private void deterdz_MouseLeave(object sender, EventArgs e)
        {
            ml(deterdz);
        }

        private void omeksivac_MouseEnter(object sender, EventArgs e)
        {
            me(omeksivac);
        }

        private void omeksivac_MouseLeave(object sender, EventArgs e)
        {
            ml(omeksivac);
        }

        private void prasak_MouseEnter(object sender, EventArgs e)
        {
            me(prasak);
        }

        private void prasak_MouseLeave(object sender, EventArgs e)
        {
            ml(prasak);
        }

        private void sampon_MouseEnter(object sender, EventArgs e)
        {
            me(sampon);
        }

        private void sampon_MouseLeave(object sender, EventArgs e)
        {
            ml(sampon);
        }
        private void hemija_Click(object sender, EventArgs e)
        {
            //meni
            peciva.Visible = false;
            namirnice.Visible = false;
            voce.Visible = false;
            mproizvodi.Visible = false;
            povrce.Visible = false;
            pice.Visible = false;
            hemija.Visible = false;
            meso.Visible = false;
            pictureBox6.Visible = true;

            //proizvodi
            pasta.Visible = true;
            sapun.Visible = true;
            tecnisapun.Visible = true;
            sampon.Visible = true;
            geltusiranje.Visible = true;
            omeksivac.Visible = true;
            prasak.Visible = true;
            deterdz.Visible = true;
        }

        private void pasta_Click(object sender, EventArgs e)
        {
            uKorpu(pasta, "Pasta");
        }

        private void sapun_Click(object sender, EventArgs e)
        {
            uKorpu(sapun, "Sapun");
        }

        private void tecnisapun_Click(object sender, EventArgs e)
        {
            uKorpu(tecnisapun, "Tecni Sapun");
        }

        private void geltusiranje_Click(object sender, EventArgs e)
        {
            uKorpu(geltusiranje, "Gel");
        }

        private void deterdz_Click(object sender, EventArgs e)
        {
            uKorpu(deterdz, "Deterdzent");
        }

        private void omeksivac_Click(object sender, EventArgs e)
        {
            uKorpu(omeksivac, "Omeksivac");
        }

        private void prasak_Click(object sender, EventArgs e)
        {
            uKorpu(prasak, "Prasak");
        }

        private void sampon_Click(object sender, EventArgs e)
        {
            uKorpu(sampon, "Sampon");
        }

        private void pomoc_Click(object sender, EventArgs e)
        {
            pomocText.Visible = true;
            pictureBox6.Visible = true;
            //proizvodi
            hlebb.Visible = false;
            djevrekk.Visible = false;
            kiflaa.Visible = false;
            bagett.Visible = false;
            mleko.Visible = false;
            jogurt.Visible = false;
            pavlaka.Visible = false;
            feta.Visible = false;
            kackavalj.Visible = false;
            eurokrem.Visible = false;
            maslac.Visible = false;
            vocnijog.Visible = false;
            krofna.Visible = false;
            zuzu.Visible = false;
            minipice.Visible = false;
            burek.Visible = false;
            jaja.Visible = false;
            brasno.Visible = false;
            secer.Visible = false;
            so.Visible = false;
            biber.Visible = false;
            kecap.Visible = false;
            majonez.Visible = false;
            senf.Visible = false;
            jabuke.Visible = false;
            banane.Visible = false;
            grozdje.Visible = false;
            pomorandze.Visible = false;
            jagode.Visible = false;
            kruske.Visible = false;
            limun.Visible = false;
            kivi.Visible = false;
            crniluk.Visible = false;
            bkrompir.Visible = false;
            ckrompir.Visible = false;
            sargarepa.Visible = false;
            sampinjoni.Visible = false;
            paradajz.Visible = false;
            krastavac.Visible = false;
            kupus.Visible = false;
            mleveno.Visible = false;
            oslic.Visible = false;
            saran.Visible = false;
            parizer.Visible = false;
            sunka.Visible = false;
            plecka.Visible = false;
            file.Visible = false;
            cevapi.Visible = false;
            voda.Visible = false;
            gazirana.Visible = false;
            pivo.Visible = false;
            vino.Visible = false;
            kola.Visible = false;
            sjabuka.Visible = false;
            sbreskva.Visible = false;
            spomorandza.Visible = false;
            pasta.Visible = false;
            sapun.Visible = false;
            tecnisapun.Visible = false;
            sampon.Visible = false;
            geltusiranje.Visible = false;
            omeksivac.Visible = false;
            prasak.Visible = false;
            deterdz.Visible = false;

            //kraj
            jedan.Visible = false;
            dva.Visible = false;
            tri.Visible = false;
            cetiri.Visible = false;
            pet.Visible = false;
            sest.Visible = false;
            sedam.Visible = false;
            osam.Visible = false;
            devet.Visible = false;
            nula.Visible = false;
            brisi.Visible = false;
            pare.Visible = false;
            krajkupovine.Visible = false;
            kusur.Visible = false;
            kusurlabel.Visible = false;
            greska.Visible = false;
            greska2.Visible = false;

            //pocetni meni
            //dobrodosli.Visible = true;
            peciva.Visible = false;
            mproizvodi.Visible = false;
            namirnice.Visible = false;
            kraj.Visible = true;
            voce.Visible = false;
            povrce.Visible = false;
            meso.Visible = false;
            pice.Visible = false;
            hemija.Visible = false;


            //pictureBox6.Visible = false;
            labelCena.Visible = false;
            ukupnaCena3.Visible = false;
            //labelCena.Location = new Point(213, 284);
            //ukupnaCena3.Location = new Point(371, 284);
            //label2.Location = new Point(545, 284);
            label2.Visible = false;
            pictureBox4.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;

                     
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            player.controls.play();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            player.controls.pause();
        }

        private void Korpatron_Scroll(object sender, ScrollEventArgs e)
        {
            //peciva.Location = new System.Drawing.Point(35, 50 + VerticalScroll.Value);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            peciva.Location = new Point(35, 50 + VerticalScroll.Value);
        }
    }
        
}
