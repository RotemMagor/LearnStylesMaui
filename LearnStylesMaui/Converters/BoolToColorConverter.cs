using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace LearnStylesMaui.Converters
{
    /// <summary>
    /// ממיר ערך בוליאני לצבע (Bool To Color Converter).
    /// מאפשר לקבוע ב-XAML איזה צבע להחזיר עבור true ואיזה צבע עבור false.
    /// דוגמה קלאסית: ירוק עבור תלמיד פעיל/נוכח, ואדום עבור תלמיד לא פעיל/נעדר.
    /// </summary>
    public class BoolToColorConverter : IValueConverter
    {
        public Color TrueColor { get; set; } = Colors.ForestGreen;
        public Color FalseColor { get; set; } = Colors.Crimson;

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool boolVal)
            {
                return boolVal ? TrueColor : FalseColor;
            }

            return FalseColor;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // אין צורך בהמרה לאחור ברוב תרחישי הצבעים, אך אם נדרש נבדוק התאמה לצבע האמת
            if (value is Color colorVal)
            {
                return colorVal == TrueColor;
            }

            return false;
        }
    }
}
