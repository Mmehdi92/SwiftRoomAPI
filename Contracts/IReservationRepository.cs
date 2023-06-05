using SwiftRoomAPI.Data;

namespace SwiftRoomAPI.Contracts
{
    public interface IReservationRepository: IGenericRepository<Reservation>
    {
        Task <List<Reservation>> GetReservationsFromUser (string userId);
        
    }
}
