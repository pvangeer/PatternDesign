using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using PatternDesign.Data.Annotations;

namespace PatternDesign.Data
{
    public class DesignProject : INotifyPropertyChanged
    {
        public DesignProject()
        {
            Design = new Design(new ObservableCollection<PatternCell>
            {
                new PatternCell(0, 0, new DesignColor(Colors.Bisque, 0)),
                new PatternCell(0, 1, new DesignColor(Colors.DarkRed, 1)),
                new PatternCell(0, 2, new DesignColor(Colors.CornflowerBlue, 2)),
                new PatternCell(1, 0, new DesignColor(Colors.YellowGreen, 3)),
                new PatternCell(1, 1, new DesignColor(Colors.Pink, 4)),
                new PatternCell(1, 2, new DesignColor(Colors.MediumPurple, 5))
            });
        }

        public Design Design { get; set; }

        public string FileLocation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
