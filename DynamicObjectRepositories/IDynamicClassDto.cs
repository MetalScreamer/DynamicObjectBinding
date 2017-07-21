using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Repositories
{
    public interface IDynamicClassDto
    {
        string Name { get; set; }
        IEnumerable<IDynamicPropertyDefinitionDto> Properties { get; }
    }
}
