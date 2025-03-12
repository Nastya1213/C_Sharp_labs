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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadDataForLocation(4);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadDataForLocation(1);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LoadDataForLocation(3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoadDataForLocation(2);
        }

        private void LoadDataForLocation(int locationId)
        {
            // Создаем строку подключения к базе данных
            string connString = @"Data Source = DBSrv\gor2024; Initial Catalog = Ponomaryovadb; Integrated Security = True;";

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                try
                {
                    sqlConnection.Open();

                    // Запрос для получения персонажей по выбранной локации
                    string queryCharacters = @"
                SELECT p.ID, p.Ник, p.Раса, p.Уровень, p.Квента
                FROM [Ponomaryovadb].[dbo].[Персонаж] p
                JOIN [Ponomaryovadb].[dbo].[место_на_карте] m
                ON p.ID = m.id_персонажа
                WHERE m.id_локации = @LocationId;";

                    // Запрос для получения NPC по выбранной локации
                    string queryNPC = @"
                SELECT n.ID, n.имя, n.раса
                FROM [Ponomaryovadb].[dbo].[NPC] n
                WHERE n.id_локации = @LocationId;";

                    // Создаем адаптеры с параметром для защиты от SQL-инъекций
                    SqlDataAdapter adapterCharacters = new SqlDataAdapter(queryCharacters, sqlConnection);
                    adapterCharacters.SelectCommand.Parameters.AddWithValue("@LocationId", locationId);

                    SqlDataAdapter adapterNPC = new SqlDataAdapter(queryNPC, sqlConnection);
                    adapterNPC.SelectCommand.Parameters.AddWithValue("@LocationId", locationId);

                    // Создаем DataTable для хранения данных
                    DataTable dataTableCharacters = new DataTable();
                    DataTable dataTableNPC = new DataTable();

                    // Заполняем DataTable
                    adapterCharacters.Fill(dataTableCharacters);
                    adapterNPC.Fill(dataTableNPC);

                    // данные персонажей и NPC
                    DataTable pers = new DataTable();
                    pers.Columns.Add("ID");
                    pers.Columns.Add("Имя");
                    pers.Columns.Add("Раса");
                    pers.Columns.Add("Уровень");
                    pers.Columns.Add("Квента");

                    DataTable npc = new DataTable();
                    npc.Columns.Add("ID");
                    npc.Columns.Add("Имя");
                    npc.Columns.Add("Раса");
                   

                    // Добавляем персонажей
                    foreach (DataRow row in dataTableCharacters.Rows)
                    {
                        pers.Rows.Add(row["ID"], row["Ник"], row["Раса"], row["Уровень"], row["Квента"]);
                    }

                    // Добавляем NPC
                    foreach (DataRow row in dataTableNPC.Rows)
                    {
                        npc.Rows.Add(row["ID"], row["имя"], row["раса"]);
                    }

                    // Устанавливаем данные в DataGridView
                    dataGridView1.DataSource = dataTableCharacters;
                    dataGridView2.DataSource = npc;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем объект формы 4
            Form4 form4 = new Form4();

            // Открываем форму 4
            form4.Show();

            this.Hide(); // закроет текущую форму
        }
    }
}
