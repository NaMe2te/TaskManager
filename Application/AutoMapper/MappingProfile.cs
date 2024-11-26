using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Task = Dal.Entities.Task;

namespace Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateCommentMap();
        CreateOrganizationMap();
        CreateProjectMap();
        CreateTaskMap();
        CreateTaskCollaboratorsMap();
        CreateProjectAccessMap();
        CreateRoleMap();
        CreateStatusMap();
        CreateTaskAssociationMap();
        CreateTaskHistoryMap();
        CreateTaskTagMap();
        CreateUserMap();
    }

    private void CreateCommentMap()
    {
        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.Task.Title))
            .ForMember(dest => dest.CommenterName, opt => opt.MapFrom(src => src.Commenter.FullName));
        
        CreateMap<CommentDto, Comment>()
            .ForMember(dest => dest.Task, opt => opt.Ignore())
            .ForMember(dest => dest.Commenter, opt => opt.Ignore());
    }

    private void CreateOrganizationMap()
    {
        CreateMap<Organization, OrganizationDto>()
            .ForMember(dest => dest.Projects,
                opt => opt.MapFrom(src => src.Projects));
        CreateMap<OrganizationDto, Organization>()
            .ForMember(dest => dest.Projects, opt => opt.Ignore());
    }

    private void CreateProjectMap()
    {
        CreateMap<Project, ProjectDto>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));

        CreateMap<ProjectDto, Project>()
            .ForMember(dest => dest.Tasks, opt => opt.Ignore());
    }

    private void CreateTaskMap()
    {
        CreateMap<Task, TaskDto>()
            /*.ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
            .ForMember(dest => dest.Collaborators, opt => opt.MapFrom(src => src.TaskCollaborators))*/
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name));

        CreateMap<TaskDto, Task>()
            .ForMember(dest => dest.Creator, opt => opt.Ignore())
            .ForMember(dest => dest.Assignee, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.Comments, opt => opt.Ignore())
            .ForMember(dest => dest.TaskCollaborators, opt => opt.Ignore());
    }

    private void CreateTaskCollaboratorsMap()
    {
        CreateMap<TaskCollaborator, TaskCollaboratorDto>()
            .ForMember(dest => dest.CollaboratorName, 
                opt => opt.MapFrom(src => src.Collaborator.FullName));

        CreateMap<TaskCollaboratorDto, TaskCollaborator>();

    }

    private void CreateProjectAccessMap()
    {
        CreateMap<ProjectAccess, ProjectAccessDto>()
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
            .ForMember(dest => dest.AccessLevel, opt => opt.MapFrom(src => src.Access.ToString()));

        CreateMap<ProjectAccessDto, ProjectAccess>();
    }

    private void CreateTaskAssociationMap()
    {
        CreateMap<TaskAssociation, TaskAssociationDto>()
            .ForMember(dest => dest.ParentTaskTitle, opt => opt.MapFrom(src => src.ParentTask.Title))
            .ForMember(dest => dest.AssociatedTaskTitle, opt => opt.MapFrom(src => src.AssociatedTask.Title));

        CreateMap<TaskAssociationDto, TaskAssociation>();
    }

    private void CreateTaskHistoryMap()
    {
        CreateMap<TaskHistory, TaskHistoryDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))  // Явное указание на Id
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))  // Преобразуем UserId
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))  // Преобразуем имя пользователя из сущности User
            .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))  // Преобразуем TaskId
            .ForMember(dest => dest.OldStatusId, opt => opt.MapFrom(src => src.OldStatusId))  // Преобразуем OldStatusId
            .ForMember(dest => dest.OldStatusName, opt => opt.MapFrom(src => src.OldStatus.Name))  // Преобразуем OldStatusName из связанной сущности Status
            .ForMember(dest => dest.NewStatusId, opt => opt.MapFrom(src => src.NewStatusId))  // Преобразуем NewStatusId
            .ForMember(dest => dest.NewStatusName, opt => opt.MapFrom(src => src.NewStatus.Name))  // Преобразуем NewStatusName из связанной сущности Status
            .ForMember(dest => dest.DateUpdated, opt => opt.MapFrom(src => src.LastUpdated));  // Преобразуем DateUpdated
    }

    private void CreateRoleMap()
    {
        CreateMap<Role, RoleDto>().ReverseMap();
    }

    private void CreateStatusMap()
    {
        CreateMap<Status, StatusDto>().ReverseMap();
    }
    
    private void CreateTaskTagMap()
    {
        CreateMap<TaskTag, TaskTagDto>().ReverseMap();

    }

    private void CreateUserMap()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}