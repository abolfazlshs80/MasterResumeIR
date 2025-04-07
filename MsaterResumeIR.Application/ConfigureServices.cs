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
            // 1. ثبت Validatorها با استفاده از FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // 2. ثبت MediatR و اضافه کردن Pipeline Behaviors
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                // اضافه کردن Behavior برای اعتبارسنجی (Validation)


                //services.AddFluentValidationAutoValidation();
                services.AddScoped<IValidator<CreateCategoryCommand>, CreateCategoryCommandValidator>();

                //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(<ValidationC,>));
            });

            // 3. ثبت سرویس‌های دیگر (اختیاری)
            // اگر سرویس‌های دیگری در لایه Application دارید، می‌توانید آن‌ها را در اینجا ثبت کنید.
            // services.AddScoped<IMyService, MyService>();

            return services;
        }
    }
}


    


        
   


