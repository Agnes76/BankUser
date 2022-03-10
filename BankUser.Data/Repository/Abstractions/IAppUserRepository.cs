using BankApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankUser.Data.Repository.Abstractions
{
    public interface IAppUserRepository
    {
        Task CreateUser(AppUser user);
        Task<AppUser> GetUser(string email);
        Task<AppUser> GetAUser(string id);
        IEnumerable<AppUser> GetAllUsers();
        void UpdateUser(AppUser user);
        void DeleteUser(AppUser user);
        Task SaveChanges();
    }
}
