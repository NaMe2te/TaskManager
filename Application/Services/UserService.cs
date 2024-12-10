using System.Linq.Expressions;
using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class UserService : IBaseCrudService<User, UserDto>
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public UserService(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
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
        var users = await _userManager.Users.ToListAsync();
        var userDtos = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        return userDtos;
    }
}