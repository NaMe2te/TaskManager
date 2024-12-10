using Application;
using Dal;
using Dal.DBContexts;
using Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddRepositories();
builder.Services.AddUnitOfWork();
builder.Services.AddCustomMiddlewares();


builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();


builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCustomMiddlewares();

app.MapControllers();

app.Run();