using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SwiftRoomAPI.Data.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            //builder.HasData(
            //    new Appointment
            //    {
            //        Id = 1,
            //        Title = "Afspraak Dokter met Piet",
            //        Description = "Bespreking van overname praktijk",
            //        Begin = new DateTime(2023, 06, 04, 19, 00, 00),
            //        End = new DateTime(2023, 06, 04, 22, 00, 00),
            //        ApiUserId = "957b09f8-1292-4739-bda6-97ae7b302284",
            //        RoomId = 1,
            //    },
            //      new Appointment
            //      {
            //          Id = 2,
            //          Title = "Afspraak Bank met Jan",
            //          Description = "Bespreking Aaandelen bla bla",
            //          Begin = new DateTime(2023, 06, 05, 12, 00, 00),
            //          End = new DateTime(2023, 06, 05, 14, 30, 00),
            //          RoomId = 2,
            //          ApiUserId = "957b09f8-1292-4739-bda6-97ae7b302284"
            //      }
            //    );
        }
    }
}
