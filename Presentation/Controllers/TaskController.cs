using Application.Dtos;
using Application.Services;
using Task = Dal.Entities.Task;

namespace Presentation.Controllers;

public class TaskController : BaseController<Task, TaskDto, int>
{
    public TaskController(IBaseCrudService<Task, TaskDto, int> service) : base(service)
    {
    }
}