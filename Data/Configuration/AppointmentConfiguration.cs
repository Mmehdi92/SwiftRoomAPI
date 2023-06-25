using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SwiftRoomAPI.Data.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            //    builder.HasData(
            //        new Appointment
            //        {
            //            Id = 1,
            //            Title = "Afspraak Dokter met Piet",
            //            Description = "Bespreking van overname praktijk",
            //            Begin = new DateTime(2023, 06, 04, 19, 00, 00),
            //            End = new DateTime(2023, 06, 04, 22, 00, 00),
            //            ApiUserId = "4226f6d9-3613-436b-a7fd-89d5694a37b9",
            //            RoomId = 1,
            //        },
            //          new Appointment
            //          {
            //              Id = 2,
            //              Title = "Afspraak Bank met Jan",
            //              Description = "Bespreking Aaandelen bla bla",
            //              Begin = new DateTime(2023, 06, 05, 12, 00, 00),
            //              End = new DateTime(2023, 06, 05, 14, 30, 00),
            //              RoomId = 2,
            //              ApiUserId = "4226f6d9-3613-436b-a7fd-89d5694a37b9"
            //          }
            //        );
            //}
        }
    }
}
