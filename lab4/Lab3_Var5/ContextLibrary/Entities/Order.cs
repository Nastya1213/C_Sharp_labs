using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextLibrary.Enums;

namespace ContextLibrary.Entities
{
    public class Order
    {
        /// <summary>
        /// Номер заявки
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Тип товара
        /// </summary>
        public DeliveryType TypeProduct { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public float Weight { get; set; }
        /// <summary>
        /// Объём
        /// </summary>
        public float Volume { get; set; }
        /// <summary>
        /// Расстояние
        /// </summary>
        public float Distance { get; set; }
        /// <summary>
        /// Количество товара
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// ФИО заказчика
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Номер телефона заказчика
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Статус заявки
        /// </summary>
        public RequestStatus Status { get; set; }

        // Связь с продуктом (выбранный продукт для заказа)
        public Product Product { get; set; }

        // Метод для расчета стоимости доставки
        public float CalculateDeliveryCost()
        {
            float basePrice = 100; // Базовая цена
            float weightCost = Weight * 5; // Стоимость за кг
            float volumeCost = Volume * 3; // Стоимость за объем
            float distanceCost = Distance * 2; // Стоимость за расстояние

            return basePrice + weightCost + volumeCost + distanceCost;
        }
    }
}
