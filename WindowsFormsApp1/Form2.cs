using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private int currentPlayerId;

        // Конструктор, который принимает ID_игрока
        public Form2(int playerId)
        {
            InitializeComponent();
            currentPlayerId = playerId; // Сохраняем ID_игрока
        }

        // Получить ID_игрока
        public int GetCurrentPlayerId()
        {
            return currentPlayerId;
        }

        private int GenerateNewCharacterId()
        {
            int newId = 1;  // Начинаем с 1

            try
            {
                string connString = @"Data Source = DBSrv\gor2024; Initial Catalog = Ponomaryovadb; Integrated Security = True;";
                using (SqlConnection sqlConnection = new SqlConnection(connString))
                {
                    sqlConnection.Open();

                    // Получаем максимальный ID персонажа из таблицы
                    string query = "SELECT MAX(ID) FROM Персонаж";  // MAX возвращает наибольшее значение ID
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    object result = sqlCommand.ExecuteScalar();  // Получаем результат запроса

                    if (result != DBNull.Value)
                    {
                        newId = Convert.ToInt32(result) + 1;  // Увеличиваем максимальный ID на 1
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при генерации нового ID: " + ex.Message);
            }

            return newId;  // Возвращаем сгенерированный ID
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Получаем текущий ID игрока
            int playerId = GetCurrentPlayerId();

            if (playerId == 0)
            {
                MessageBox.Show("Вы не авторизованы.");
                return;
            }

            try
            {
                // Устанавливаем строку подключения
                string connString = @"Data Source = DBSrv\gor2024; Initial Catalog = Ponomaryovadb; Integrated Security = True;";

                using (SqlConnection sqlConnection = new SqlConnection(connString))
                {
                    // Открываем соединение
                    sqlConnection.Open();

                    // Запрос для получения всех персонажей этого игрока
                    string query = "SELECT ID, Ник, Раса, Уровень, Квента FROM Персонаж WHERE ID_игрока = @PlayerId";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@PlayerId", playerId);

                    // Выполняем запрос и получаем результаты
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Устанавливаем результат в DataGridView
                    dataGridView1.DataSource = dataTable;  // Выводим данные в DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что все поля заполнены
                if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
                    !string.IsNullOrWhiteSpace(textBox2.Text) &&
                    !string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    // Получаем ID игрока, который авторизовался
                    int playerId = GetCurrentPlayerId(); // Получаем ID из Form1 или где-то еще
                    int newCharacterId = GenerateNewCharacterId();  // Генерируем новый ID для персонажа

                    // Получаем данные из полей
                    string nick = textBox1.Text;
                    string race = textBox2.Text;
                    string quests = textBox3.Text;
                    int level = trackBar1.Value; // Получаем уровень из TrackBar (он будет от 1 до 100)
                                                 // Строка подключения
                    string connString = @"Data Source = DBSrv\gor2024; Initial Catalog = Ponomaryovadb; Integrated Security = True;";
                    using (SqlConnection sqlConnection = new SqlConnection(connString))
                    {
                        sqlConnection.Open();

                        // Запрос для добавления персонажа в базу данных
                        string query = "INSERT INTO Персонаж (ID, Ник, Раса, Уровень, Квента, ID_игрока) " +
                                       "VALUES (@Id, @Nick, @Race, @Level, @Quests, @PlayerId)";

                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@Id", newCharacterId);
                            sqlCommand.Parameters.AddWithValue("@Nick", nick);
                            sqlCommand.Parameters.AddWithValue("@Race", race);
                            sqlCommand.Parameters.AddWithValue("@Level", level);
                            sqlCommand.Parameters.AddWithValue("@Quests", quests);
                            sqlCommand.Parameters.AddWithValue("@PlayerId", playerId);

                            // Выполняем запрос
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Персонаж успешно добавлен!");
                        }
                    }

                    // Очистим поля после добавления
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    trackBar1.Value = 1; // сбрасываем уровень на 1

                    // Обновим отображение персонажей (если нужно)
                    //LoadCharacters();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении персонажа: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Закрываем текущую форму (Form2)
            this.Close();

            // Открываем форму 1 (Form1)
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Создаем объект формы 3
            Form3 form3 = new Form3();

            // Открываем форму 3
            form3.Show();

            this.Hide(); // закроет текущую форму
        }
    }
}
