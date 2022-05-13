using vehiclesAPI.Domain.Entities;

namespace vehiclesAPI.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> Search(string brand);
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int id);
    }
}
