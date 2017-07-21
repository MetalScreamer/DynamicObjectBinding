using DynamicObjects.Repositories;
using DynamicObjects.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Dal
{
    class PropertyDefinition : IDynamicPropertyDefinitionDto
    {
        public long PropertyDefinitionId { get; set; }

        public string Name { get; set; }
        public PropertyType DataType { get; set; }

        [ForeignKey("Class")]
        private long ClassId { get; set; }
        public ClassDefinition Class { get; set; }
    }
}
