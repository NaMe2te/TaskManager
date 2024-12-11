using Application.Dtos;
using Application.Dtos.Task;
using Application.Services.BaseServices;
using Dal.Entities;

namespace Application.Services.UserServices;

public interface IUserService : IBaseCrudService<User, UserDto>
{
    Task<IEnumerable<TaskDto>> GetTasksByUser(long userId);
}