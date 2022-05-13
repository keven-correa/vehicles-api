using Microsoft.EntityFrameworkCore;
using vehiclesAPI.Domain.Entities;

namespace vehiclesAPI.Infraestructure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
