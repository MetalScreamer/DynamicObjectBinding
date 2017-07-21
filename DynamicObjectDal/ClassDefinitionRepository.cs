using DynamicObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Dal
{
    public class ClassDefinitionRepository : IDynamicClassRepository
    {
        private DomainRepository<ClassDefinition> repo = new DomainRepository<ClassDefinition>();

        public IDynamicClassDto Create()
        {
            return new ClassDefinition();
        }

        public IEnumerable<IDynamicClassDto> GetClasses()
        {
            return repo.GetAll();
        }

        public void Remove(IDynamicClassDto[] dynamicClasses)
        {
            repo.Remove(dynamicClasses.Cast<ClassDefinition>().ToArray());
        }

        public void Save(IDynamicClassDto[] dynamicClasses)
        {
            repo.Add(dynamicClasses.Cast<ClassDefinition>().Where(c => c.ClassDefinitionId == 0).ToArray());
            repo.Update(dynamicClasses.Cast<ClassDefinition>().Where(c => c.ClassDefinitionId > 0).ToArray());
        }
    }
}
