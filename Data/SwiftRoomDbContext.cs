using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwiftRoomAPI.Data.Configuration;
using SwiftRoomAPI.Data;

namespace SwiftRoomAPI.Data
{
    public class SwiftRoomDbContext : IdentityDbContext<ApiUser>
    {
        public SwiftRoomDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());

        }

        public DbSet<SwiftRoomAPI.Data.Reservation> Reservation { get; set; }
    }
}
