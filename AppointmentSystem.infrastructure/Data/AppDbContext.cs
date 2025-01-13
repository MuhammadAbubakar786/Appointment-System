using AppointmentSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> users { get; set; }
    }
}
