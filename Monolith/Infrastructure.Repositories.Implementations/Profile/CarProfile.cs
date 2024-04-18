using AutoMapper;
using Domain.Entities;
using Domain.Entities.New;
using Infrastructure.EntityFramework.Models;
using Repositories.Implementations.New.Models;

namespace Repositories.Implementations.New;

public class CarProfile:Profile
{
    public CarProfile()
    {
        CreateMap<string, CarNumberModel>()
            .ForMember(x => x.Number, x => x.MapFrom(x => x));
        CreateMap<string,ICarNumber>().As<CarNumberModel>();

        CreateMap<CarEntity, CarModel>()
            .ForMember(x => x.MessageOptions,
                x => x.MapFrom(
                    y => y.MessageOptions.GroupBy(z => z.MessageType)
                        .ToDictionary(z => z.Key, z => z.FirstOrDefault())
                        .Where(z => z.Value != null)
                        .SelectMany(x => Enum.GetValues<MessageType>().Where(z => x.Key.HasFlag(z))
                            .Select(y => new
                            {
                                x.Key,
                                x.Value
                            }))
                        .ToDictionary(x => x.Key, x => x.Value)))
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
        CreateMap<CarEntity,ICar<Guid>>().As<CarModel>();
    }
}