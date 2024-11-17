using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class TaskTagController : BaseController<TaskTag, TaskTagDto, int>
{
    public TaskTagController(IBaseCrudService<TaskTag, TaskTagDto> service) : base(service)
    {
    }
}