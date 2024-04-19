using AutoMapper;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions.New;

namespace Repositories.Implementations.New;

public class CarRepository(DatabaseContext context, IMapper mapper, IRepository<CarEntity, Guid> repository):
    ICarRepository<Guid>
{

    public async Task<ICar<Guid>?> GetAsync(Guid userId, CancellationToken token)
    {
        var car = await repository.GetAsync(userId, token);
        return mapper.Map<ICar<Guid>>(car);
    }

    public async Task AddAsync(ICar<Guid> entity, CancellationToken token)
    {
        var model = mapper.Map<CarEntity>(entity);
        await repository.AddAsync(model, token);
    }

    public async Task<ICar<Guid>?> GetAsync(ICarNumber carNumber, CancellationToken token)
    {
        var numberString = carNumber.Number;
        var car = await context.Cars.FirstOrDefaultAsync(x => x.Number == numberString, token);
        if (car == null)
            return null;
        var carModel = mapper.Map<ICar<Guid>>(car);
        return carModel;
    }
}