using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Data
{
    public class PatternCell
    {
        public PatternCell(int rowIndex, int columnIndex, DesignColor color)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            Color = color;
        }

        public int RowIndex { get; }

        public int ColumnIndex { get; }

        public DesignColor Color { get; }
    }
}
