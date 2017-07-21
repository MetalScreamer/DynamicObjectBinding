using DynamicObjects.Repositories;
using DynamicObjects.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Dal
{
    class DynamicObjectDbContext : DbContext  //, IDynamicClassRepository, IDynamicPropertyDescriptionRepository
    {
        public DbSet<ClassDefinition> ClassDefinitions { get; set; }        
    }
}
