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
                        Name = "Молоко",
                        Weight = 10,
                        Volume = 15,
                        Quantity = 10,
                        Status = 1,
                        MinStockLevel = 5
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Хлеб",
                        Weight = 5,
                        Volume = 8,
                        Quantity = 15,
                        Status = 1,
                        MinStockLevel = 5
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Вода",
                        Weight = 12,
                        Volume = 20,
                        Quantity = 5,
                        Status = 1,
                        MinStockLevel = 5
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Яблоки",
                        Weight = 8,
                        Volume = 10,
                        Quantity = 30,
                        Status = 2,
                        MinStockLevel = 5
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Конфеты",
                        Weight = 6,
                        Volume = 12,
                        Quantity = 8,
                        Status = 1,
                        MinStockLevel = 5
                    }
                });
            }
            // Добавление тестовых заказов (если их нет)
            if (!orders.Any())
            {
                orders.AddRange(new List<Order>
        {
            new Order
            {
                Id = 1,
                DateAdd = DateTime.Now,
                TypeProduct = DeliveryType.standart,
                Weight = 10,
                Volume = 15,
                Distance = 100,
                Quantity = 2,
                FullName = "Иванов Иван Иванович",
                PhoneNumber = "+7 (123) 456-78-90",
                Status = RequestStatus.New,
                Product = products.First(p => p.Id == 1) // Связь с продуктом
            },
            new Order
            {
                Id = 2,
                DateAdd = DateTime.Now.AddDays(-1),
                TypeProduct = DeliveryType.expess,
                Weight = 5,
                Volume = 8,
                Distance = 50,
                Quantity = 1,
                FullName = "Петров Петр Петрович",
                PhoneNumber = "+7 (987) 654-32-10",
                Status = RequestStatus. InProcess,
                Product = products.First(p => p.Id == 2) // Связь с продуктом
            },
            new Order
            {
                Id = 3,
                DateAdd = DateTime.Now.AddDays(-2),
                TypeProduct = DeliveryType.standart,
                Weight = 12,
                Volume = 20,
                Distance = 200,
                Quantity = 3,
                FullName = "Сидорова Анна Владимировна",
                PhoneNumber = "+7 (555) 123-45-67",
                Status = RequestStatus.Completed,
                Product = products.First(p => p.Id == 3) // Связь с продуктом
            },
            new Order
            {
                Id = 4,
                DateAdd = DateTime.Now.AddDays(-3),
                TypeProduct = DeliveryType.standart,
                Weight = 8,
                Volume = 10,
                Distance = 150,
                Quantity = 5,
                FullName = "Кузнецов Дмитрий Сергеевич",
                PhoneNumber = "+7 (111) 222-33-44",
                Status = RequestStatus.New,
                Product = products.First(p => p.Id == 4) // Связь с продуктом
            },
            new Order
            {
                Id = 5,
                DateAdd = DateTime.Now.AddDays(-4),
                TypeProduct = DeliveryType.standart,
                Weight = 6,
                Volume = 12,
                Distance = 80,
                Quantity = 4,
                FullName = "Морозова Екатерина Андреевна",
                PhoneNumber = "+7 (999) 888-77-66",
                Status = RequestStatus. InProcess,
                Product = products.First(p => p.Id == 5) // Связь с продуктом
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
