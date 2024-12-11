using Application.Dtos;
using Application.Services;
using Application.Services.BaseServices;
using Dal.Entities;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class TaskHistoryController : BaseController<TaskHistory, TaskHistoryDto, int>
{
    public TaskHistoryController(IBaseCrudService<TaskHistory, TaskHistoryDto, int> service) : base(service)
    {
    }
}