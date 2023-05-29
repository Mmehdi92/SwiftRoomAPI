using SwiftRoomAPI.Contracts;
using SwiftRoomAPI.Data;

namespace SwiftRoomAPI.Repository
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(SwiftRoomDbContext swiftRoomDbContext) : base(swiftRoomDbContext)
        {
        }
    }
}
