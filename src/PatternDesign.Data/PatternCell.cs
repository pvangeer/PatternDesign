using System.ComponentModel;
using System.Runtime.CompilerServices;
using PatternDesign.Data.Annotations;

namespace PatternDesign.Data
{
    public class PatternCell : INotifyPropertyChanged
    {
        private DesignColor color;

        public PatternCell(int rowIndex, int columnIndex, DesignColor color)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            Color = color;
        }

        public int RowIndex { get; }

        public int ColumnIndex { get; }

        public DesignColor Color
        {
            get => color;
            set
            {
                color = value;
                OnPropertyChanged(nameof(Color));
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
