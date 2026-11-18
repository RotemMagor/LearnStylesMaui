using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace LearnStylesMaui.Converters
{
    /// <summary>
    /// ממיר דו-כיווני (Two-Way Converter) לטמפרטורה.
    /// ממחיש לתלמידים כיצד לממש הן את Convert והן את ConvertBack:
    /// - Convert: ממיר מעלות צלזיוס (Celsius ב-ViewModel) לפרנהייט (Fahrenheit ב-UI).
    /// - ConvertBack: ממיר מעלות פרנהייט (שמשתמש מקליד ב-UI) חזרה לצלזיוס ב-ViewModel.
    /// </summary>
    public class TemperatureTwoWayConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is double celsius)
            {
                double fahrenheit = (celsius * 9.0 / 5.0) + 32.0;
                return Math.Round(fahrenheit, 1);
            }

            return 0.0;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string str && double.TryParse(str, out double fahrenheit))
            {
                double celsius = (fahrenheit - 32.0) * 5.0 / 9.0;
                return Math.Round(celsius, 1);
            }
            else if (value is double fVal)
            {
                double celsius = (fVal - 32.0) * 5.0 / 9.0;
                return Math.Round(celsius, 1);
            }

            return 0.0;
        }
    }
}
