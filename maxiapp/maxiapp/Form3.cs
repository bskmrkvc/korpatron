using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace maxiapp
{

    public partial class Form3 : Form
    {
        
        
        public Form3()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = pictureBox2.CreateGraphics();

            if (i == pictureBox2.Width)
            {
                timer1.Enabled = false;
                pictureBox1.Visible = false;
                pictureBox3.Visible = true;
            }
            else { 
                SolidBrush cetka = new SolidBrush(Color.Gray);
                g.FillRectangle(cetka, 0, 0, i, pictureBox2.Height);
                i++;
            }
        }
       
        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            timer1.Enabled = true;
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Korpatron program = new Korpatron();
            Form3 ucitavanje = new Form3();

            //ucitavanje.Hide();
            Visible=false;
            program.Show();
            
        }
    }
}
