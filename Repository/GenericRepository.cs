using Microsoft.EntityFrameworkCore;
using SwiftRoomAPI.Contracts;
using SwiftRoomAPI.Data;

namespace SwiftRoomAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SwiftRoomDbContext _swiftRoomDbContext;

        public GenericRepository(SwiftRoomDbContext swiftRoomDbContext)
        {
            this._swiftRoomDbContext = swiftRoomDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _swiftRoomDbContext.AddAsync(entity);
            await _swiftRoomDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _swiftRoomDbContext.Set<T>().Remove(entity);
            await _swiftRoomDbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _swiftRoomDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }
            return await _swiftRoomDbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _swiftRoomDbContext.Attach(entity);
            _swiftRoomDbContext.Update(entity);
            await _swiftRoomDbContext.SaveChangesAsync();
        }

    }
}
