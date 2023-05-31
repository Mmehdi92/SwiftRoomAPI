using SwiftRoomAPI.Data;
using SwiftRoomAPI.Models.Appointment;

namespace SwiftRoomAPI.Contracts
{
    public interface IAppointmentRepository: IGenericRepository<Appointment>
    {
        Task<List<Appointment>> GetAppointmentFromuser(string id);
    }
}
