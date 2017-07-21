using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Repositories
{
    public interface IDynamicClassRepository
    {
        IEnumerable<IDynamicClassDto> GetClasses();
        IDynamicClassDto Create();
        void Save(IDynamicClassDto[] dynamicClasses);
        void Remove(IDynamicClassDto[] dynamicClasses);
    }
}
