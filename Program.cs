using webapi.Middlewares;
using webapi.Services;
using webapi.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

//builder.Services.AddScoped<IHelloWorldService, HelloWordService>();
builder.Services.AddScoped<IHelloWorldService>( p => new HelloWordService());
builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<ITaskService,TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();

app.UseTimeMiddlware();


// app.UseCors();

app.MapControllers();

app.Run();
