using DynamicObjects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Services
{
    public interface IPropertyDefinitionModel
    {
        string Name { get; set; }
        PropertyType DataType { get; set; }
    }
}
