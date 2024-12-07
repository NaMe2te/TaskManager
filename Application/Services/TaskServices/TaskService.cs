using Application.Dtos.Task;
using AutoMapper;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;
using Task = Dal.Entities.Task;

namespace Application.Services.TaskServices;

public class TaskService : BaseCrudService<Task, TaskDto, long>,
    ITaskService
{
    public TaskService(IBaseRepository<Task, long> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork)
    { }

    public async Task<TaskDetailsDto> GetDetails(long taskId)
    {
        var task = await _repository.GetAsync(x => x.Id == taskId, _repository.GetNavigationFields());
        var taskDetails = _mapper.Map<Task, TaskDetailsDto>(task);
        return taskDetails;
    }
}