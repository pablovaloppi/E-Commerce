using Entities.Model;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ECommerceDbContext ECommerceDbContext { get; set; }

        protected RepositoryBase( ECommerceDbContext eCommerceDbContext ) {
            ECommerceDbContext = eCommerceDbContext;
        }

        public void Create( T entity ) {
            ECommerceDbContext.Set<T>().Add( entity );
        }

        public void Delete( T entity ) {
            // Hard remove
            // TODO: Soft Remove
            ECommerceDbContext.Set<T>().Remove(entity );
        }
        public void Update( T entity ) {
            ECommerceDbContext.Set<T>().Update( entity );
        }

        public IQueryable<T> FindByCondition( System.Linq.Expressions.Expression<Func<T, bool>> expression ) {
            return ECommerceDbContext.Set<T>().Where( expression ).AsNoTracking();
        }

        public IQueryable<T> Get() {
            return ECommerceDbContext.Set<T>().AsNoTracking();
        }       
    }
}
