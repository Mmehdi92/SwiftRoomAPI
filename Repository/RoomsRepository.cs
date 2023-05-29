using Microsoft.EntityFrameworkCore;
using SwiftRoomAPI.Contracts;
using SwiftRoomAPI.Data;

namespace SwiftRoomAPI.Repository
{
    public class RoomsRepository : GenericRepository<Room>, IRoomsRepository
    {
        private readonly SwiftRoomDbContext _swiftRoomDbContext;

        public RoomsRepository(SwiftRoomDbContext swiftRoomDbContext) : base(swiftRoomDbContext)
        {
            this._swiftRoomDbContext = swiftRoomDbContext;
        }

        public async Task<Room> GetDetailsAsync(int id)
        {
            return await _swiftRoomDbContext.Rooms.Include(q => q.Appointments)
                .FirstOrDefaultAsync(q => q.Id == id);

        }
    }
}
