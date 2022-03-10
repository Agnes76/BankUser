using BankApp.Models.dto;
using BankUser.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bankuser.Core.Interface
{
    public interface IAppUserService
    {
        Task<Response<AppUserResponseDto>> CreateUser(AppUserRequestDto newUser);
        Task<Response<AppUserResponseDto>> GetAUser(string id);
        Response<IEnumerable<AppUserResponseDto>> GetAllUsers();
        Task<Response<AppUserResponseDto>> UpdateUser(string id, AppUserUpdateDto updateUser);
        Task<Response<string>> DeleteUser(string id);
    }
}
