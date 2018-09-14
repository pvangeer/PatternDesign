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
