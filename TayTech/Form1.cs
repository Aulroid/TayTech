using System;
using System.Data.SqlClient;

namespace TayTech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "KULLANICI ID";
            textBox1.ForeColor = Color.Gray;

            textBox1.Enter += kullaniciIdTextBox_Enter;
            textBox1.Leave += kullaniciIdTextBox_Leave;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciID = textBox1.Text.Trim();
            
            bool response = KullaniciGirisYap(kullaniciID);
            if (response)
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
        }

        private void kullaniciIdTextBox_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "KULLANICI ID")
            {
                textBox1.Text = "";
                
            }
        }

        private void kullaniciIdTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "KULLANICI ID";
               
            }
        }

        private bool KullaniciGirisYap(string kullaniciID)
        {
             
            string connectionString =
                "Data Source=DESKTOP-LAI404R;Initial Catalog=TayTech;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciID = @kullaniciID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);

                int result = (int)cmd.ExecuteScalar();
                 
                if (result > 0)
                {
                    MessageBox.Show("Giriþ baþarýlý!", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Kullanýcý ID bulunamadý!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}