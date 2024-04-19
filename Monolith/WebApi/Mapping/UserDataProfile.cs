using AutoMapper;
using Domain.Entities;
using WebApi.Contracts.Dtos;
using WebApi.Contracts.Requests;
using UserDataDto = Repositories.Implementations.New.Models.UserDataDto;

namespace WebApi.Mapping;

public class UserDataProfile:Profile
{
    public UserDataProfile()
    {
        CreateMap<CarNumberRequest, CarNumberDto>();
        CreateMap<CarNumberRequest, CarNumberDto>();
        CreateMap<CarNumberRequest, ICarNumber>().As<CarNumberDto>();
        CreateMap<CarRequest, CarDto>()
            .ForMember(x=>x.MessageOptions, x=>x.MapFrom(y=>
                new Dictionary<MessageType, MessageOptionsDto>()
                {
                    { MessageType.Parking ,new MessageOptionsDto()
                        {
                            NotifyOptions = y.Parked
                        }
                    },
                    {
                        MessageType.Incident , new MessageOptionsDto()
                        {
                            NotifyOptions = y.Incident
                        }
                    },
                    {
                        MessageType.Leave, new MessageOptionsDto()
                        {
                            NotifyOptions = y.Leave
                        }
                    }
                }));
        CreateMap<CarRequest,ICar<Guid>>().As<CarDto>();
        CreateMap<MessageOptionsRequest, MessageOptionsDto>();
        CreateMap<TelegramContactRequest, TelegramContactDto>();
        CreateMap<UserDataRequest, UserDataDto>()
            .ForMember(x => x.Contacts, x => x.Ignore())
            .AfterMap((_,x,_)=>x.Contacts = new List<IContact>());
    }
}