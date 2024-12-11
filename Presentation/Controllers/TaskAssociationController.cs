using Application.Dtos;
using Application.Services;
using Application.Services.BaseServices;
using Dal.Entities;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class TaskAssociationController : BaseController<TaskAssociation, TaskAssociationDto, long>
{
    public TaskAssociationController(IBaseCrudService<TaskAssociation, TaskAssociationDto, long> service) : base(service)
    {
    }
}