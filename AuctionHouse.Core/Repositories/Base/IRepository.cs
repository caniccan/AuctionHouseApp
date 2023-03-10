﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse.Core.Repositories.Base
{
    /// <summary>
    /// IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class,new()
    {
        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeString"></param>
        /// <param name="disableTracking"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate,Func<IQueryable<T>,IOrderedQueryable<T>> orderBy, string includeString, bool disableTracking=true);

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <param name="disableTracking"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, List<Expression<Func<T,object>>> includes, bool disableTracking = true);

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

    }
}
