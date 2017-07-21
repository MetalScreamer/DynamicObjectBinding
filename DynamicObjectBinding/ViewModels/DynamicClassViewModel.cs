using DynamicObjects.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.ViewModels
{
    public class DynamicClassViewModel : ViewModelBase
    {
        private string name;
        private DynamicPropertyDescriptionViewModel selectedProperty;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public DynamicPropertyDescriptionViewModel SelectedProperty
        {
            get { return selectedProperty; }
            set
            {
                SetProperty(ref selectedProperty, value);
                RemoveProperty.RaiseCanExecuteChanged();
            }
        }

        public Command AddProperty { get; }
        public Command RemoveProperty { get; }

        public ObservableCollection<DynamicPropertyDescriptionViewModel> Properties { get; } = new ObservableCollection<DynamicPropertyDescriptionViewModel>();

        public static IEnumerable<PropertyType> DataTypes { get; } = Enum.GetValues(typeof(PropertyType)).Cast<PropertyType>();

        public DynamicClassViewModel()
        {
            AddProperty = new Command(_ => DoAddProperty());
            RemoveProperty = new Command(_ => DoRemoveProperty(), _ => CanRemoveProperty());
        }

        private bool CanRemoveProperty()
        {
            return SelectedProperty != null;
        }

        private void DoRemoveProperty()
        {
            if (SelectedProperty != null)
            {
                var selectedIdx = Properties.IndexOf(SelectedProperty);
                Properties.Remove(SelectedProperty);
                var newSelectedProperty = selectedIdx < Properties.Count ? Properties[selectedIdx] : null;
                SelectedProperty = newSelectedProperty;
            }
        }

        private void DoAddProperty()
        {
            var newProperty = new DynamicPropertyDescriptionViewModel()
            {
                Name = GetNewPropertyName(),
                Type = PropertyType.String
            };
            Properties.Add(newProperty);
            SelectedProperty = newProperty;
        }

        private string GetNewPropertyName()
        {
            const string BASE_NAME = "Prop";
            var counter = 1;
            while (Properties.Any(p => p.Name == $"{BASE_NAME}{++counter}")) ;

            return $"{BASE_NAME}{counter}";
        }
    }
}
