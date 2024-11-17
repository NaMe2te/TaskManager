using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class TaskCollaboratorController : BaseController<TaskCollaborator, TaskCollaboratorDto, long>
{
    public TaskCollaboratorController(IBaseCrudService<TaskCollaborator, TaskCollaboratorDto, long> service) : base(service)
    {
    }
}