using BankApp.Models;
using BankUser.Data.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUser.Data.Repository.Implementations
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly ApplicationDbContext _context;
        public AppUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateUser(AppUser user)
        {
            await _context.AddAsync(user);
        }

        public void DeleteUser(AppUser user)
        {
            _context.Users.Remove(user);
        }

        public IEnumerable<AppUser> GetAllUsers()
        {
            return _context.Users;
        }

        public async Task<AppUser> GetAUser(string id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<AppUser> GetUser(string email)
        {
            return await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateUser(AppUser user)
        {
            _context.Users.Update(user);
        }
    }
}
