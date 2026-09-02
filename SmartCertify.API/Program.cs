using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using SmartCertify.API.Controllers;
using SmartCertify.Application;
using SmartCertify.Application.interfaces.Courses;
using SmartCertify.Application.Services;
using SmartCertify.Domain;
using SmartCertify.Infrastructure;
using SmartCertify.Infrastructure.Persistence;
using SmartCertify.API.Filters;
using FluentValidation;
using SmartCertify.Application.DTOValidations;
using SmartCertify.Application.interfaces.Questions;
using SmartCertify.Application.DTOs;
namespace SmartCertify.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<SmartCertifyDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"),
            sqlOptions => sqlOptions.EnableRetryOnFailure())
  );

            // Add services to the container.
            // Add FluentValdiation
            builder.Services.AddValidatorsFromAssemblyContaining<CreateCourseValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateCourseValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<QuestionValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateQuestionValidator>();

            // adding 
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();

            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IQuestionService, QuestionService>();
            // IN production, modify this with the actual domains you want to allow 
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            // Add services to the container.


            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilter>(); //add your custom valdiation filter
            }).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true; //Disable automatic validation

            });
            builder.Services.AddEndpointsApiExplorer();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options => {
                    options.WithTitle("My API");
                    options.WithTheme(ScalarTheme.BluePlanet);
                    options.HideSidebar();
                
                });
                app.UseSwaggerUi(options =>
                {
                    options.DocumentPath = "openapi/v1.json";
                });

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("default");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
