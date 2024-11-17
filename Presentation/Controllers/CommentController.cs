using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class CommentController : BaseController<Comment, CommentDto, long>
{
    public CommentController(IBaseCrudService<Comment, CommentDto, long> service) : base(service)
    {
    }
}