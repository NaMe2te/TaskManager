using Application.Dtos;
using Application.Services;
using Task = Dal.Entities.Task;

namespace Presentation.Controllers;

public class TaskController : BaseController<Task, TaskDto, long>
{
    public TaskController(IBaseCrudService<Task, TaskDto> service) : base(service)
    {
    }
}