using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PatternDesign.Data
{
    public class ColorPalette
    {
        private ObservableCollection<DesignColor> colorList;

        public ColorPalette()
        {
            colorList = new ObservableCollection<DesignColor>();
        }

        public void AddColor(Color color)
        {
            if (colorList.Any(c => c.Color == color))
            {
                return;
            }

            var existingIndices = ColorList.Select(c => c.ColorIndex).Distinct().OrderBy(i => i).ToArray();
            var newIndex = 1;
            while (existingIndices.Contains(newIndex))
            {
                newIndex += 1;
            }

            colorList.Add(new DesignColor(color,newIndex));
        }

        public void RemoveColor(int index)
        {
            colorList.RemoveAt(index);
        }

        public void RemoveColor(Color color)
        {
            var colorToRemove = colorList.FirstOrDefault(c => c.Color == color);
            if (colorToRemove != null)
            {
                RemoveColor(colorToRemove);
            }
        }

        public void RemoveColor(DesignColor color)
        {
            colorList.Remove(color);
        }

        public IEnumerable<DesignColor> ColorList => colorList;
    }
}
