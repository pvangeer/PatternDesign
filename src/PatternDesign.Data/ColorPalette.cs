using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;

namespace PatternDesign.Data
{
    public class ColorPalette
    {
        private readonly ObservableCollection<DesignColor> colorList;

        public ColorPalette()
        {
            colorList = new ObservableCollection<DesignColor>();
            Colors = new ReadOnlyObservableCollection<DesignColor>(colorList);
            colorList.Add(new DesignColor(System.Windows.Media.Colors.AntiqueWhite,1));
        }

        public void AddColor(Color color)
        {
            if (colorList.Any(c => c.Color == color))
            {
                return;
            }

            var existingIndices = Colors.Select(c => c.ColorIndex).Distinct().OrderBy(i => i).ToArray();
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

        public ReadOnlyObservableCollection<DesignColor> Colors { get; }
    }
}
