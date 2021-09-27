using AcademyCRM.BLL.Services;
using AcademyCRM.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace AcademyCRM.BLL
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IEntityService<Topic>, BaseEntityService<Topic>>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentGroupService, StudentGroupService>();
            services.AddScoped<IStudentRequestService, StudentRequestService>();

            return services;
        }
    }
}
