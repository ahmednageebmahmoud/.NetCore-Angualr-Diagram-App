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
        /// Update Sate , Here You Can Pass New Model And Wuill Attach To Context 
        /// </summary>
        /// <param name="entity"></param>
        void UpdateState(T entity);


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
        /// Find Item By Id As No Tracking
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T FindById_NT(object id);

        

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
