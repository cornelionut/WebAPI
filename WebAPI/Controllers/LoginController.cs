using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        // GET: api/Login
        [HttpGet("GetUsers")]
        public ActionResult<IEnumerable<Register>> GetRegister()
        {
            return _loginRepository.GetUsers().ToList();
        }

        //    // GET: api/Login/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<Register>> GetRegister(int id)
        //    {
        //        var register = await _context.Register.FindAsync(id);

        //        if (register == null)
        //        {
        //            return NotFound();
        //        }

        //        return register;
        //    }

        //    // PUT: api/Login/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //    // more details see https://aka.ms/RazorPagesCRUD.
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutRegister(int id, Register register)
        //    {
        //        if (id != register.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(register).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RegisterExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        // POST: api/Login
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Route("InsertUser")]
        [HttpPost]
        public async Task<ActionResult<object>> PostRegister(Register user)
        {
            try
            {
                if (user.UserId == 0)
                {
                    await _loginRepository.InsertUser(user);
                    //  return CreatedAtAction("GetRegister", new { id = user.UserId }, user);
                    return new Response { Status = "Success", Message = "User SuccessFully Saved." };
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return new Response { Status = "Error", Message = "Invalid Data." };
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<Response>> Login(Login login)
        {
            var userExistent = await _loginRepository.Login(login);

         //   var log = DB.EmployeeLogins.Where(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password)).FirstOrDefault();

            if (userExistent.Count() == 0)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
                return new Response { Status = "Success", Message = "Login Successfully" };
        }

        //    // DELETE: api/Login/5
        //    [HttpDelete("{id}")]
        //    public async Task<ActionResult<Register>> DeleteRegister(int id)
        //    {
        //        var register = await _context.Register.FindAsync(id);
        //        if (register == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Register.Remove(register);
        //        await _context.SaveChangesAsync();

        //        return register;
        //    }

        //    private bool RegisterExists(int id)
        //    {
        //        return _context.Register.Any(e => e.Id == id);
        //    }
        //}
    }
}
