using System.Collections.Generic;
using ContextLibrary.Entities;
using ContextLibrary.Enums;

namespace ContextLibrary
{
    public class ApplicationContext : IDisposable
    {
        private bool _isDisposed = false;
        private static readonly List<Order> orders = [];
        private static readonly List<Product> products = [];
       
        public List<Order> Orders { get => orders; }
        public List<Product> Products { get => products; }

        // Конструктор, который инициализирует начальные данные
        public ApplicationContext()
        {
            // Добавление тестовых продуктов
            if (!products.Any())
            {
                products.AddRange(new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Продукт 1",
                        Weight = 10,
                        Volume = 15,
                        Quantity = 10,
                        Status = 1,
                        MinStockLevel = 5
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Продукт 2",
                        Weight = 5,
                        Volume = 8,
                        Quantity = 15,
                        Status = 1,
                        MinStockLevel = 5
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Продукт 3",
                        Weight = 12,
                        Volume = 20,
                        Quantity = 5,
                        Status = 1,
                        MinStockLevel = 5
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Продукт 4",
                        Weight = 8,
                        Volume = 10,
                        Quantity = 30,
                        Status = 2,
                        MinStockLevel = 5
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Продукт 5",
                        Weight = 6,
                        Volume = 12,
                        Quantity = 8,
                        Status = 1,
                        MinStockLevel = 5
                    }
                });
            }
        }



        protected virtual void Dispose(bool disposing)
        {
            // check if already disposed 
            if (!_isDisposed)
            {
                // set the bool value to true 
                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }
    }
}
