﻿using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Organization : BaseEntity<long>
{
    public Organization(string name)
    {
        Name = name;
        Projects = new List<Project>();
        Statuses = new List<Status>();
        StatusTransitions = new List<StatusTransition>();
        Users = new List<User>();
        Roles = new List<Role>();
    }
    
    protected Organization() { }

    public string Name { get; set; }
    
    public ICollection<Project> Projects { get; set; }
    public ICollection<Status> Statuses { get; set; }
    public ICollection<StatusTransition> StatusTransitions { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Role> Roles { get; set; }
}