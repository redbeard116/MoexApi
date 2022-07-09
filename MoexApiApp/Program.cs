using MoexApiApp;
using MoexApiApp.Extensions;
using MoexApiApp.Tools;

var builder = WebApplication.CreateBuilder(args);

NlogTools.AddNlogLogger();
builder.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var main = app.Services.GetService<Main>();

await main.Start();

app.Run();
