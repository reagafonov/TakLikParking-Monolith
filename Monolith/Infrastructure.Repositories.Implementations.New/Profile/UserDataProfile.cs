using AutoMapper;
using Domain.Entities.New;
using Infrastructure.EntityFramework.Models;
using Repositories.Implementations.New.Models;

namespace Repositories.Implementations.New;

public class UserDataProfile:Profile
{
    public UserDataProfile()
    {
        CreateMap<UserDataEntity, EmailContactModel>()
            .ForMember(x=>x.Email, x=>x.MapFrom(y=>y.Email));

        CreateMap<UserDataEntity, SmsContactModel>()
            .ForMember(x => x.PhoneNumber, x => x.MapFrom(y => y.Phone));
        CreateMap<UserDataEntity, TelegramContactModel>()
            .ForMember(x => x.Name, x => x.MapFrom(y => y.TelegramName));

        CreateMap<UserDataEntity, UserDataDto>()
            .ForMember(x => x.Contacts, x => x.MapFrom(y => new IContact?[]
                {
                    string.IsNullOrWhiteSpace(y.Email) ? null : new EmailContactModel() { Email = y.Email },
                    string.IsNullOrWhiteSpace(y.Phone) ? null : new SmsContactModel() { PhoneNumber = y.Phone },
                    string.IsNullOrWhiteSpace(y.TelegramName) ? null : new TelegramContactModel() { Name = y.TelegramName }
                }
                .Where(x => x != null).ToArray()))
            .ReverseMap()
            .ForMember(x=>x.Email,x=>x.MapFrom(y=>
              GetContactData<IEmailContact,string>(y.Contacts,contact=>contact.Email)))
            .ForMember(x=>x.Phone,x=>x.MapFrom(y=>GetContactData<ISmsContact,string>(y.Contacts,contact=>contact.PhoneNumber)))
            .ForMember(x=>x.TelegramName,x=>x.MapFrom(y=>GetContactData<ITelegramContact,string>(y.Contacts,contact=>contact.Name)));
        CreateMap<UserDataEntity, IUserData<Guid>>().As<UserDataDto>();
    }

    private static TResult GetContactData<TSource, TResult>(IEnumerable<IContact> sources,
        Func<TSource, TResult> getter) 
        where TSource:class
        where TResult:class
    {
        var found = sources.Where(x => x is TSource).Select(x => x as TSource).FirstOrDefault();
        return found is null ? (TResult)null : getter(found);
    }

}