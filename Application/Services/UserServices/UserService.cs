using System.Linq.Expressions;
using Application.Dtos;
using Application.Dtos.Task;
using AutoMapper;
using Dal.Entities;
using Dal.Extentions;
using Dal.Models;
using Dal.Repositories.BaseRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task = Dal.Entities.Task;

namespace Application.Services.UserServices;

public class UserService : IUserService
{
    private readonly IBaseRepository<Task, long> _taskRepository;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;

    public UserService(IBaseRepository<Task, long> taskRepository, IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<UserDto> Add(UserDto dto)
    { 
        User? user = _mapper.Map<UserDto, User>(dto);
        await _userManager.CreateAsync(user);
        return dto;
    }

    public async Task<UserDto> Update(UserDto dto)
    {
        User? user = _mapper.Map<UserDto, User>(dto);
        await _userManager.UpdateAsync(user);
        return dto;
    }

    public async Task<UserDto> Remove(UserDto dto)
    {
        User? user = _mapper.Map<UserDto, User>(dto);
        await _userManager.DeleteAsync(user);
        return dto;
    }

    public async Task<IEnumerable<UserDto>> GetAll(Expression<Func<User, bool>>? predicate = null, PaginationParams? paginationParams = null)
    {
        var query = _userManager.Users;
        
        if (predicate is not null)
        {
            query = query.Where(predicate);
        }
        
        var users = paginationParams is not null ? 
            await query.ToPaginationListAsync(paginationParams.PageSize, paginationParams.PageNumber) : await query.ToListAsync();

        var usersWithRoles = new List<UserDto>();

        foreach (var user in users)
        {
            var role = await GetRoleByUser(user);
            var userDto = _mapper.Map<User, UserDto>(user, options =>
            {
                options.Items["Role"] = role.Name;
                options.Items["RoleId"] = role.Id;
            });
            usersWithRoles.Add(userDto);
        }

        return usersWithRoles;
    }
    
    public async Task<IEnumerable<TaskDto>> GetTasksByUser(long userId)
    {
        var tasksByUser = await _taskRepository.GetAllAsync(x => x.Assignee != null && x.Assignee.Id == userId);
        return _mapper.Map<IEnumerable<Task>, IEnumerable<TaskDto>>(tasksByUser);
    }

    private async Task<(long Id, string Name)> GetRoleByUser(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var roleName = roles.FirstOrDefault() ?? string.Empty;
        var role = await _roleManager.FindByNameAsync(roleName);

        return (role.Id, role.RoleName);
    }
}