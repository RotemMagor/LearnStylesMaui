using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace LearnStylesMaui.Converters
{
    /// <summary>
    /// ממיר ציון מספרי (0-100) לטקסט הערכה מילולי או לצבע תואם באמצעות ConverterParameter.
    /// אם parameter שווה ל-"Color", הממיר מחזיר צבע מתאים (ירוק, כחול, כתום, אדום).
    /// אחרת, הממיר מחזיר הערכה מילולית ("מצוין", "טוב מאוד", "כמעט טוב", "מספיק", "טעון שיפור").
    /// </summary>
    public class ScoreToGradeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            double score = 0;

            if (value is int intVal)
            {
                score = intVal;
            }
            else if (value is double dblVal)
            {
                score = dblVal;
            }
            else if (value is string strVal && double.TryParse(strVal, out double parsed))
            {
                score = parsed;
            }

            bool returnColor = parameter is string paramStr && paramStr.Equals("Color", StringComparison.OrdinalIgnoreCase);

            if (returnColor)
            {
                if (score >= 90) return Color.FromArgb("#2E7D32"); // Green
                if (score >= 75) return Color.FromArgb("#1976D2"); // Blue
                if (score >= 55) return Color.FromArgb("#F57C00"); // Orange
                return Color.FromArgb("#D32F2F"); // Red
            }

            // החזרת טקסט מילולי
            if (score >= 90) return "מצוין (A)";
            if (score >= 80) return "טוב מאוד (B)";
            if (score >= 70) return "טוב (C)";
            if (score >= 55) return "מספיק (D)";
            return "טעון שיפור (F)";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException("ההמרה מציון מילולי למספרי אינה נתמכת.");
        }
    }
}
