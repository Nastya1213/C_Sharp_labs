using System.ComponentModel;

namespace ContextLibrary.Enums
{
    /// <summary>
    /// Статус заявки
    /// </summary>
    public enum RequestStatus
    {
        /// <summary>
        /// Новая заявка
        /// </summary>
        [Description("Новая")]
        New,
        /// <summary>
        /// Заявка в процессе выполнения
        /// </summary>
        [Description("В процессе")]
        InProcess,
        /// <summary>
        /// Заявка завершена
        /// </summary>
        [Description("Завершена")]
        Completed
    }
}
