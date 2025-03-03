using System;
using System.Collections.Generic;
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


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private SalesReport _salesReport;

        // Конструктор, принимающий объект SalesReport
        public ReportWindow(SalesReport salesReport)
        {
            InitializeComponent();
            _salesReport = salesReport;

            // Обновляем данные на форме
            UpdateStatistics();
        }

        // Метод для обновления данных на форме
        private void UpdateStatistics()
        {
            // Отображаем общую выручку
            TotalRevenueLabel.Content = "Total Revenue: " + _salesReport.GetTotalRevenue().ToString("C");

            // Отображаем прибыль
            ProfitLabel.Content = "Profit: " + _salesReport.GetProfit().ToString("C");
        }
    }
}
