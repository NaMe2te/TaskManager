using Application.Dtos;
using Application.Services.BaseServices;
using Dal.Entities;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class CommitHistoryController : BaseController<CommitHistory, CommitHistoryDto, long>
{
    public CommitHistoryController(IBaseCrudService<CommitHistory, CommitHistoryDto, long> service) : base(service)
    { }
}