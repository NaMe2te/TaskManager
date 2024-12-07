using Application.Dtos.Task;
using Application.Services.TaskServices;
using Microsoft.AspNetCore.Mvc;
using Task = Dal.Entities.Task;

namespace Presentation.Controllers;

public class TaskController : BaseController<Task, TaskDto, long>
{
    public TaskController(ITaskService service) : base(service)
    {
    }

    [HttpGet(nameof(GetTaskDetails))]
    public async Task<ActionResult<TaskDto>> GetTaskDetails([FromQuery] long taskId)
    {
        return Ok(await ((ITaskService)_service).GetDetails(taskId));
    }
}