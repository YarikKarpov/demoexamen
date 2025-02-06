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
    public partial class partners_products : Form
    {
        public partners_products()
        {
            InitializeComponent();
            ConfigureListView();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        // Настройка ListView
        private void ConfigureListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Код", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Продукция", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Партнер", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Количество продукции", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Дата продажи", -2, HorizontalAlignment.Left);
        }

        // Подключение к серверу
        string connectionString = "Server=localhost;Database=demo;User ID=root;Password=luckygmdproduction;Port=3306;";
        private void ConnectToDatabase()
        {
            string query = "SELECT * FROM продукты_партнеров;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    listView1.Items.Clear();

                    // Проверка данных
                    while (reader.Read())
                    {


                        ListViewItem item = new ListViewItem(reader["Код"].ToString());
                        item.SubItems.Add(reader["Продукция"].ToString());
                        item.SubItems.Add(reader["Партнер"].ToString());
                        item.SubItems.Add(reader["Количество_продукции"].ToString());
                        item.SubItems.Add(reader["Дата_продажи"].ToString());
                        listView1.Items.Add(item);
                    }
                    reader.Close();

                    // Отладочное сообщение
                    MessageBox.Show("Данные успешно загружены.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения: " + ex.Message);
                }
            }
        }
    
    private void button1_click(object sender, EventArgs e)
        {
            ConnectToDatabase();
        }
        private void button4_click(object sender, EventArgs e)
        {
            addpartnersproducts addpartnersproducts = new addpartnersproducts();
            addpartnersproducts.Show();
        }
        private void button5_click(object sender, EventArgs e)
        {
            deletepartners deletepartners = new deletepartners();
            deletepartners.Show();
        }
    }
}
