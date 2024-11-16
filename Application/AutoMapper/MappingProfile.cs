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
            .ForMember(dest => dest.Task, opt => opt.Ignore()) // Игнорируем навигационное свойство Task
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
            .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization.Name)) // Маппим имя организации
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks)); // Маппим коллекцию задач

        CreateMap<ProjectDto, Project>()
            .ForMember(dest => dest.Organization, opt => opt.Ignore()) // Игнорируем Organization (объект)
            .ForMember(dest => dest.Tasks, opt => opt.Ignore());
    }

    private void CreateTaskMap()
    {
        CreateMap<Task, TaskDto>()
            .ForMember(dest => dest.CreatorName, opt => opt.MapFrom(src => src.Creator.FullName)) // Маппинг имени создателя
            .ForMember(dest => dest.AssigneeName, opt => opt.MapFrom(src => src.Assignee != null ? src.Assignee.FullName : null)) // Маппинг имени исполнителя
            .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status != null ? src.Status.Name : null)) // Маппинг названия статуса
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments)) // Маппинг комментариев
            .ForMember(dest => dest.Collaborators, opt => opt.MapFrom(src => src.TaskCollaborators)); // Маппинг участников задачи

        CreateMap<TaskDto, Task>()
            .ForMember(dest => dest.Creator, opt => opt.Ignore()) // Игнорируем объект создателя
            .ForMember(dest => dest.Assignee, opt => opt.Ignore()) // Игнорируем объект исполнителя
            .ForMember(dest => dest.Status, opt => opt.Ignore()) // Игнорируем объект статуса
            .ForMember(dest => dest.Comments, opt => opt.Ignore()) // Игнорируем комментарии
            .ForMember(dest => dest.TaskCollaborators, opt => opt.Ignore());
    }

    private void CreateTaskCollaboratorsMap()
    {
        CreateMap<TaskCollaborator, TaskCollaboratorDto>()
            .ForMember(dest => dest.CollaboratorName, opt => opt.MapFrom(src => src.Collaborator.FullName));
    }

    private void CreateProjectAccessMap()
    {
        // Маппинг из ProjectAccess в ProjectAccessDto
        CreateMap<ProjectAccess, ProjectAccessDto>()
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name)) // Преобразуем Project в ProjectName
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName)) // Преобразуем User в UserName
            .ForMember(dest => dest.AccessLevel, opt => opt.MapFrom(src => src.Access.ToString())); // Преобразуем Access в строку
    }

    private void CreateRoleMap()
    {
        CreateMap<Role, RoleDto>();
    }

    private void CreateStatusMap()
    {
        CreateMap<Status, StatusDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))  // Явное указание на Id
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))  // Явное указание на Name
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted));  // Маппинг для поля IsDeleted
    }

    private void CreateTaskAssociationMap()
    {
        CreateMap<TaskAssociation, TaskAssociationDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))  // Явное указание на Id
            .ForMember(dest => dest.ParentTaskId, opt => opt.MapFrom(src => src.ParentTaskId))  // Явное указание на ParentTaskId
            .ForMember(dest => dest.ParentTaskTitle, opt => opt.MapFrom(src => src.ParentTask.Title))  // Маппинг на заголовок родительской задачи
            .ForMember(dest => dest.AssociatedTaskId, opt => opt.MapFrom(src => src.AssociatedTaskId))  // Явное указание на AssociatedTaskId
            .ForMember(dest => dest.AssociatedTaskTitle, opt => opt.MapFrom(src => src.AssociatedTask.Title));  // Маппинг на заголовок связанной задачи
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

    private void CreateTaskTagMap()
    {
        CreateMap<TaskTag, TaskTagDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))  // Явное указание на Id
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));  // Преобразуем Name

    }

    private void CreateUserMap()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))  // Маппинг имени роли
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted));  // Маппинг флага IsDeleted

    }
}