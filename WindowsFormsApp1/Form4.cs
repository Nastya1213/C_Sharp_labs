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
    public partial class Form4 : Form
    {
        private int currentPlayerId;
        private string connString = @"Data Source=DBSrv\gor2024;Initial Catalog=Ponomaryovadb;Integrated Security=True;";


        public Form4()
        {
            InitializeComponent();
            LoadClassesIntoComboBox();
        }
        // Метод для загрузки классов в ComboBox
        private void LoadClassesIntoComboBox()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "SELECT ID, название FROM класс";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBox1.DataSource = dataTable;
                    comboBox1.DisplayMember = "название"; // Отображаемое поле
                    comboBox1.ValueMember = "ID"; // Значение, которое будет использоваться
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке классов: " + ex.Message);
                }
            }
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }


        // Метод для загрузки персонажей по выбранному классу
        private void LoadCharactersByClass(int classId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                try
                {
                    sqlConnection.Open();
                    string query = @"
                        SELECT p.ID, p.Ник, p.Раса, p.Уровень, p.Квента
                        FROM Персонаж p
                        JOIN персонаж_класс pc ON p.ID = pc.id_персонажа
                        WHERE pc.id_класса = @ClassId;";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                    adapter.SelectCommand.Parameters.AddWithValue("@ClassId", classId);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке персонажей: " + ex.Message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox1.SelectedValue is int)
            {
                int selectedClassId = (int)comboBox1.SelectedValue;
                LoadCharactersByClass(selectedClassId);
            }
            else
            {
                MessageBox.Show("Выберите класс из списка.");
            }
        }
    }
}
