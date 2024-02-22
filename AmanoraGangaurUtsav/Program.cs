using Agu.Business;
using Agu.Interface.Business;
using Agu.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Agu.Interface.Repository;
using Microsoft.AspNetCore.Identity;
using Agu.Domain.Core;

public class Program
{


    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              policy =>
                              {
                                  policy.WithOrigins("http://localhost:3000",
                                                      "http://www.AkshayExample.com");
                              });
        });

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddDbContext<AgDbContext>(options => options.UseSqlServer
         (builder.Configuration.GetConnectionString("DefaultConnection")));
        Program.ConfigureModules(builder);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
        {
            var userRoleManager = scope.ServiceProvider.GetRequiredService<IUserRoleManger>;

            Program.CreateSuperAdminRole(userRoleManager.Invoke());

            var userManager = scope.ServiceProvider.GetRequiredService<IUserManger>;

            Program.CreateSuperAdminUser(userManager.Invoke());
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(MyAllowSpecificOrigins);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }

    private static void ConfigureModules(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAgDbContext, AgDbContext>();
        builder.Services.AddScoped<IUserRoleManger, UserRoleManager>();
        builder.Services.AddScoped<IUserManger, UserManager>();
    }
    private static void CreateSuperAdminRole(IUserRoleManger userRole)
    {
       
        userRole.AddDefaultUserRole();
    }
    private static void CreateSuperAdminUser(IUserManger user)
    {
        var superAdminUser = new User
        {
            FullName = "Super Admin",
            Email = "SuperAdmin@agu.com",
            UserName = "SuperAdmin@agu.com",
            Password = "SuperAdmin@321"
        };
        user.AddDefaultUser(superAdminUser);
    }
}