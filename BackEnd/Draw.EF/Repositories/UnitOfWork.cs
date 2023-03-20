using Draw.Core.Model;
using Draw.Core.Repositories;

namespace Draw.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IRepositry<ApplicationUser> Users { get; private set; }
        public IRepositry<Diagram> Diagrams { get; private set; }


        public UnitOfWork(ApplicationContext context)
        {
            this._context = context;
            this.Users = new Repositry<ApplicationUser>(this._context);
            this.Diagrams = new Repositry<Diagram>(this._context);
        }


        public async Task<bool> Complate() => this._context.SaveChangesAsync().Result > 0;
        public void Dispose() => this._context.Dispose();


    }
}
