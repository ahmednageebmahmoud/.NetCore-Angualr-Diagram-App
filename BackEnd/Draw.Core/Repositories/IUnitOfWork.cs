using Draw.Core.Model;
using System;


namespace Draw.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Users Repositry
        /// </summary>
        IRepositry<ApplicationUser> Users { get; }

        /// <summary>
        /// Diagram Repositry
        /// </summary>
        IRepositry<Diagram> Diagrams { get; }

        /// <summary>
        /// Save Change And Return Number Of Row Effected
        /// </summary>
        /// <returns></returns>
        Task<bool> Complate();
    }
}
