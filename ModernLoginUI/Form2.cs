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
using System.Data.SqlClient;

namespace ModernLoginUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
        MyDatabase myDatabase = new MyDatabase();
        public void Mukkerrer()
        {
            SqlCommand sqlCommand = new SqlCommand("Select * from Tbl_KullaniciBilgi", myDatabase.baglanti());
            SqlDataReader sqlDatareader = sqlCommand.ExecuteReader();
            while (sqlDatareader.Read() == true)
            {
                if (textBox2.Text == sqlDatareader["Username"].ToString() || textBox3.Text == sqlDatareader["Email"].ToString())
                {
                    MessageBox.Show("Mükerrer Error", "Email Veya Şifre  Kullanilmaktadir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {            
                    Kayit();

                }
                break;
            }
            myDatabase.baglanti().Close();
        
        }
        public void Kayit()
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Tbl_KullaniciBilgi (Username,Email,Password)values(@p1,@p2,@p3)", myDatabase.baglanti());
            sqlCommand.Parameters.AddWithValue("@p1", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@p2", textBox2.Text);
            string veri = textBox3.Text;
            byte[] data = ASCIIEncoding.ASCII.GetBytes(veri);
            string veri2 = Convert.ToBase64String(data);
            sqlCommand.Parameters.AddWithValue("@p3", veri2);
            sqlCommand.ExecuteNonQuery();
            myDatabase.baglanti().Close();
            MessageBox.Show("Başarılı bir şekilde kaydınız alınmıştır", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new Font(button1.Font.FontFamily, 18);

        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Font = new Font(button1.Font.FontFamily, 21);
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
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                Mukkerrer();
            }
            else
            {
                MessageBox.Show("Girdiğiniz Şifreler Eşleşmemektedir", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
