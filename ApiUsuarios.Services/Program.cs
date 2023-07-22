using ApiUsuarios.Infra.Messages.Consumers;
using ApiUsuarios.Services.Extensions;
using ApiUsuarios.Services.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map => map.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddDependencyInjection();
builder.Services.AddJwtBearer();
builder.Services.AddHostedService<UsuarioMessageConsumer>();
builder.Services.AddCorsPolicy();

var app = builder.Build();

app.UseSwaggerDoc();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.UseCorsPolicy();
app.Run();

public partial class Program { }
