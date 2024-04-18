using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Implementations.New.Models;
using Services.Abstractions;
using Services.Abstractions.New;
using WebApi.Contracts.Dtos;
using WebApi.Contracts.Requests;
using UserDataDto = Repositories.Implementations.New.Models.UserDataDto;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController(IUserService<Guid, Guid> userService, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task AddRegistrationAsync(UserDataRequest userData, CancellationToken token)
    {
        var dto = mapper.Map<UserDataDto>(userData);
        var telegramContact = mapper.Map<TelegramContactDto>(userData.TelegramContact);
        dto.Contacts.Add(telegramContact);
        await userService.CreateAsync(dto, token);
    }

    [HttpPatch]
    public async Task SetNotificationOptionsAsync(Guid userId, Guid carKey, MessageType type, NotifyOptions options,
        CancellationToken token)
    {
        await userService.SetNotificationOptionsAsync(userId, carKey, type, options, token);
    }
}