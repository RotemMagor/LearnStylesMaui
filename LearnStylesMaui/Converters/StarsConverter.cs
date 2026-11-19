using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnStylesMaui.Converters
{
    internal class StarsConverter : IValueConverter

    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int rating && rating<=5)
            {
                string filledStars = new string('★',rating);
                string emptyStars = new string('☆', 5 - rating);

                return filledStars + emptyStars;
            }

            else {
                return "☆☆☆☆☆"; }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
