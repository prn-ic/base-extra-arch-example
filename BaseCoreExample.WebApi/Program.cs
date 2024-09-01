using System.Reflection;
using BaseCoreExample.Application.Commands;
using BaseCoreExample.Application.Mappings;
using BaseCoreExample.Application.Queries;
using BaseCoreExample.Persistanse;
using BaseCoreExample.Persistanse.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddNpgsqlEntityFrameworkPersistanse(builder.Configuration);
        builder.Services.AddAutoMapper(typeof(AppMappingProfile));
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.RegisterServicesFromAssembly(Assembly.Load("BaseCoreExample.Application"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }
            catch { }
            finally { }
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
