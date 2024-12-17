using Application.Dtos;
using Application.Dtos.Task;
using Application.Services.BaseServices;
using Dal.Entities;

namespace Application.Services.UserServices;

public interface IUserService : IBaseCrudService<User, UserDto>
{
    Task<IEnumerable<TaskDto>> GetTasksByUser(long userId);
    Task<(long Id, string Name)> GetRoleByUser(long userId);
    Task<IEnumerable<UserDto>> GetUsersWithRoles(IEnumerable<User> users);
    Task<UserDto> GetUserWithRole(User user);
}