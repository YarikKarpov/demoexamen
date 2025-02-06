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
    public partial class deletematerialtype : Form
    {
        string connectionstring = "Server=localhost;Database=demo;User ID=root;Password=luckygmdproduction;Port=3306;";
        public deletematerialtype()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void deletefromdatabase()
        {
            string query = "DELETE FROM тип_материала WHERE Код = @Код";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Код", textBox1.Text);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные успешно удалены");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка удаления");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения" + ex.Message);
                }
            }
        }
        private void button1_click(object sender, EventArgs e)
        {
            deletefromdatabase();
        }
    }
}
