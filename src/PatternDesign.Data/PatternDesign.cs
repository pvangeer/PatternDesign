using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PatternDesign.Data
{
    public class PatternDesign
    {
        public PatternDesign()
        {
            Cells = new ObservableCollection<PatternCell>();
        }

        public IEnumerable<PatternCell> Cells { get; }

        public ColorPalette ColorPalette { get; }
    }
}
