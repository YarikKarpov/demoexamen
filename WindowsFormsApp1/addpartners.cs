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

namespace WindowsFormsApp1
{
    public partial class addpartners : Form
    {
        string connectionString = "Server=localhost;Database=demo;User ID=root;Password=luckygmdproduction;Port=3306;";
        public addpartners()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
   
    private void AddDataToDatabase()
        {
            string query = "insert into партнеры(Тип_партнера,Наименование_партнера,Директор,Почта_партнера,Телефон,Юридический_адрес,ИНН,Рейтинг)"+
                "values (@Тип_партнера, @Наименование_партнера, @Директор, @Почта_партнера, @Телефон, @Юридический_адрес, @ИНН, @Рейтинг)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Добавление параметров
                    command.Parameters.AddWithValue("@Тип_партнера", textBox1.Text);
                    command.Parameters.AddWithValue("@Наименование_партнера", textBox2.Text);
                    command.Parameters.AddWithValue("@Директор", textBox3.Text);
                    command.Parameters.AddWithValue("@Почта_партнера", textBox4.Text);
                    command.Parameters.AddWithValue("@Телефон", textBox5.Text);
                    command.Parameters.AddWithValue("@Юридический_адрес", textBox5.Text);
                    command.Parameters.AddWithValue("@ИНН", textBox5.Text);
                    command.Parameters.AddWithValue("@Рейтинг", textBox5.Text);

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
