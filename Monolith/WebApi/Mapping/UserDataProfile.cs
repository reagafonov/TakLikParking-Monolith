using AutoMapper;
using Domain.Entities.New;
using WebApi.Contracts.Dtos;
using UserDataDto = Repositories.Implementations.New.Models.UserDataDto;

namespace WebApi.Mapping;

public class UserDataProfile:Profile
{
    public UserDataProfile()
    {
        CreateMap<CarNumberRequest, CarNumberDto>();
        CreateMap<CarRequest, CarDto>();
        CreateMap<MessageOptionsRequest, MessageOptionsDto>();
        CreateMap<TelegramContactRequest, TelegramContactDto>();
        CreateMap<UserDataRequest, UserDataDto>()
            .ForMember(x => x.Contacts, x => x.Ignore())
            .AfterMap((_,x,_)=>x.Contacts = new List<IContact>());
    }
}