using Domain.Entities;
using Infrastructure.EntityFramework.Models;
using Repositories.Implementations.New.Models;

namespace Repositories.Implementations.New.Profile;

public class CarProfile:AutoMapper.Profile
{
    public CarProfile()
    {
        CreateMap<string, CarNumberModel>()
            .ForMember(x => x.Number, x => x.MapFrom(x => x));
        CreateMap<string,ICarNumber>().As<CarNumberModel>();
        
        CreateMap<ICar<Guid>, CarEntity>()
            .ForMember(x=>x.MessageOptions, x=>x.MapFrom(y=>y.MessageOptions.Select(x=>new MessageOptionsEntity()
                {
                    MessageType = x.Key,
                    NotifyOptions = x.Value.NotifyOptions
                }).ToList()))
            .ForMember(x=>x.Number, x=>x.MapFrom(y=>y.Number.Number));
        
        CreateMap<IMessageOptions, MessageOptionsEntity>();
        CreateMap<CarEntity, CarModel>()
            .ForMember(x => x.MessageOptions,
                x => x.MapFrom(
                    y => y.MessageOptions.GroupBy(z => z.MessageType)
                        .ToDictionary(z => z.Key, z => z.FirstOrDefault())
                       ))
            .ReverseMap()
            .ForMember(x=>x.MessageOptions,x=>x.MapFrom(y=>y.MessageOptions
                .Where(x=> x.Value!=null && x.Value.NotifyOptions!=null)
                .GroupBy(x=>x.Value.NotifyOptions)
                .Select(z=>new MessageOptionsEntity()
                {
                    Id = Guid.NewGuid(),
                    MessageType  = z.Select(x=>x.Key).Aggregate((a,b)=>a|b),
                    NotifyOptions = z.Key
                })));
        CreateMap<MessageOptionsEntity, MessageOptionsModel>();
        CreateMap<MessageOptionsEntity,IMessageOptions>().As<MessageOptionsModel>();
        CreateMap<CarEntity,ICar<Guid>>().As<CarModel>();
    }
}