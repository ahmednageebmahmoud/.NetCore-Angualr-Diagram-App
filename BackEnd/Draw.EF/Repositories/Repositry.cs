using Draw.Core.Repositories;

namespace Draw.EF.Repositories
{
    public class Repositry<T> : IRepositry<T> where T : class
    {
        protected ApplicationContext _Context;
        public Repositry(ApplicationContext context)
        {
            this._Context = context;
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T FindById(object id) =>_Context.Set<T>() .Find(id);
    }
}
