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




    public static class ConfigureServices
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, string con_string)
        {
        services .AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        // Add DbContext for EF Core
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(con_string));
            return services;
        }

    }









