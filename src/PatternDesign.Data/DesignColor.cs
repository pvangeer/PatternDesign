using System.Windows.Media;

namespace PatternDesign.Data
{
    public class DesignColor
    {
        public DesignColor(Color color, int colorIndex)
        {
            Color = color;
            ColorIndex = colorIndex;
        }

        public Color Color { get; } 

        public int ColorIndex { get; }
    }
}
