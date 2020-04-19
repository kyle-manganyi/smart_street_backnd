using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smart_street_backend.Helpers;
using smart_street_backend.Model;
using smart_street_backend.Models;

namespace smart_street_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public usersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> Getusers()
        {
            return await _context.users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<user>> Getuser(int id)
        {
            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuser(int id, user user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/users
        [HttpPost("login")]
        public async Task<ActionResult<user>> Login(loginUser user)
        {
            user customer;
            try
            {
                customer = await _context.users.FirstOrDefaultAsync(x => (x.username == user.username || x.email == user.username) && Encryption.VerifyPassword(user.password, x.password));
                if (customer == null)
                {
                    return Ok(new { message = "Invalid Password or Username" });
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Failed" });
            }
            string usertoken = new Authetication().GenerateJsonToken(customer);
            customer.password = null;
            return Ok(new { user = customer, token = usertoken });
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<user>> Deleteuser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool userExists(int id)
        {
            return _context.users.Any(e => e.Id == id);
        }
    }
}
