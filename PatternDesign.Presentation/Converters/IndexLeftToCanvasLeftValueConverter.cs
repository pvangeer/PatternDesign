using System;
using System.Globalization;
using System.Windows.Data;

namespace PatternDesign.Presentation.Converters
{
    public class IndexLeftToCanvasLeftValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 5 || !(values[0] is int index) || !(values[1] is int noColumns) || !(values[2] is int noRows) ||
                !(values[3] is double width) || !(values[4] is double height))
            {
                return values;
            }


            var maximumCellWidth = width / noColumns;
            var maximumCellHeight = height / noRows;
            double cellSize = Math.Min(maximumCellWidth, maximumCellHeight);

            var halfMargin = 0.0;
            if (maximumCellWidth > cellSize)
            {
                halfMargin = (width - cellSize * noColumns)/2.0;
            }
            return index * cellSize + halfMargin;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}