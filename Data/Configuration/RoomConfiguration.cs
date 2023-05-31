using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SwiftRoomAPI.Data.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(new Room
            {
                Id = 1,
                Name = "Conference Room A",
                ShortName = "R A"
            },
            new Room
            {
                Id = 2,
                Name = "Conference Room B",
                ShortName = " R B "
            }
            );
        }
    }
}
