
using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _usercontext;

        public UserRepository(AppDbContext usercontext)
        {
            _usercontext = usercontext;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var query = _usercontext.Users.AsQueryable();

            query = query.Where(x => x.Email == email && x.Password == password);

            return query.FirstOrDefault();
        }
    }
}
