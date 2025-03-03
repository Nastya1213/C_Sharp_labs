using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContextLibrary;
using ContextLibrary.Entities;


namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<Order> Orders { get; set; }
    public ObservableCollection<Product> Products { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;

        // Загружаем заявки из контекста
        using (var context = new ApplicationContext())
        {
            Orders = new ObservableCollection<Order>(context.Orders);
        }
    }

    private void Storage_Click(object sender, RoutedEventArgs e)
    {
        StorageWindow storageWindow = new StorageWindow();
        storageWindow.Show();
    }


    private void Statistic_Click(object sender, RoutedEventArgs e)
    {

        // Создаем отчет на основе текущих заказов
        var report = new SalesReport(Orders.ToList());
        // Открываем окно с отчетом
        ReportWindow reportWindow = new ReportWindow(report);
        reportWindow.Show();
    }



    // Добавление заявки
    private void AddRequest_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new OrderWindow();
        if (addWindow.ShowDialog() == true)
        {
            using (var context = new ApplicationContext())
            {
                context.Orders.Add(addWindow.Order);
            }
            Orders.Add(addWindow.Order);
        }
    }


    // Редактирование заявки
    private void EditRequest_Click(object sender, RoutedEventArgs e)
    {
        if (OrderGrid.SelectedItem is Order selectedRequest)
        {
            var editWindow = new OrderWindow(selectedRequest);
            if (editWindow.ShowDialog() == true)
            {
                OrderGrid.Items.Refresh(); // Обновление UI
            }
        }
        else
        {
            MessageBox.Show("Выберите заявку для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
    // Удаление заявки
    private void DeleteRequest_Click(object sender, RoutedEventArgs e)
    {
        if (OrderGrid.SelectedItem is Order selectedRequest)
        {
            if (MessageBox.Show("Удалить выбранную заявку?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (var context = new ApplicationContext())
                {
                    context.Orders.Remove(selectedRequest);
                }
                Orders.Remove(selectedRequest);
            }
        }
        else
        {
            MessageBox.Show("Выберите заявку для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }


}