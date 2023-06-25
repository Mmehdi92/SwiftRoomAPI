using SwiftRoomAPI.Data;

namespace SwiftRoomAPI.Contracts
{
    public interface IReservationRepository: IGenericRepository<Reservation>
    {
        Task <List<Reservation>> GetReservationsFromUser (string userId);
    
        bool IsTimeSlotAvailable(DateTime startTime, DateTime endTime);
        Task<Reservation> AddReservationUnique(Reservation reservation);

    }
}
