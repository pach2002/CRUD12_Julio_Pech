using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travels.DataAccess.Repositories
{
    // Design Pattern Repository
    public interface IRepository<TId, TEntity> where TEntity : class, new()
    {

        // Get all 
        IQueryable<TEntity> GetAll();

        // Get one
        Task<TEntity> GetAsync(TId id);

        // Add
        Task<TEntity> AddAsync(TEntity entity);

        // Update
        Task<TEntity> UpdateAsync(TEntity entity);

        // Delete
        Task DeleteAsync(TId id);

    }
