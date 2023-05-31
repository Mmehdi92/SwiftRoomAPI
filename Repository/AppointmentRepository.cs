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
      //task return user + reservations
    }
}
