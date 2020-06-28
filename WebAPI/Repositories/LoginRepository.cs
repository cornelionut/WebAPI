using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        protected readonly LeasingDbContext _context;

        public LoginRepository(LeasingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Register> GetUsers()
        {
            return _context.Users.ToList();
        }

        public async Task<object> InsertUser(Register user)
        {
            _context.Set<Register>().Add(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Register>> Login(Login login)
        {
            var user = await _context.Users.Where(x => x.Email == login.Email && x.Password == login.Password).ToListAsync();
            return user;
        }

   }
}