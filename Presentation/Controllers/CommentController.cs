using Application.Dtos;
using Application.Services;
using Application.Services.BaseServices;
using Dal.Entities;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class CommentController : BaseController<Comment, CommentDto, long>
{
    public CommentController(IBaseCrudService<Comment, CommentDto, long> service) : base(service)
    {
    }
}