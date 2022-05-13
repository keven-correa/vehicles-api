using Microsoft.EntityFrameworkCore;
using vehiclesAPI.Domain.Entities;
using vehiclesAPI.Domain.Interfaces;
using vehiclesAPI.Infraestructure.DataAccess;

namespace vehiclesAPI.Infraestructure.Implementations
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;

        }

        public async Task DeleteVehicleAsync(int id)
        {
            var entity = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<IEnumerable<Vehicle>> Search(string brand)
        {
            IQueryable<Vehicle> query = _context.Vehicles;

            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(b => b.Brand == brand);
            }

            return await query.ToListAsync();
        }

        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
