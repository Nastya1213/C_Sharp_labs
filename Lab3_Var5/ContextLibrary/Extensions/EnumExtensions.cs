using System.ComponentModel;
using System.Reflection;

namespace ContextLibrary.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Получить значение атрибута "Description" при наличии, иначе стандартное строковое представление
        /// </summary>
        /// <param name="enumValue">Конкретное значение Enum-типа</param>
        /// <returns>Значение атрибута "Description" при наличии, иначе стандартное строковое представление</returns>
        public static string GetDescription(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            FieldInfo? field = type.GetField(enumValue.ToString());
            object[]? attributes = field?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes?.Length ?? 0) == 0
                ? enumValue.ToString()
                : ((DescriptionAttribute?)attributes?[0])?.Description ?? enumValue.ToString();
        }
    }
}
