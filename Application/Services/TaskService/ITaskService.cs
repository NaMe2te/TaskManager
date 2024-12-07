using Application.Dtos.Task;
using Task = Dal.Entities.Task;

namespace Application.Services.TaskService;

public interface ITaskService : IBaseCrudService<Task, TaskDto, long>
{
    Task<TaskDetailsDto> GetDetails(long taskId);
    
    Task<IEnumerable<TaskDto>> GetTasksCreatedByUserId(long userId);
    
    Task<IEnumerable<TaskDto>> GetTasksAssignedToUserId(long userId);
}