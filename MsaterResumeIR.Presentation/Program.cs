using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MsaterResumeIR.Application;
using MsaterResumeIR.Application.Common;
using MsaterResumeIR.Infrastructure;
using MsaterResumeIR.Infrastructure.Context;

namespace MsaterResumeIR.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //.AddFluentValidation(options =>
            //{
            //    // ثبت Validatorها از Assembly جاری
            //    options.RegisterValidatorsFromAssemblyContaining<Program>();
            //}); ;

            // Add FluentValidation
            builder.Services.AddFluentValidationAutoValidation(); // اعتبارسنجی خودکار سمت سرور
            builder.Services.AddFluentValidationClientsideAdapters(); // اعتبارسنجی سمت کلاینت (اختیاری)

            // ثبت Validatorها از Assembly جاری
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.RegisterApplicationServices();
            builder.Services.RegisterInfrastructureServices(connection);



            // Add MediatR for commands and queries

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

           

            app.Run();
        }
    }
}
