using Application;
using Dal;
using Dal.DBContexts;
using Microsoft.EntityFrameworkCore;
using Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

builder.Services.AddRepositories();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddUnitOfWork();
builder.Services.AddCustomMiddlewares();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

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

app.MapControllers();

app.UseCustomMiddlewares();

app.Run();