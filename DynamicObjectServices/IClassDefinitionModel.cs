using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Services
{
    public interface IClassDefinitionModel
    {
        string Name { get; set; }
        IEnumerable<IPropertyDefinitionModel> Properties { get; }
    }
}
