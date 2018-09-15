using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using PatternDesign.Data;
using PatternDesign.Data.Annotations;

namespace PatternDesign.Presentation.ViewModels
{
    public class PatternCellViewModel : INotifyPropertyChanged
    {
        public PatternCellViewModel(PatternCell patternCell)
        {
            Cell = patternCell;
            Cell.PropertyChanged += CellPropertyChanged;
        }

        private void CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PatternCell.Color))
            {
                OnPropertyChanged(nameof(Color));
            }
        }

        public int IndexLeft => Cell.ColumnIndex;

        public int IndexTop => Cell.RowIndex;

        public PatternCell Cell { get; }

        public SolidColorBrush Color
        {
            get => new SolidColorBrush(Cell.Color.Color);
            set => Cell.Color = new DesignColor(value.Color,-1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}