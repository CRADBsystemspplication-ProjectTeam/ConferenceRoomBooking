using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ConferenceRoomBooking.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceRoomBooking.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<BaseRepository<T>> _logger;

        public BaseRepository(DbContext context, ILogger<BaseRepository<T>> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // ✅ Add
        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Cannot add a null entity.");

            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Entity of type {EntityType} added successfully.", typeof(T).Name);
                return entity;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error occurred while adding {EntityType}.", typeof(T).Name);
                throw new InvalidOperationException($"Could not add {typeof(T).Name}. Database update failed.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error adding {EntityType}.", typeof(T).Name);
                throw;
            }
        }

        // ✅ Get by Id
        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    _logger.LogWarning("{EntityType} with ID {Id} not found.", typeof(T).Name, id);
                }
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving {EntityType} with ID {Id}.", typeof(T).Name, id);
                throw;
            }
        }

        // ✅ Get all
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all entities of type {EntityType}.", typeof(T).Name);
                throw new InvalidOperationException($"Failed to retrieve {typeof(T).Name} records.", ex);
            }
        }

        // ✅ Update
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Cannot update a null entity.");

            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("{EntityType} updated successfully.", typeof(T).Name);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Concurrency issue while updating {EntityType}.", typeof(T).Name);
                throw new InvalidOperationException($"Concurrency issue while updating {typeof(T).Name}.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating {EntityType}.", typeof(T).Name);
                throw;
            }
        }

        // ✅ Delete
        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity == null)
                {
                    _logger.LogWarning("{EntityType} with ID {Id} not found. Delete skipped.", typeof(T).Name, id);
                    return;
                }

                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("{EntityType} with ID {Id} deleted successfully.", typeof(T).Name, id);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error while deleting {EntityType} with ID {Id}.", typeof(T).Name, id);
                throw new InvalidOperationException($"Could not delete {typeof(T).Name} with ID {id}.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while deleting {EntityType} with ID {Id}.", typeof(T).Name, id);
                throw;
            }
        }
    }
}