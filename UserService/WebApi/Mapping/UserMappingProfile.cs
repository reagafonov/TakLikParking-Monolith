using AutoMapper;
using Domain.Entities;
using Services.Contracts;
using WebApi.Contracts.Dtos;
using WebApi.Models;

namespace WebApi.Mapping;

public class UserMappingProfile:Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserInfo,User>().ReverseMap();
        CreateMap<User, User>();
        CreateMap<UserDTO, UserResultModel>().ReverseMap();
        CreateMap<UserInfo, UserDTO>().ReverseMap();
    }
}