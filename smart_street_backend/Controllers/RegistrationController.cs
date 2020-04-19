using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smart_street_backend.Helpers;
using smart_street_backend.Model;

namespace smart_street_backend.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly DatabaseContext context;
        public RegistrationController(DatabaseContext context)
        {
            this.context = context;
        }
        // POST: api/Register
        [HttpPost("registration")]
        public async Task<ActionResult<user>> Post([FromBody] user newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var customerCheck = context.users.FirstOrDefault(x => x.username == newUser.username);
                if (customerCheck == null)
                {
                    newUser.password = Encryption.CreatePasswordHash(newUser.password);
                    context.users.Add(newUser);
                    customer newCustomer = new customer();
                    newCustomer.UserId = newUser.Id;
                    newCustomer.user = newUser;
                    context.customers.Add(newCustomer);
                    await context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = "user already Exist" });
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            Authetication userAuth = new Authetication();
            newUser.password = null;
            var tokenString = userAuth.GenerateJsonToken(newUser);
            return Ok(new { user = newUser, token = tokenString });
        }
    }
}