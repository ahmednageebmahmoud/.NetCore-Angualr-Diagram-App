using Draw.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Draw.EF.Repositories
{
    public class Repositry<T> : IRepositry<T> where T : class
    {
        protected ApplicationContext _Context;
        protected readonly DbSet<T> _entity;

        public Repositry(ApplicationContext context)
        {
            this._Context = context;
            this._entity = context.Set<T>();

        }

        public T FindById(object id) => this._entity.Find(id);
        public T FindById_NT(object id)
        {
            var entity = this.FindById(id);
            this._Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }



        public void Add(T entity) => this._entity.Add(entity);

        public void Update(T entity) => this._entity.Update(entity);

        public void UpdateState(T entity)
        {
            this._entity.Attach(entity);
            this._Context.Entry(entity).State = EntityState.Modified;

        }


        public void Remove(T entity) => this._entity.Remove(entity);

        public void Remove(Expression<Func<T, bool>> identity)
        {
            var Entities = this._entity.Where(identity);
            this._entity.RemoveRange(Entities);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> identity)
        {
            return await this._entity.Where(identity).ToListAsync();



        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> identity, Expression<Func<T, object>> order)
        {
            return await this._entity.Where(identity).OrderByDescending(order).ToListAsync();



        }
    }
}
