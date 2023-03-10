using Inventory.Info;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationsController : Controller
    {
        private readonly InventoriesDbContext dbContext;

        public RegistrationsController(InventoriesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetRegistrations()
        {
            return Ok(await dbContext.Registrations.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegistration([FromRoute] Guid id)
        {
            var registration = await dbContext.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();               
            }

            return Ok(registration);
        }

        [HttpGet]
        [Route("registrations/{username}")]
        public async Task<IActionResult> GetRegistrationByUsername(string username)
        {
            var registration = await dbContext.Registrations.FirstOrDefaultAsync(r => r.UserName == username);
            if (registration == null)
            {
                return NotFound();
            }

            return Ok(registration);
        }


        [HttpGet]
        public async Task<IActionResult> AddRegistration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRegistration(AddRegistrationRequest addRegistrationRequest)
        {
            var registration = new Registration()
            {
                Id = Guid.NewGuid(),
                UserName = addRegistrationRequest.UserName,
                Password = addRegistrationRequest.Password,
                UserFirstName = addRegistrationRequest.UserFirstName,
                UserLastName = addRegistrationRequest.UserLastName,
                Email = addRegistrationRequest.Email,
                Phone = addRegistrationRequest.Phone,
                Address = addRegistrationRequest.Address
            };

            await dbContext.Registrations.AddAsync(registration);
            await dbContext.SaveChangesAsync();
            return Ok(registration);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegistration([FromRoute] Guid id, UpdateRegistrationRequest updateRegistrationRequest)
        {
           var registration= await dbContext.Registrations.FindAsync(id);
            if(registration !=  null)
            {
                registration.UserName = updateRegistrationRequest.UserName;
                registration.Password = updateRegistrationRequest.Password;
                registration.UserFirstName = updateRegistrationRequest.UserFirstName;
                registration.UserLastName = updateRegistrationRequest.UserLastName;
                registration.Email = updateRegistrationRequest.Email;
                registration.Phone = updateRegistrationRequest.Phone;
                registration.Address = updateRegistrationRequest.Address;

                await dbContext.SaveChangesAsync();

                return Ok(registration);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegistration([FromRoute] Guid id)
        {
            var registration = await dbContext.Registrations.FindAsync(id);

            if(registration != null)
            {
                dbContext.Remove(registration);
                await dbContext.SaveChangesAsync();
                return Ok(registration);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("registrations")]
        public async Task<IActionResult> DeleteAllRegistrations()
        {
            dbContext.Registrations.RemoveRange(dbContext.Registrations);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
