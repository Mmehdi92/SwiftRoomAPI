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
        public bool IsTimeSlotAvailable(DateTime startTime, DateTime endTime)
        {
            Console.WriteLine($"Checking availability for timeslot: {startTime} - {endTime}");

            // Check if there are any reservations in the specified time range
            bool isAvailable = !_swiftRoomDbContext.Reservation.Any(r =>
                r.StartTime < endTime && r.EndTime > startTime);

            Console.WriteLine($"Timeslot availability: {isAvailable}");

            return isAvailable;
        }

        public async Task<Reservation> AddReservationUnique(Reservation reservation)
        {
           // Check if the time slot is available
         bool isAvailable =  IsTimeSlotAvailable(reservation.StartTime, reservation.EndTime);

            if (!isAvailable)
            {
                // The time slot is already booked, handle the error or throw an exception
                throw new InvalidOperationException("The specified time slot is already booked.");
            }

            // Time slot is available, add the reservation to the database
            _swiftRoomDbContext.Reservation.Add(reservation);
            await _swiftRoomDbContext.SaveChangesAsync();

            return reservation;
        }

        public async Task<List<Reservation>> GetReservationsFromUser(string userId)
        {
            var reservations = await _swiftRoomDbContext.Reservation.Include(q => q.ApiUser)
                .Where(q => q.ApiUserId == userId).ToListAsync();
            return reservations;
        }

      

        
    }
}
