using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
            Cells = new ObservableCollection<PatternCellViewModel>();
            Project = project;
            Project.Design.PropertyChanged += DesignPropertyChanged;
            ((INotifyCollectionChanged) Project.Design.Cells).CollectionChanged += CellsCollectionChanged;
            foreach (var patternCell in Project.Design.Cells)
            {
                Cells.Add(new PatternCellViewModel(patternCell));
            }
        }

        private void DesignPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Design.NoColumns))
            {
                OnPropertyChanged(nameof(NoColumns));
            }
            if (e.PropertyName == nameof(Design.NoRows))
            {
                OnPropertyChanged(nameof(NoRows));
            }
        }

        private void CellsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var patternCell in e.NewItems.OfType<PatternCell>())
                {
                    Cells.Add(new PatternCellViewModel(patternCell));
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var patternCell in e.OldItems.OfType<PatternCell>())
                {
                    var cellToRemove = Cells.FirstOrDefault(c => c.Cell == patternCell);
                    if (cellToRemove != null)
                    {
                        Cells.Remove(cellToRemove);
                    }
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                Cells.Clear();
            }
        }

        public DesignProject Project { get; }

        public ObservableCollection<PatternCellViewModel> Cells { get; }

        public int NoColumns => Project.Design.NoColumns;

        public int NoRows => Project.Design.NoRows;

        public double Margin => 10.0;
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}