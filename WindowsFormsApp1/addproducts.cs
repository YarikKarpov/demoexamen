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
    public partial class addproducts : Form
    {
        string connectionString = "Server=localhost;Database=demo;User ID=root;Password=luckygmdproduction;Port=3306;";
        public addproducts()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void AddDataToDatabase()
        {
            string query = "insert into продукты(Тип_продукции,Наименование_продукции,Артикул,Минимальная_стоимость_для_партнера)" +
                "values (@Тип_продукции, @Наименование_продукции, @Артикул, @Минимальная_стоимость_для_партнера)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Добавление параметров
                    command.Parameters.AddWithValue("@Тип_продукции", textBox1.Text);
                    command.Parameters.AddWithValue("@Наименование_продукции", textBox2.Text);
                    command.Parameters.AddWithValue("@Артикул", textBox3.Text);
                    command.Parameters.AddWithValue("@Минимальная_стоимость_для_партнера", textBox4.Text);
            

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
