using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MsaterResumeIR.Application.Common;
using MsaterResumeIR.Infrastructure.Context;
using Microsoft.Data.SqlClient;
using System.Data;
using MsaterResumeIR.Domain.Interface;
using MsaterResumeIR.Infrastructure.Implement;




public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, string con_string)
    {
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddKeyedScoped<ICategoryRepository, DapperCategoryRepository>("Dapper");
        services.AddKeyedScoped<ICategoryRepository, EfCoreCategoryRepository>("EF");
        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        // Add DbContext for EF Core
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(con_string));

        services.AddTransient<IDbConnection>(provider =>
        {
            var connectionString = con_string;
            return new SqlConnection(connectionString);
        });
        return services;
    }

}









