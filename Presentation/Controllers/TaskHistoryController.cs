using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class TaskHistoryController : BaseController<TaskHistory, TaskHistoryDto, int>
{
    public TaskHistoryController(IBaseCrudService<TaskHistory, TaskHistoryDto> service) : base(service)
    {
    }
}