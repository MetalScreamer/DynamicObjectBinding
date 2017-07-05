using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjectBinding.ViewModels
{
    class DynamicObjectViewModel : ViewModelBase, ICustomTypeDescriptor
    {
        private class _PropertyDescriptor : PropertyDescriptor
        {
            public override Type ComponentType
            {
                get
                {
                    return typeof(DynamicObjectViewModel);
                }
            }

            public override bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            public override Type PropertyType
            {
                get
                {
                    return typeof(int);
                }
            }

            public _PropertyDescriptor(string name) : base(name, null) { }

            public override bool CanResetValue(object component)
            {
                return false;
            }

            public override object GetValue(object component)
            {
                var dyn = (DynamicObjectViewModel)component;
                return dyn.properties[Name];
            }

            public override void ResetValue(object component)
            {
                throw new NotImplementedException();
            }

            public override void SetValue(object component, object value)
            {
                var dyn = (DynamicObjectViewModel)component;
                dyn.properties[Name] = (int)value;
                dyn.NotifyPropertyChanged(Name);
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }

        private Dictionary<string, int> properties = new Dictionary<string, int>();

        public void Add(string name) => properties.Add(name, 0);


        public string ClassName { get; set; }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this);
        }

        public string GetClassName()
        {
            return ClassName;
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this);
        }

        public TypeConverter GetConverter()
        {
            return null;
        }

        public EventDescriptor GetDefaultEvent()
        {
            return null;
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        public object GetEditor(Type editorBaseType)
        {
            return null;
        }

        public EventDescriptorCollection GetEvents()
        {
            return null;
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return null;
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return new PropertyDescriptorCollection(
                properties.Select(kvp =>  new _PropertyDescriptor(kvp.Key)).ToArray());
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
}
