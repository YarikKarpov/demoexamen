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
    public partial class addpartnersproducts : Form
    {
        string connectionstring = "Server=localhost;Database=demo;User ID=root;Password=luckygmdproduction;Port=3306;";
        public addpartnersproducts()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void AddDataToDatabase()
        {
            string query = "insert into продукты_партнеров(Продукция,Партнер,Количество_продукции,Дата_продажи)" +
                "values (@Продукция, @Партнер, @Количество_продукции, @Дата_продажи)";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Добавление параметров
                    command.Parameters.AddWithValue("@Продукция", textBox1.Text);
                    command.Parameters.AddWithValue("@Партнер", textBox2.Text);
                    command.Parameters.AddWithValue("@Количество_продукции", textBox3.Text);
                    command.Parameters.AddWithValue("@Дата_продажи", textBox4.Text);


                    // Выполнение команды
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные успешно добавлены!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении данных.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения: " + ex.Message);
                }
            }
        }
        private void button1_click(object sender, EventArgs e)
        {
            AddDataToDatabase();
        }

    }
}
