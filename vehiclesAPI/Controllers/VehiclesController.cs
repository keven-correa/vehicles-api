using Microsoft.AspNetCore.Mvc;
using vehiclesAPI.Domain.Entities;
using vehiclesAPI.Domain.Interfaces;

namespace vehiclesAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _repository;

        public VehiclesController(IVehicleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllVehicles")]
        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return await _repository.GetAllVehiclesAsync();
        }

        [HttpGet("{id}", Name = "GetVehicleById")]
        public async Task<ActionResult<Vehicle>> GetVehicleById(int id)
        {
            var vehicle = await _repository.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound($"there is no vehicle with this {id}");
            return await _repository.GetVehicleByIdAsync(id);
        }

        [HttpPost(Name = "CreateVehicle")]
        public async Task<ActionResult<Vehicle>> CreateVehicle([FromBody] Vehicle vehicle)
        {
            if (vehicle == null) return BadRequest("The fields cannot be empty!");

            var newVehicle = await _repository.CreateVehicleAsync(vehicle);
            return CreatedAtAction(nameof(GetAllVehicles), new { newVehicle.Id }, newVehicle);
        }

        [HttpPut("{id}", Name = "UpdateVehicle")]
        public async Task<ActionResult> UpdateVehicle(int id, [FromBody] Vehicle vehicle)
        {
            if (id != vehicle.Id) return NotFound($"there is no vehicle with this {id}");
            await _repository.UpdateVehicleAsync(vehicle);
            return Ok("Updated!");
        }

        [HttpDelete("{id}", Name = "DeleteVehicle")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _repository.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound($"there is no vehicle with this {id}");
            await _repository.DeleteVehicleAsync(vehicle.Id);
            return Ok("Deleted!");
        }

        [HttpGet(Name ="SearchVehicle")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Search(string brand)
        {
            try
            {
                var result = await _repository.Search(brand);

                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
