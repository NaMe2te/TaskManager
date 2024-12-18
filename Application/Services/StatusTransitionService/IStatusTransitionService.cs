using Application.Dtos;
using Application.Services.BaseServices;
using Dal.Entities;

namespace Application.Services.StatusTransitionService;

public interface IStatusTransitionService : IBaseCrudService<StatusTransition, StatusTransitionDto, long>
{
    Task<IEnumerable<StatusTransitionDto>> GetStatusTransitionsToFrom(int statusTo);
}