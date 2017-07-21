using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Repositories
{
    public interface IDynamicPropertyDefinitionRepository
    {
        IEnumerable<IDynamicPropertyDefinitionDto> GetProperties(IDynamicClassDto cls);
        IDynamicPropertyDefinitionDto Create(IDynamicClassDto cls);
        void Save(IDynamicPropertyDefinitionDto[] propertyDefinitions);
        void Remove(IDynamicPropertyDefinitionDto[] propertyDefinitions, IDynamicClassDto cls);
    }
}
