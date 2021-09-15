using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ModernLoginUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 frm2 = new Form2();
        MyDatabase myDatabase = new MyDatabase();
         void BilgilerimiGetir() 
        {
            SqlCommand sqlCommand = new SqlCommand("Select * from Tbl_KullaniciBilgi where Username=@p1 and Password=@p2", myDatabase.baglanti());
            sqlCommand.Parameters.AddWithValue("@p1", textBox1.Text.Trim());
            byte[] veri = ASCIIEncoding.ASCII.GetBytes(textBox2.Text);
            string sifre = Convert.ToBase64String(veri);
            sqlCommand.Parameters.AddWithValue("@p2", sifre);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                MessageBox.Show("Giriş Başarılı", "WELCOME", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                MessageBox.Show("Kullanici Adi Veya Şifreniz Hatali", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frm2.Show();
            frm2.Left += 150;
            if (frm2.Left>=1000)
            {
                timer2.Start();
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            frm2.Left -= 150;
            if (frm2.Left <=950)
            {
                timer1.Stop();
                this.TopMost = false;
                this.Hide();
                frm2.TopMost = true;       
                timer2.Stop();
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Font = new Font(button1.Font.FontFamily, 21);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new Font(button1.Font.FontFamily, 18);
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.Font = new Font(button2.Font.FontFamily, 21);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Font = new Font(button2.Font.FontFamily, 18);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BilgilerimiGetir();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
