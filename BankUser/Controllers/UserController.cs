using BankApp.Models;
using BankApp.Models.dto;
using Bankuser.Core.Interface;
using BankUser.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAppUserService _userService;
        public UserController(IAppUserService userService)
        {
            _userService = userService;
        }

        //POST: api/users
        [HttpPost]
        public async Task<ActionResult<AppUser>> CreateUser(AppUserRequestDto newUser)
        {
            var response = await _userService.CreateUser(newUser);
            return StatusCode(response.StatusCode, response);
        }


        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var response = _userService.GetAllUsers();
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetAUser(string id)
        {
            var users = await _userService.GetAUser(id);
            return StatusCode(users.StatusCode, users);
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id) 
        {
            var response = await _userService.DeleteUser(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(string id, AppUserUpdateDto updateUser)
        {
            var result = await _userService.UpdateUser(id, updateUser);
            return StatusCode(result.StatusCode,result);
        }


    }
}
