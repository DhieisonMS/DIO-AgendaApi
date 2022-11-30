using Microsoft.EntityFrameworkCore;


using src.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var stringDb = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AgendaContext>(options => options.UseMySql(
    stringDb,
    ServerVersion.AutoDetect(stringDb)
));

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateFormatString = "dd/MM/yyyy HH:mm:ss tt";
    });
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
