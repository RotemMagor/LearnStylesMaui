using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace LearnStylesMaui.Converters
{
    /// <summary>
    /// ממיר הבודק האם מחרוזת היא ריקה או null, ומחזיר בוליאן.
    /// אם parameter שווה ל-"Inverse", התוצאה תתהפך (true אם המחרוזת מכילה ערך).
    /// שימושי מאוד להצגת הודעות שגיאה או אינדיקציות ולידציה.
    /// </summary>
    public class NullOrEmptyToBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string? text = value as string;
            bool isEmpty = string.IsNullOrWhiteSpace(text);

            bool inverse = parameter is string paramStr && paramStr.Equals("Inverse", StringComparison.OrdinalIgnoreCase);

            return inverse ? !isEmpty : isEmpty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
