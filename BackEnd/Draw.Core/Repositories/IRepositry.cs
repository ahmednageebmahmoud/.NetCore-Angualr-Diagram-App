using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Core.Repositories
{
    public interface IRepositry<T> where T:class
    {
        /// <summary>
        /// Insert New Item In DataBsae
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Find Item By Id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T FindById(object id);
 

    }
}
