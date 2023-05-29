using Microsoft.EntityFrameworkCore;

namespace SwiftRoomAPI.Data
{
    public class SwiftRoomDbContext : DbContext
    {
        public SwiftRoomDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    Title = "Afspraak Dokter met Piet",
                    Description = "Bespreking van overname praktijk",
                    Begin = new DateTime(2023, 06, 04, 19, 00, 00),
                    End = new DateTime(2023, 06, 04, 22, 00, 00),
                    RoomId = 1,
                },
                  new Appointment
                  {
                      Id = 2,
                      Title = "Afspraak Bank met Jan",
                      Description = "Bespreking Aaandelen bla bla",
                      Begin = new DateTime(2023, 06, 05, 12, 00, 00),
                      End = new DateTime(2023, 06, 05, 14, 30, 00),
                      RoomId = 2,
                  }
                );


            modelBuilder.Entity<Room>().HasData(new Room
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
