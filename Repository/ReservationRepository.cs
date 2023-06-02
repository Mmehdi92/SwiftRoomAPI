using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SwiftRoomAPI.Contracts;
using SwiftRoomAPI.Data;
using SwiftRoomAPI.Models.Reservation;

namespace SwiftRoomAPI.Repository
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly SwiftRoomDbContext _swiftRoomDbContext;

        public ReservationRepository(SwiftRoomDbContext swiftRoomDbContext) : base(swiftRoomDbContext)
        {
            this._swiftRoomDbContext = swiftRoomDbContext;
        }

        public async Task<List<Reservation>> GetReservationsFromUser(string userId)
        {
            var reservations = await _swiftRoomDbContext.Reservation.Include(q => q.ApiUser)
                .Where(q => q.ApiUserId == userId).ToListAsync();
            return reservations;
        }

      

        
    }
}
