using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ContextLibrary.Entities;


namespace Lab2_Var4
{
    /// <summary>
    /// Логика взаимодействия для RequestWindow.xaml
    /// </summary>
    public partial class RequestWindow : Window
    {
        public Request Request { get; set; }
        public ObservableCollection<string> Statuses { get; } = new()
        {
            "Новая заявка",
            "В процессе ремонта",
            "Завершена"
        };

        public RequestWindow()
        {
            InitializeComponent();
            Request = new ContextLibrary.Entities.Request
            {
                Id = Guid.NewGuid().ToString(), // Генерация уникального номера заявки
                DateAdded = DateTime.Now // Текущая дата
            };
            DataContext = this;
        }

        public RequestWindow(Request request)
        {
            InitializeComponent();
            Request = request;
            DataContext = this;
        }

        // Сохранение данных
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request.EquipmentType) ||
                string.IsNullOrWhiteSpace(Request.EquipmentModel) ||
                string.IsNullOrWhiteSpace(Request.ProblemDescription) ||
                string.IsNullOrWhiteSpace(Request.ClientName) ||
                string.IsNullOrWhiteSpace(Request.PhoneNumber))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка формата телефона
            if (!System.Text.RegularExpressions.Regex.IsMatch(Request.PhoneNumber, @"^\+?\d{10,15}$"))
            {
                MessageBox.Show("Некорректный номер телефона!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }

        // Отмена ввода
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
