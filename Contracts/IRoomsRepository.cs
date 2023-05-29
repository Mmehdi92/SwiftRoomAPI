using SwiftRoomAPI.Data;

namespace SwiftRoomAPI.Contracts
{
    public interface IRoomsRepository : IGenericRepository<Room> 
    {
        Task<Room> GetDetailsAsync(int id);
    }
}
