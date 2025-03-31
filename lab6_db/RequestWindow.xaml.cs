using System;
using System.Windows;

namespace lab6_db
{
    public partial class RequestWindow : Window
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Request _request;

        public RequestWindow(ApplicationDbContext dbContext, Request request = null)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _request = request ?? new Request();
            DataContext = _request;

            if (_request.Id == 0) // Новая заявка
            {
                DateAddedPicker.SelectedDate = DateTime.Now;
                StatusComboBox.SelectedIndex = 0; // "Новая" по умолчанию
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_request.Id == 0) // Новая заявка
                {
                    _dbContext.Requests.Add(_request);
                }
                _dbContext.SaveChanges();
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}