﻿using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Dal.DBContexts;

public class DatabaseContext : DbContext
{
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommitHistory> CommitHistories { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectAccess> ProjectAccesses { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<TaskAssociation> TaskAssociations { get; set; }
    public DbSet<TaskCollaborator> TaskCollaborators { get; set; }
    public DbSet<TaskHistory> TaskHistories { get; set; }
    public DbSet<TaskTag> TaskTags { get; set; }
    public DbSet<User> Users { get; set; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}