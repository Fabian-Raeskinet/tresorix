using Tresorix.Api;
using Tresorix.Data;
using Tresorix.DependencyInjection.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiServices(builder.Configuration);
builder.Services.RegisterApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    using var scope = app.Services.CreateScope();
    var initializer = scope.ServiceProvider.GetRequiredService<TresorixContextInitializer>();
    await initializer.InitialiseAsync();
    await initializer.TrySeedAsync();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();