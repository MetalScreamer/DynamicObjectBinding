using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Domain.Models
{
    class ClassDefinition
    {
        public string Name { get; set; }
        public List<PropertyDefinition> Properties { get; set; } = new List<PropertyDefinition>();
    }
}
