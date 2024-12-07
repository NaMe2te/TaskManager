using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;
using Task = System.Threading.Tasks.Task;

namespace Application.Services;

public class StatusTransitionService : BaseCrudService<StatusTransition, StatusTransitionDto, long>
{
    protected StatusTransitionService(IBaseRepository<StatusTransition, long> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork) { }

    /*public async Task UploadPipeline(IEnumerable<>)
    {
        
    }*/
}