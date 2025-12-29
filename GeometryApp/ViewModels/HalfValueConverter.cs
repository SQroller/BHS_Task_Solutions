using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace GeometryApp.ViewModels;

/// <summary>
/// Простой конвертер, возвращающий половину переданного значения double.
/// Используется для вычисления центра поворота прямоугольника.
/// </summary>
public sealed class HalfValueConverter : IValueConverter
{
    /// <summary>
    /// Реализация singleton для удобного использования в XAML.
    /// </summary>
    public static HalfValueConverter Instance { get; } = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double d)
        {
            return d / 2.0;
        }

        return 0.0;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // Обратное преобразование не используется.
        throw new NotSupportedException();
    }
}


