using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace LearnStylesMaui.Converters
{
    /// <summary>
    /// ממיר בוליאני הפוך (Inverse Boolean Converter).
    /// מקבל ערך true ומחזיר false ולהפך.
    /// נפוץ מאוד כאשר רוצים להציג פקד כאשר תנאי מסוים אינו מתקיים (למשל: הצגת הודעה שאין נתונים כש-HasItems=false).
    /// </summary>
    public class InverseBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool boolVal)
            {
                return !boolVal;
            }

            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool boolVal)
            {
                return !boolVal;
            }

            return false;
        }
    }
}
