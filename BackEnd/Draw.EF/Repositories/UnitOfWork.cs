using Draw.Core.Model;
using Draw.Core.Repositories;

namespace Draw.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IRepositry<ApplicationUser> Users { get; private set; }


        public UnitOfWork(ApplicationContext context)
        {
            this._context = context;
            this.Users = new Repositry<ApplicationUser>(this._context);
        }


        public int Complate() => this._context.SaveChanges();
        public void Dispose() => this._context.Dispose();


    }
}
