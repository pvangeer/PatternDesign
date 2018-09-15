using System.Linq;
using System.Windows.Input;
using PatternDesign.Data;

namespace PatternDesign.Presentation.ViewModels
{
    public class RibbonViewModel
    {
        public RibbonViewModel() : this(new DesignProject()){ }

        public RibbonViewModel(DesignProject project)
        {
            Project = project;
        }

        public DesignProject Project { get; }

        public ICommand FileNewCommand
        {
            get { throw new System.NotImplementedException(); }
        }

        public ICommand SaveProjectCommand
        {
            get { throw new System.NotImplementedException(); }
        }

        public ICommand SaveProjectAsCommand
        {
            get { throw new System.NotImplementedException(); }
        }

        public ICommand OpenProjectCommand
        {
            get { throw new System.NotImplementedException(); }
        }

        public int NoColumns
        {
            get => Project.Design.NoColumns;
            set => Project.Design.ChangeSize(value,Project.Design.NoRows);
        }

        public int NoRows
        {
            get => Project.Design.NoRows;
            set => Project.Design.ChangeSize(Project.Design.NoColumns, value);
        }
    }
}