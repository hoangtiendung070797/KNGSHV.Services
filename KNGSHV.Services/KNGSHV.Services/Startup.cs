using AutoMapper;
using KNGSHV.Application.AutoMapper;
using KNGSHV.Application.Implementation;
using KNGSHV.Application.Interfaces;
using KNGSHV.Data.EF;
using KNGSHV.Data.Entities;
using KNGSHV.Infrastructure.Interfaces;
using KNGSHV.Services.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace KNGSHV.Services
{
    public class Startup
    {
        readonly string specificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            //Inject AppSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KNGSHV.Services", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: specificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200/",
                                                          "http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                                  });
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMemoryCache();

            services.AddDbContext<AppDbContext>(options =>
                                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                    o => o.MigrationsAssembly("KNGSHV.Data.EF")));

            // Authen
            services.AddIdentity<Account, Function>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<SignInManager<Account>, SignInManager<Account>>();
            services.AddScoped<UserManager<Account>, UserManager<Account>>();
            services.AddScoped<RoleManager<Function>, RoleManager<Function>>();
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                //Lockout setting 
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;

                //User setting 
                options.User.RequireUniqueEmail = false;
            });


            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IBlogTypeService, BlogTypeService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IClassRoomService, ClassRoomService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<ILearnerService, LearnerService>();
            services.AddTransient<ILectureService, LectureService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<ILectureScheduleService, LectureScheduleService>();
            services.AddTransient<IRegistrationFormService, RegistrationFormService>();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KNGSHV.Services v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(specificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

        }
    }
}
