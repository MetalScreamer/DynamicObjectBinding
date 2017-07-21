using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Dal
{
    class DomainRepository<T> where T : class
    {
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            return ExecuteWithContext(
                context =>
                {
                    var dbSet = GetDbSet(context, navigationProperties);

                    return
                        dbSet
                            .AsNoTracking()
                            .ToArray();
                });
        }

        public IEnumerable<T> GetAllWhere(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return ExecuteWithContext(
                context =>
                {
                    var dbSet = GetDbSet(context, navigationProperties);

                    return
                        dbSet
                            .AsNoTracking()
                            .Where(where)
                            .ToArray();
                });
        }

        public T GetFirstWhere(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return ExecuteWithContext(
                context =>
                {
                    var dbSet = GetDbSet(context, navigationProperties);

                    return
                        dbSet
                            .AsNoTracking()
                            .Where(where)
                            .FirstOrDefault();
                });
        }

        public void Add(T[] items)
        {
            DoDbAction(items, EntityState.Added);
        }

        public void Update(T[] items)
        {
            DoDbAction(items, EntityState.Modified);
        }

        public void Remove(T[] items)
        {
            DoDbAction(items, EntityState.Deleted);
        }

        private void DoDbAction(T[] items, EntityState actionState)
        {
            ExecuteWithContext(
                context =>
                {
                    foreach (var item in items)
                    {
                        context.Entry(item).State = actionState;
                    }

                    context.SaveChanges();
                });
        }

        private static DbSet<T> GetDbSet(DbContext context, params Expression<Func<T, object>>[] navigationProperties)
        {
            var result = context.Set<T>();

            foreach (var navigationProperty in navigationProperties)
            {
                result.Include(navigationProperty);
            }

            return result;
        }

        private void ExecuteWithContext(Action<DynamicObjectDbContext> executeAction)
        {
            using (var context = GetDbContext())
            {
                executeAction(context);
            }
        }

        private TResult ExecuteWithContext<TResult>(Func<DynamicObjectDbContext, TResult> executeFunc)
        {
            using (var context = GetDbContext())
            {
                return executeFunc(context);
            }
        }

        private DynamicObjectDbContext GetDbContext()
        {
            return new DynamicObjectDbContext();
        }
    }
}
