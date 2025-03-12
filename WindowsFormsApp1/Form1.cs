using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {   // Глобальная переменная для хранения ID_игрока
        private int currentPlayerId;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Функция для получения текущего ID игрока
        public int GetCurrentPlayerId()
        {
            return currentPlayerId;
        }
        private void getUser()
        {
            try
            {


                if
                    (textBox1.Text != null && textBox2.Text != null)
                {

                    string connString = @"Data Source = DBSrv\gor2024; Initial Catalog = Ponomaryovadb; Integrated Security = True;";
                    SqlConnection sqlConnection = new SqlConnection(connString);

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("select * from [Игрок] where [Логин] = '" + textBox1.Text + "' and [Пароль] = '" + textBox2.Text + "'", sqlConnection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        currentPlayerId = (int)sqlDataReader["ID"]; // Получаем ID_игрока из базы
                        MessageBox.Show("Успешный вход!");
                        // Открываем Form2 и передаем ID_игрока
                        Form2 form2 = new Form2(currentPlayerId);
                        form2.Show();  // Открываем форму с передачей ID

                        // Закрываем текущую форму, если нужно
                        this.Hide(); // Это скроет текущую форму (Form1), но не закрывает её

                    }
                    else
                    {
                        MessageBox.Show("Данные не верны!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            getUser();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null)
            {
                try
                {
                    string connString = @"Data Source = DBSrv\gor2024; Initial Catalog = Ponomaryovadb; Integrated Security = True;";
                    SqlConnection sqlConnection = new SqlConnection(connString);

                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("insert into [Players] values ('" + textBox1.Text + "','" + textBox2.Text + "','12.20.231.128','qyutghd@mas.com')", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    textBox1.Text = null;
                    textBox2.Text = null;

                    MessageBox.Show(" добавлена");
                }
                catch
                {
                    MessageBox.Show("Exception", "Error");
                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }
    }
}
