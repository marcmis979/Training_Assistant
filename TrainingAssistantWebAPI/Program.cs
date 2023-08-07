using Microsoft.EntityFrameworkCore;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Repositories.Implementation;
using TraingAssistantDAL.Repositories.Repositories;
using TrainingAssistantBLL.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TrainingAssistantContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITrainingPlanRepository, TrainingPlanRepository>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped<IMusclePartRepository, MusclePartRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IExerciseBs, ExerciseBs>();
builder.Services.AddScoped<IMusclePartBs, MusclePartBs>();
builder.Services.AddScoped<ITrainingBs, TrainingBs>();
builder.Services.AddScoped<ITrainingPlanBs, TrainingPlanBs>();
builder.Services.AddScoped<IUserBs, UserBs>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
