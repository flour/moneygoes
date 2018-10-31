using AutoMapper;
using moneygoes.Models;
using moneygoes.Models.DTOs;
using moneygoes.Models.ViewModels.Account;

namespace moneygoes.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserDto, AppUser>();
            CreateMap<RegisterViewModel, AppUser>();
            CreateMap<RegisterViewModel, AppUserDto>();            
        }
    }
}