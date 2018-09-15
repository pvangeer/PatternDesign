using System.ComponentModel;
using System.Runtime.CompilerServices;
using PatternDesign.Data.Annotations;

namespace PatternDesign.Data
{
    public class DesignProject : INotifyPropertyChanged
    {
        public DesignProject()
        {
            Design = new Design(12,12);
        }

        public Design Design { get; }

        public string FileLocation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
