
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SocialLearning.Business.Abstract;
using SocialLearning.Business.Concrete;
using SocialLearning.Business.ValidationRules;
using SocialLearning.DataAccess;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialLearning
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
            services.AddTransient<IUserService, UserManager>();
            services.AddTransient<ILessonService, LessonManager>();
            services.AddTransient<IEducationService, EducationManager>();
            services.AddTransient<IAnswerService, AnswerManager>();
            services.AddTransient<IQuestionService, QuestionManager>();
            //addtransient, addscope, addsingleton
            services.AddControllers();
            services.AddSwaggerDocument();
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EducationValidator>());
            services.AddTransient<IValidator<User>, UserValidator>();
            services.AddTransient<IValidator<Education>, EducationValidator>();
            services.AddTransient<IValidator<Question>, QuestionValidator>();
            services.AddTransient<IValidator<Answer>, AnswerValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialLearning", Version = "v1" });
            });
            services.AddDbContext<SLDbContext>(options =>
options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;


            }).AddEntityFrameworkStores<SLDbContext>()
            .AddDefaultTokenProviders();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialLearning v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


           
    

        }
        }
    }

