using AutoMapper;
using BankApp.Models;
using BankApp.Models.dto;
using Bankuser.Core.Interface;
using BankUser.Data;
using BankUser.Data.Repository.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bankuser.Core.Implementaions
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public AppUserService(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }
        public async Task<Response<AppUserResponseDto>> CreateUser(AppUserRequestDto newUser)
        {
            var user = await _appUserRepository.GetUser(newUser.Email);
            if (DateTime.Now.Year - newUser.DateOfBirth.Year < 18)
            {
                return  Response<AppUserResponseDto>.Fail("User must be 18 years and above", StatusCodes.Status403Forbidden);
            }
            if (user != null)
            {
                return Response<AppUserResponseDto>.Fail("User with email already exists", StatusCodes.Status403Forbidden);
            }
            user = new AppUser() 
            { 
                DateOfBirth = newUser.DateOfBirth, 
                Email = newUser.Email, 
                FirstName = newUser.FirstName, 
                LastName = newUser.LastName 
            };

            await _appUserRepository.CreateUser(user);
            await _appUserRepository.SaveChanges();
            var res = _mapper.Map<AppUserResponseDto>(user);
            return Response<AppUserResponseDto>.Success("Success", res, StatusCodes.Status201Created);
        }

        public async Task<Response<string>> DeleteUser(string id)
        {
            var user = await _appUserRepository.GetUser(id);
            if(user == null)
            {
                return Response<string>.Fail("User not found");
            }
            _appUserRepository.DeleteUser(user);
            await _appUserRepository.SaveChanges();
            return Response<string>.Success("User Deleted", "User Deleted");
        }

        public Response<IEnumerable<AppUserResponseDto>> GetAllUsers()
        {
            var users = _appUserRepository.GetAllUsers();
            var res = _mapper.Map<IEnumerable<AppUserResponseDto>>(users);
            return Response<IEnumerable<AppUserResponseDto>>.Success("Success", res);
        }

        public async Task<Response<AppUserResponseDto>> GetAUser(string id)
        {
            var user = await _appUserRepository.GetAUser(id);
            if (user == null)
            {
                return Response<AppUserResponseDto>.Fail("User not Found");
            }
            var res = _mapper.Map<AppUserResponseDto>(user);
            return Response<AppUserResponseDto>.Success("User fetched", res);
        }

        public async Task<Response<AppUserResponseDto>> UpdateUser(string id, AppUserUpdateDto updateUser)
        {
            var user =await _appUserRepository.GetUser(id);
            if (user.DateOfBirth.Year < 18)
            {
                return Response<AppUserResponseDto>.Fail("User must be 18 years and above");
            }
            if (user == null)
            {
                return Response<AppUserResponseDto>.Fail("User not Found");
            }
            user.DateOfBirth = string.IsNullOrWhiteSpace(updateUser.DateOfBirth.ToString()) ? user.DateOfBirth : updateUser.DateOfBirth;
            user.Email = string.IsNullOrWhiteSpace(updateUser.Email) ? user.Email : updateUser.Email;
            user.FirstName = string.IsNullOrWhiteSpace(updateUser.FirstName) ? user.FirstName : updateUser.FirstName;
            user.LastName = string.IsNullOrWhiteSpace(updateUser.LastName) ? user.LastName : updateUser.LastName;
            _appUserRepository.UpdateUser(user);
            await _appUserRepository.SaveChanges();
            var res = _mapper.Map<AppUserResponseDto>(user);
            return Response<AppUserResponseDto>.Success("User Updated", res);
        }

        
    }
}
