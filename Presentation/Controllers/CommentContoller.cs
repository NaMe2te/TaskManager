using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class CommentContoller : BaseController<Comment, CommentDto, long>
{
    public CommentContoller(IBaseCrudService<Comment, CommentDto> service) : base(service)
    {
    }
}