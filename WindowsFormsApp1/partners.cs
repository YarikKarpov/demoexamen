using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class partners : Form
    {
        public partners()
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
            listView1.Columns.Add("Тип партнера", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Наименование партнера", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Директор", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Почта партнера", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Телефон", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Юридический адрес", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("ИНН", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Рейтинг", -2, HorizontalAlignment.Left);
        }

        // Подключение к серверу
        string connectionString = "Server=localhost;Database=demo;User ID=root;Password=luckygmdproduction;Port=3306;";
        private void ConnectToDatabase()
        {
            string query = "SELECT * FROM партнеры;";

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
                        item.SubItems.Add(reader["Тип_партнера"].ToString());
                        item.SubItems.Add(reader["Наименование_партнера"].ToString());
                        item.SubItems.Add(reader["Директор"].ToString());
                        item.SubItems.Add(reader["Почта_партнера"].ToString());
                        item.SubItems.Add(reader["Телефон"].ToString());
                        item.SubItems.Add(reader["Юридический_адрес"].ToString());
                        item.SubItems.Add(reader["ИНН"].ToString());
                        item.SubItems.Add(reader["Рейтинг"].ToString());

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
        private void button2_click(object sender, EventArgs e)
        {
          
        }
     
        private void button4_click(object sender, EventArgs e)
        {
            addpartners add = new addpartners();
            add.Show();
        }
        private void button5_click(object sender, EventArgs e)
        {
            deletepartners deleteparners = new deletepartners();
            deleteparners.Show();
        }
        private void form3_Load(object sender, EventArgs e)
        {

        }

    }
}
