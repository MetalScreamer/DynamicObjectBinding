using DynamicObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Dal
{
    class PropertyDefinitionRepository : IDynamicPropertyDefinitionRepository
    {
        private DomainRepository<PropertyDefinition> repo = new DomainRepository<PropertyDefinition>();

        public IDynamicPropertyDefinitionDto Create(IDynamicClassDto cls)
        {
            var result = new PropertyDefinition();
            var classDefinition = (ClassDefinition)cls;

            classDefinition.Properties.Add(result);

            result.Class = classDefinition;

            return result;
        }

        public IEnumerable<IDynamicPropertyDefinitionDto> GetProperties(IDynamicClassDto cls)
        {
            var classDefinition = (ClassDefinition)cls;
            var properties = repo.GetAllWhere(p => p.Class.ClassDefinitionId == classDefinition.ClassDefinitionId);
            classDefinition.Properties.Clear();
            classDefinition.Properties.AddRange(properties);

            return classDefinition.Properties;
        }

        public void Remove(IDynamicPropertyDefinitionDto[] propertyDefinitions, IDynamicClassDto cls)
        {
            var classDefinition = (ClassDefinition)cls;
            var propertiesToRemove = propertyDefinitions.Cast<PropertyDefinition>();
            foreach (var property in propertiesToRemove)
            {
                classDefinition.Properties.Remove(property);
            }

            repo.Remove(propertiesToRemove.ToArray());
        }

        public void Save(IDynamicPropertyDefinitionDto[] propertyDefinitions)
        {
            repo.Add(propertyDefinitions.Cast<PropertyDefinition>().Where(p => p.PropertyDefinitionId == 0).ToArray());
            repo.Update(propertyDefinitions.Cast<PropertyDefinition>().Where(p => p.PropertyDefinitionId > 0).ToArray());
        }
    }
}
