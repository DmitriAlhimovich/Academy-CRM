using System.Collections.Generic;
using AcademyCRM.BLL;
using AcademyCRM.BLL.Models;
using AcademyCRM.BLL.Services;
using AcademyCRM.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AcademyCRM.DAL.EF.Contexts;
using AcademyCRM.DAL.EF.Repositories;
using AcademyCRM.Web.Mvc.Mapper;
using AutoMapper;

namespace AcademyCRM.Web.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AcademyContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AcademyContext>();

            services.AddScoped<IRepository<Topic>, BaseRepository<Topic>>();
            services.AddScoped<IRepository<Course>, BaseRepository<Course>>();
            services.AddScoped<IRepository<Teacher>, TeachersRepository>();
            services.AddScoped<IRepository<Student>, StudentsRepository>();
            services.AddScoped<IRepository<StudentGroup>, StudentGroupsRepository>();
            services.AddScoped<IRepository<StudentRequest>, StudentRequestsRepository>();

            services.AddBusinessLogicServices();
            services.AddScoped<ICourseService, FakeCourseService>();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }

    public class FakeCourseService : ICourseService
    {
        public IEnumerable<Course> GetAll()
        {
            return new[] { new Course
            {
                Title = "FakeCourse",
                Description = "Fake desc"
            } };
        }

        public Course GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Course entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Course entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
