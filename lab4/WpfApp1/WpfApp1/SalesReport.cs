using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextLibrary.Entities;

namespace WpfApp1
{
    public class SalesReport
    {
        public List<Order> Orders { get; set; }
        public SalesReport(List<Order> orders)
        {
            Orders = orders;
        }
        public float GetTotalRevenue()
        {
            return Orders.Sum(Order => Order.CalculateDeliveryCost());
        }

        public float GetProfit()
        {
            float totalCost = Orders.Sum(order => order.Weight * 20);
            return GetTotalRevenue() - totalCost;
        }
    }
}
