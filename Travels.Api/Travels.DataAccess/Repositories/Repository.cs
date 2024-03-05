using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travels.DataAccess.Repositories
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : class, new()
    {
        // local database context
        private readonly TravelsDataContext _context;

        // protected context
        protected TravelsDataContext Context { get => _context; }

        // builder, receive GymManager context
        public Repository(TravelsDataContext context)
        {
            _context = context;
        }

        // add
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            // if entity comes null
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            // try : catch
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        // delete
        public virtual async Task DeleteAsync(TId id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            _context.Remove<TEntity>(entity);
            await _context.SaveChangesAsync();

        }

        // get all
        public virtual IQueryable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        // get one
        public virtual async Task<TEntity> GetAsync(TId id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            return entity;
        }

        // update 
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            // if entity received is not null
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            // try : catch
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}
