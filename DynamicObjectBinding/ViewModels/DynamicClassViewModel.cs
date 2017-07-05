using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjectBinding.ViewModels
{
    public class DynamicClassViewModel : ViewModelBase
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public ObservableCollection<DynamicPropertyDescriptionViewModel> Properties { get; } = new ObservableCollection<DynamicPropertyDescriptionViewModel>();
    }
}
