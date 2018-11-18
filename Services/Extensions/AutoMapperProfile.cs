using AutoMapper;
using moneygoes.Models;
using moneygoes.Models.DTOs;
using moneygoes.Models.ViewModels;

namespace Name
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserDto, AppUser>();

            CreateMap<RegistrationVM, AppUser>();
            CreateMap<RegistrationVM, AppUserDto>();
            
            this.InitMappers();

        }
        private void InitMappers()
        {
            Map<PurchasingGroup, PurchasingGroupDto, PurchasingGroupVM>();
            Map<Purchase, PurchaseDto, PurchaseVM>();
            Map<PurchaseObject, PurchaseObjectDto, PurchaseObjectVM>();
            Map<Comment, CommentDto, CommentVM>();
        }

        private void Map<E, D, V>()
            where E : BaseEntity
            where D : BaseDto
            where V : IViewModel
        {
            CreateMap<E, D>();
            CreateMap<D, E>();

            CreateMap<E, V>();
            CreateMap<V, E>();
        }
    }
}