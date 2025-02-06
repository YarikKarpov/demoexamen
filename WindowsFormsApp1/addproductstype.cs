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

    public partial class addproductstype : Form
    {
        string connectionstring = "Server=localhost;Database=demo;User ID=root;Password=luckygmdproduction;Port=3306;";
        public addproductstype()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void AddDataToDatabase()
        {
            string query = "insert into тип_продукта(Тип_продукции,Коэффициент_типа_продукции)" +
                "values (@Тип_продукции, @Коэффициент_типа_продукции)";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Добавление параметров
                    command.Parameters.AddWithValue("@Тип_продукции", textBox1.Text);
                    command.Parameters.AddWithValue("@Коэффициент_типа_продукции", textBox2.Text);
            


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
