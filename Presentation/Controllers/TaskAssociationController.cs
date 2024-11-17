using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class TaskAssociationController : BaseController<TaskAssociation, TaskAssociationDto, long>
{
    public TaskAssociationController(IBaseCrudService<TaskAssociation, TaskAssociationDto, long> service) : base(service)
    {
    }
}