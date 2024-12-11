using Application.Dtos;
using Application.Services.BaseServices;
using Dal.Entities;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class TaskCollaboratorController : BaseController<TaskCollaborator, TaskCollaboratorDto, long>
{
    public TaskCollaboratorController(IBaseCrudService<TaskCollaborator, TaskCollaboratorDto, long> service) : base(service)
    {
    }
}