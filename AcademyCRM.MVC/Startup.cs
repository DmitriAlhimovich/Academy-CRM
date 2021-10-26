using AcademyCRM.BLL;
using AcademyCRM.DAL;
using AcademyCRM.DAL.EF.Contexts;
using AcademyCRM.DAL.EF.Repositories;
using AcademyCRM.MVC.Configuration;
using AcademyCRM.MVC.Mapper;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using AcademyCRM.MVC.Filters;
using AcademyCRM.MVC.Middleware;
using AcademyCRM.Core.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace AcademyCRM.MVC
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
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                    options.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
                    options.EnableSensitiveDataLogging();
                }
            );

            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddDefaultUI()
                 .AddEntityFrameworkStores<AcademyContext>()
                 .AddDefaultTokenProviders();

            services.AddScoped<IRepository<CourseCategory>, BaseRepository<CourseCategory>>();
            services.AddScoped<ICourseRepository, CoursesRepository>();
            services.AddScoped<IRepository<Teacher>, TeachersRepository>();

            services.AddScoped<IRepository<Student>, StudentsRepository>();
            services.AddScoped<IRepository<StudentGroup>, StudentGroupsRepository>();
            services.AddScoped<IRepository<StudentRequest>, StudentRequestsRepository>();

            services.AddBusinessLogicServices();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc(options =>
                options.Filters.Add<GlobalExceptionFilter>()
            );

            services.AddControllersWithViews()
                .AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true);

            services.Configure<SecurityOptions>(
                   Configuration.GetSection(SecurityOptions.SectionTitle));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, IOptions<SecurityOptions> securityOptions)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
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
                    pattern: "{controller=Courses}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            CreateRoles(serviceProvider, securityOptions).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider, IOptions<SecurityOptions> securityOptions)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "admin", "manager", "student" };


            foreach (var roleName in roles)
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                });

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var adminUser = await userManager.FindByEmailAsync(securityOptions.Value.AdminUserEmail);

            if (adminUser != null)
            {
                await userManager.AddToRoleAsync(adminUser, "ADMIN");
            }

            var managerUser = await userManager.FindByEmailAsync(Configuration["Security:ManagerUserEmail"]);

            if (managerUser != null)
            {
                await userManager.AddToRoleAsync(managerUser, "MANAGER");
            }


        }
    }
}
