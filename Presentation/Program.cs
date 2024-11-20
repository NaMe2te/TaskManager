using Application;
using Dal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

builder.Services.AddRepositories();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddUnitOfWork();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();