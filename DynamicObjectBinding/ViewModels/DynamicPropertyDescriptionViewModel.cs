using DynamicObjects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.ViewModels
{
    public class DynamicPropertyDescriptionViewModel : ViewModelBase
    {
        private string name;
        private PropertyType type;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public PropertyType Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }
    }
}
