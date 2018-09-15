using System;
using System.Globalization;
using System.Windows.Data;

namespace PatternDesign.Presentation.Converters
{
    public class GridToDimensionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 4 || !(values[0] is int noColumns) || !(values[1] is int noRows) ||
                !(values[2] is double width) || !(values[3] is double height))
            {
                return values;
            }

            return Math.Min(width / noColumns, height / noRows);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}