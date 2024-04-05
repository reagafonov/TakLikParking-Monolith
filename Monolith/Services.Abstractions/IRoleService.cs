using Services.Contracts;

namespace Services.Abstractions;

public interface IRoleService
{
    Task<int> Create(RoleDto parkingDto, CancellationToken token);
    Task Delete(int id, CancellationToken token);
    Task Update(int id, RoleDto dto, CancellationToken token);
    Task<RoleDto> GetByID(int id);
    Task<ICollection<RoleDto>> GetPaged(int page, int pageSize, CancellationToken token);
}