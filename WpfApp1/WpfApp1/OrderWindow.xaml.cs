using ContextLibrary;
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
using ContextLibrary.Enums;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public Order Order { get; set; }
        public ObservableCollection<RequestStatus> Statuses { get; } = new(Enum.GetValues<RequestStatus>());
        public ObservableCollection<DeliveryType> Types { get; } = new(Enum.GetValues<DeliveryType>());
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();


        /// <summary>
        // Метод генерации нового ID
        /// </summary>
        private int GenerateNewId()
        {
            using var context = new ApplicationContext();
            return context.Orders.Any() ? context.Orders.Max(r => r.Id) + 1 : 1;
        }

        public OrderWindow()
        {
            InitializeComponent();
            using ApplicationContext context = new ApplicationContext();
            LoadProducts();
            LoadEmployees();
            //проверка товаров с низким запасом
            var lowStockProducts = context.Products.Where(p => p.IsLowStock()).ToList();
            if (lowStockProducts.Any())
            {
                string message = "Низкий запас товаров:\n" + string.Join("\n", lowStockProducts.Select(p => $"{p.Name} (Осталось {p.Quantity})"));
                MessageBox.Show(message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

                Order = new ContextLibrary.Entities.Order
            {
                Id = GenerateNewId(), // Генерация нового ID
                DateAdd = DateTime.Now // Текущая дата
            };
            DataContext = this;

        }

        private void LoadProducts()
        {
            using var context = new ApplicationContext();
            var productsList = context.Products.ToList();
            foreach (var product in productsList)
            {
                Products.Add(product);
            }
        }

        private void LoadEmployees()
        {
            using var context = new ApplicationContext();
            var employees = context.Employees.ToList();
            foreach (var employee in employees)
            { Employees.Add(employee); }
        }

        public OrderWindow(Order order)
        {
            InitializeComponent();
            Order = order;
            LoadProducts();
            LoadEmployees() ;
            DataContext = this;
           

        }

        // Обработчик изменения выбранного продукта
        private void ProductComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Order.Product != null)
            {
                Order.Weight = Order.Product.Weight; // Устанавливаем вес
                Order.Volume = Order.Product.Volume; // Устанавливаем объём
            }
        }

        
        


        // Сохранение данных
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Order.FullName) ||
                string.IsNullOrWhiteSpace(Order.PhoneNumber ))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка формата телефона
            if (!System.Text.RegularExpressions.Regex.IsMatch(Order.PhoneNumber, @"^\+?\d{10,15}$"))
            {
                MessageBox.Show("Некорректный номер телефона!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Уменьшаем количество выбранного продукта в базе данных
            if (Order.Product != null && Order.Quantity > 0)
            {
                using var context = new ApplicationContext();
                var productInDb = context.Products.FirstOrDefault(p => p.Id == Order.Product.Id);
                if (productInDb != null)
                {
                    productInDb.Quantity -= Order.Quantity; // Уменьшаем количество
  
                }
                
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
