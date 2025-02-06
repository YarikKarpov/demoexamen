using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        string connectionString = "Server=localhost;Database=demo;User ID=root;Password=luckygmdproduction;Port=3306;";
        public login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AuthenticateUser()
        {
            string query = "SELECT * FROM users WHERE username = @username AND password = @password";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", textBox1.Text);
                    command.Parameters.AddWithValue("@password", textBox2.Text);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Авторизация успешна");
                        this.Hide();
                        tables tables = new tables();
                        tables.Show();

                    }
                    else
                    {
                        MessageBox.Show("Неверное имя пользователя или пароль");
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения" + ex.Message);
                }
            }
        }

                
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {
       
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }

        private void loginbutton_Click_1(object sender, EventArgs e)
        {
            AuthenticateUser();
        }
    }
}
