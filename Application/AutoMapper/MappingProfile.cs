using Application.Dtos;
using Application.Dtos.Task;
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
        CreateStatusTransition();
        CreateTaskAssociationMap();
        CreateTaskTagMap();
        CreateUserMap();
        CreateCommitHistoryMap();
    }

    private void CreateCommentMap()
    {
        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.Task.Title))
            .ForMember(dest => dest.CommenterName, opt => opt.MapFrom(src => src.Commenter.UserName));
        
        CreateMap<CommentDto, Comment>()
            .ForMember(dest => dest.Task, opt => opt.Ignore())
            .ForMember(dest => dest.Commenter, opt => opt.Ignore());
    }

    private void CreateOrganizationMap()
    {
        CreateMap<Organization, OrganizationDto>()
            .ForMember(dest => dest.Projects,
                opt => opt.MapFrom(src => src.Projects))
            .ForMember(dest => dest.Statuses, opt => opt.MapFrom(src => src.Statuses));
        CreateMap<OrganizationDto, Organization>()
            .ForMember(dest => dest.Projects, opt => opt.Ignore())
            .ForMember(dest => dest.Statuses, opt => opt.Ignore())
            .ForMember(dest => dest.StatusTransitions, opt => opt.Ignore())
            .ForMember(dest => dest.Users, opt => opt.Ignore())
            .ForMember(dest => dest.Roles, opt => opt.Ignore());
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
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name));

        CreateMap<TaskDto, Task>()
            .ForMember(dest => dest.Creator, opt => opt.Ignore())
            .ForMember(dest => dest.Assignee, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.Comments, opt => opt.Ignore())
            .ForMember(dest => dest.TaskCollaborators, opt => opt.Ignore());

        CreateMap<Task, TaskDetailsDto>()
            .IncludeBase<Task, TaskDto>()
            .ForMember(dest => dest.Collaborators, opt => opt.MapFrom(src => src.TaskCollaborators))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

    }

    private void CreateTaskCollaboratorsMap()
    {
        CreateMap<TaskCollaborator, TaskCollaboratorDto>()
            .ForMember(dest => dest.CollaboratorName, 
                opt => opt.MapFrom(src => src.Collaborator.UserName));

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

    private void CreateRoleMap()
    {
        CreateMap<Role, RoleDto>().ReverseMap();
    }

    private void CreateStatusMap()
    {
        CreateMap<Status, StatusDto>().ReverseMap();
    }

    private void CreateStatusTransition()
    {
        CreateMap<StatusTransition, StatusTransitionDto>()
            .ForMember(dest => dest.FromStatusName, opt => opt.MapFrom(src => src.From.Name))
            .ForMember(dest => dest.ToStatusName, opt => opt.MapFrom(src => src.To.Name));

        CreateMap<StatusTransitionDto, StatusTransition>();
    }
    
    private void CreateTaskTagMap()
    {
        CreateMap<TaskTag, TaskTagDto>().ReverseMap();
    }

    private void CreateUserMap()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleName, opt =>
                opt.MapFrom((src, dest, destMember, context) => context.Items["Role"]))
            .ReverseMap();
    }
    
    private void CreateCommitHistoryMap()
    {
        CreateMap<CommitHistory, CommitHistoryDto>().ReverseMap();
    }
}