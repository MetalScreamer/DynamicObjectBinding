using DynamicObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Dal
{
    class ClassDefinition : IDynamicClassDto
    {
         public long ClassDefinitionId { get; private set; }

        public string Name { get; set; }
        public virtual List<PropertyDefinition> Properties { get; private set; } = new List<PropertyDefinition>();

        IEnumerable<IDynamicPropertyDefinitionDto> IDynamicClassDto.Properties
        {
            get
            {
                return Properties;
            }
        }
    }
}
