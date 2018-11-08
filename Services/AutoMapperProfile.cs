using AutoMapper;
using moneygoes.Models;
using moneygoes.Models.DTOs;
using moneygoes.Models.ViewModels.Account;
using moneygoes.Models.ViewModels.Payments;

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

            CreateMap<PaymentGroup, PaymentGroupDto>();
            CreateMap<PaymentGroup, PaymentGroupVM>();
            CreateMap<PaymentGroupVM, PaymentGroup>();
            CreateMap<PaymentGroupVM, PaymentGroupDto>();            

            CreateMap<PaymentItem, PaymentItemDto>();
            CreateMap<PaymentItem, PaymentItemVM>();
            CreateMap<PaymentItemVM, PaymentItem>();
            CreateMap<PaymentItemVM, PaymentItemDto>();
        }
    }
}