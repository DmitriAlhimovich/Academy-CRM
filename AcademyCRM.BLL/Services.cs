using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyCRM.BLL.Models;
using AcademyCRM.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AcademyCRM.BLL
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IEntityService<Topic>, EntityService<Topic>>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentGroupService, StudentGroupService>();
            services.AddScoped<IEntityService<StudentRequest>, EntityService<StudentRequest>>();

            return services;
        }
    }
}
