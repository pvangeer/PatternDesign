using PatternDesign.Data;
using PatternDesign.Presentation.ViewModels;

namespace PatternDesign.App.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Project = new DesignProject();
            RibbonViewModel = new RibbonViewModel(Project);
            GameViewModel = new GameViewModel(Project);
        }

        public DesignProject Project { get; }

        public RibbonViewModel RibbonViewModel { get; }

        public GameViewModel GameViewModel { get; }
    }
}