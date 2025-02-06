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
    public partial class products : Form
    {
        public products()
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
            listView1.Columns.Add("Тип продукции", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Наименование продукции", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Артикул", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Минимальная_стоимость_для_партнера", -2, HorizontalAlignment.Left);
        }

        // Подключение к серверу
        string connectionString = "Server=localhost;Database=demo;User ID=root;Password=luckygmdproduction;Port=3306;";
        private void ConnectToDatabase()
        {
            string query = "SELECT * FROM продукты;";

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
                        item.SubItems.Add(reader["Тип_продукции"].ToString());
                        item.SubItems.Add(reader["Наименование_продукции"].ToString());
                        item.SubItems.Add(reader["Артикул"].ToString());
                        item.SubItems.Add(reader["Минимальная_стоимость_для_партнера"].ToString());
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
    
    private void button1_Click(object sender, EventArgs e)
        {
            ConnectToDatabase();
        }
        private void button4_click(object sender, EventArgs e)
        {
            addproducts addproducts = new addproducts();
            addproducts.Show();
        }
        private void button5_click(object sender, EventArgs e)
        {
            deleteproducts deleteproducts = new deleteproducts();
            deleteproducts.Show();
        }

    }
}

