using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ConferenceRoomBookingDbContext _context;
        protected readonly ILogger<BaseRepository<T>> _logger;

        public BaseRepository(ConferenceRoomBookingDbContext context, ILogger<BaseRepository<T>>? logger = null)
        {
            _context = context;
            _logger = logger ?? Microsoft.Extensions.Logging.Abstractions.NullLogger<BaseRepository<T>>.Instance;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}