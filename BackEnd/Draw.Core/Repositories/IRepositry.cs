using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        void Add(T entity);

        /// <summary>
        /// Update Item In DataBsae
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(T entity);

        /// <summary>
        /// Delete Item From DataBsae By Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Remove(T entity);

        /// <summary>
        /// Delete Item From DataBsae By Filter
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Remove(Expression<Func<T, bool>> identity);

        /// <summary>
        /// Find Item By Id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T FindById(object id);

        /// <summary>
        /// Get All Items Matched
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
   Task<    IEnumerable<T>>  GetAll(Expression<Func<T, bool>> identity);


        /// <summary>
        /// Get All Items Matched And Order
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> identity, Expression<Func<T, object>> order);

    }
}
