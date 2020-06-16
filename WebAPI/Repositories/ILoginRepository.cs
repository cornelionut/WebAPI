using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface ILoginRepository
    {
        public IEnumerable<Register> GetUsers();

        public Task<object> InsertUser(Register user);

        public Task<IEnumerable<Register>> Login(Login login);

    }
}