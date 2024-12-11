using Application.Dtos;
using Application.Services;
using Application.Services.BaseServices;
using Dal.Entities;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class TaskTagController : BaseController<TaskTag, TaskTagDto, int>
{
    public TaskTagController(IBaseCrudService<TaskTag, TaskTagDto, int> service) 
        : base(service)
    { }
}