using AutoMapper;
using BankApp.Models;
using BankApp.Models.dto;
using System;

namespace BankUser.Utilities
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<AppUser, AppUserResponseDto>()
                .ForMember(x => x.Age, y => y.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year));
        }
    }
}
