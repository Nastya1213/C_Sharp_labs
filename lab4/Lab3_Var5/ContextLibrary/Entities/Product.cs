using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextLibrary.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Weight { get; set; }
        public int Volume { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return Name;
        }

        // Минимальный порог для заказа
        public int MinStockLevel { get; set; } = 5;

        // Проверка низкого запаса
        public bool IsLowStock() => Quantity <= MinStockLevel;

        // Автоматический заказ у поставщиков
        public void Reorder()
        {
            if (IsLowStock())
            {
                Console.WriteLine($"Заказ на поставку {Name} отправлен!");
                Quantity += 10; // Допустим, пополняем на 10 штук
            }
        }
    }
}
