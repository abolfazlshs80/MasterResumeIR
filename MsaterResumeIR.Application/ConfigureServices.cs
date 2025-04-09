using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MsaterResumeIR.Application.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MsaterResumeIR.Application.Users.Commands.CreateUser;
namespace MsaterResumeIR.Application
{
 

   


    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            //services.AddFluentValidationAutoValidation();
    
          //  services.AddScoped<IValidator<CreateCategoryCommand>, CreateCategoryCommandValidator>();


            // 3. ثبت سرویس‌های دیگر (اختیاری)
            // اگر سرویس‌های دیگری در لایه Application دارید، می‌توانید آن‌ها را در اینجا ثبت کنید.
            // services.AddScoped<IMyService, MyService>();
            // ثبت MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly);
            });

            // ثبت Validatorها
            services.AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);

            // اضافه کردن Validation Pipeline Behavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
         
        }
    }
}


    


        
   


