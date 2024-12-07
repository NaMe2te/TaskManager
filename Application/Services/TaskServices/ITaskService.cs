using Application.Dtos.Task;
using Task = Dal.Entities.Task;

namespace Application.Services.TaskServices;

public interface ITaskService : IBaseCrudService<Task, TaskDto, long>
{
    Task<TaskDetailsDto> GetDetails(long taskId);
}