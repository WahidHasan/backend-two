using Workshop_1.Middlewares;
using Workshop_1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMvc();
builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<CacheControlMiddleware>();

app.MapControllers();
app.MapHub<ChatHub>("chatHub");
app.Run();
