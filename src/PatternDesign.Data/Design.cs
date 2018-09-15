using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using PatternDesign.Data.Annotations;

namespace PatternDesign.Data
{
    public class Design : INotifyPropertyChanged
    {
        private readonly ObservableCollection<PatternCell> cells;

        public Design(int noColumns, int noRows)
        {
            cells = new ObservableCollection<PatternCell>();
            Cells = new ReadOnlyObservableCollection<PatternCell>(cells);
            NoColumns = 0;
            NoRows = 0;
            ColorPalette = new ColorPalette();
            ChangeSize(noColumns, noRows);
        }

        public int NoRows { get; private set; }

        public int NoColumns { get; private set; }

        public ReadOnlyObservableCollection<PatternCell> Cells { get; }

        public ColorPalette ColorPalette { get; }

        public void ChangeSize(int noColumns, int noRows)
        {
            var oldNoColumns = NoColumns;
            if (noColumns != NoColumns)
            {
                NoColumns = noColumns;
                OnPropertyChanged(nameof(NoColumns));
            }

            var oldNoRows = NoRows;
            if (noRows != NoRows)
            {
                NoRows = noRows;
                OnPropertyChanged(nameof(NoRows));
            }

            var cellsToRemove = cells.Where(c => c.ColumnIndex > NoColumns - 1 || c.RowIndex > NoRows - 1).ToList();
            foreach (var patternCell in cellsToRemove)
            {
                cells.Remove(patternCell);
            }

            for (int iColumn = 0; iColumn < NoColumns; iColumn++)
            {
                for (int iRow = 0; iRow < NoRows; iRow++)
                {
                    if (iColumn > oldNoColumns - 1 || iRow > oldNoRows - 1)
                    {
                        cells.Add(new PatternCell(iRow, iColumn, ColorPalette.Colors.First()));
                    }
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
