using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class RoleService : BaseCrudService<Role, RoleDto, int>
{
    public RoleService(IBaseRepository<Role, int> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : base(repository, mapper, unitOfWork)
    { }
}