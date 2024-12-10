using System.Linq.Expressions;
using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class RoleService : IBaseCrudService<Role, RoleDto>
{
    private readonly IMapper _mapper;
    private readonly RoleManager<Role> _roleManager;
    
    public RoleService(RoleManager<Role> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task<RoleDto> Add(RoleDto dto)
    {
        var role = _mapper.Map<RoleDto, Role>(dto);
        await _roleManager.CreateAsync(role);
        return dto;
    }

    public async Task<RoleDto> Update(RoleDto dto)
    {
        var role = _mapper.Map<RoleDto, Role>(dto);
        await _roleManager.UpdateAsync(role);
        return dto;
    }

    public async Task<RoleDto> Remove(RoleDto dto)
    {
        var role = _mapper.Map<RoleDto, Role>(dto);
        await _roleManager.DeleteAsync(role);
        return dto;
    }

    public async Task<IEnumerable<RoleDto>> GetAll(Expression<Func<Role, bool>>? predicate = null, PaginationParams? paginationParams = null)
    {
        var roles = await _roleManager.Roles.ToListAsync();
        var roleDtos = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>>(roles);
        return roleDtos;
    }
}