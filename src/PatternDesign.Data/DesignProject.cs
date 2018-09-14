using System.ComponentModel;
using System.Runtime.CompilerServices;
using PatternDesign.Data.Annotations;

namespace PatternDesign.Data
{
    public class DesignProject : INotifyPropertyChanged
    {
        public PatternDesign Design { get; set; }

        public string FileLocation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
