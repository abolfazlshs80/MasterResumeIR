using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MsaterResumeIR.Application.Common;

namespace MsaterResumeIR.Application
{
 

    public static class ConfigureServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {

            //      services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
              //  cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>);
            });

                return services;
        }

    }


    


        
   

}
