using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using PatternDesign.Data;
using PatternDesign.Data.Annotations;

namespace PatternDesign.Presentation.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public GameViewModel(DesignProject project)
        {
            Project = project;
            Project.Design.PropertyChanged += DesignPropertyChanged;
        }

        private void DesignPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Design.Cells))
            {
                OnPropertyChanged(nameof(Cells));
            }
        }

        public DesignProject Project { get; }

        public ObservableCollection<PatternCellViewModel> Cells => new ObservableCollection<PatternCellViewModel>(
            Project.Design.Cells.Select(c => new PatternCellViewModel(c)));

        public int NoColumns => Project.Design.Cells.Any() ? Project.Design.Cells.Select(c => c.ColumnIndex).Max()+1 : 1;

        public int NoRows => Project.Design.Cells.Any() ? Project.Design.Cells.Select(c => c.RowIndex).Max()+1 : 1;

        public double Margin => 10.0;
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}