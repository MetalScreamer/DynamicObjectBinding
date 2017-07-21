using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Services
{
    public interface IDynamicObjectServices
    {
        IClassDefinitionModel CreateClass();
        IEnumerable<IClassDefinitionModel> GetClasses();
        void RemoveClass(IClassDefinitionModel classDefinition);

        IValidationResponse ValidateClass(IClassDefinitionModel classDefinition);
        IPropertyDefinitionModel CreateProperty(IClassDefinitionModel classDefinition);
        IEnumerable<IPropertyDefinitionModel> GetProperties(IClassDefinitionModel classDefinition);
        IValidationResponse ValidateProperty(IPropertyDefinitionModel propertyDefinition);

    }
}
