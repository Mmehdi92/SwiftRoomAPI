using Microsoft.EntityFrameworkCore;
using SwiftRoomAPI.Contracts;
using SwiftRoomAPI.Data;
using SwiftRoomAPI.Models.Appointment;

namespace SwiftRoomAPI.Repository
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly SwiftRoomDbContext _swiftRoomDbContext;

        public AppointmentRepository(SwiftRoomDbContext swiftRoomDbContext) : base(swiftRoomDbContext)
        {

            this._swiftRoomDbContext = swiftRoomDbContext;
        }

        // task return user + appointments
        public async Task<List<Appointment>> GetAppointmentFromuser(string id)
        {
            return await _swiftRoomDbContext.Appointments.Include(q => q.ApiUser)
            .Where(q => q.ApiUserId == id)
            .ToListAsync();
        }

    


        //task return user + reservations
    }
}
