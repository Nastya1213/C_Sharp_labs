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

namespace Lab2_Var4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Request> Requests { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Загружаем заявки из контекста
            using (var context = new ApplicationContext())
            {
                Requests = new ObservableCollection<Request>(context.Requests);
            }
        }

        // Добавление заявки
        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new RequestWindow();
            if (addWindow.ShowDialog() == true)
            {
                using (var context = new ApplicationContext())
                {
                    context.Requests.Add(addWindow.Request);
                }
                Requests.Add(addWindow.Request);
            }
        }

        // Редактирование заявки
        private void EditRequest_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsGrid.SelectedItem is Request selectedRequest)
            {
                var editWindow = new RequestWindow(selectedRequest);
                if (editWindow.ShowDialog() == true)
                {
                    RequestsGrid.Items.Refresh(); // Обновление UI
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
            if (RequestsGrid.SelectedItem is Request selectedRequest)
            {
                if (MessageBox.Show("Удалить выбранную заявку?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    using (var context = new ApplicationContext())
                    {
                        context.Requests.Remove(selectedRequest);
                    }
                    Requests.Remove(selectedRequest);
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}