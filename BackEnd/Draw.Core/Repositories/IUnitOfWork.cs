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
        /// Save Change And Return Number Of Row Effected
        /// </summary>
        /// <returns></returns>
        int Complate();
    }
}
