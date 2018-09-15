using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PatternDesign.Data.Annotations;

namespace PatternDesign.Data
{
    public class Design : INotifyPropertyChanged
    {
        public Design(ObservableCollection<PatternCell> cells)
        {
            Cells = cells;
            ColorPalette = new ColorPalette();
        }

        public ObservableCollection<PatternCell> Cells { get; }

        public ColorPalette ColorPalette { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
