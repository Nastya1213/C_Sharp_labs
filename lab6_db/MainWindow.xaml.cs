using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace lab6_db
{
    public partial class MainWindow : Window
    {
        private ApplicationDbContext dbContext;
        public ObservableCollection<Request> Requests { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            dbContext = new ApplicationDbContext();
            Requests = new ObservableCollection<Request>();
            LoadRequests();
            RequestsGrid.DataContext = this;
        }

        private void LoadRequests()
        {
            Requests.Clear();
            var requests = dbContext.Requests.ToList();
            foreach (var request in requests)
            {
                Requests.Add(request);
            }
        }

        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            var requestWindow = new RequestWindow(dbContext);
            if (requestWindow.ShowDialog() == true)
            {
                LoadRequests();
            }
        }

        private void EditRequest_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsGrid.SelectedItem is Request selectedRequest)
            {
                var requestWindow = new RequestWindow(dbContext, selectedRequest);
                if (requestWindow.ShowDialog() == true)
                {
                    LoadRequests();
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для редактирования");
            }
        }

        private void DeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsGrid.SelectedItem is Request selectedRequest)
            {
                dbContext.Requests.Remove(selectedRequest);
                dbContext.SaveChanges();
                LoadRequests();
            }
            else
            {
                MessageBox.Show("Выберите заявку для удаления");
            }
        }
    }
}