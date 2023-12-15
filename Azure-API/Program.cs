using AzureAPI.Dao;
using AzureAPI.Dao.IRepository;
using AzureAPI.Data;
using Microsoft.EntityFrameworkCore;
using AzureAPI.Middlewares;
using Microsoft.AspNetCore.Mvc;
using AzureAPI.Exceptions;
using StackExchange.Redis;
using Azure_API.Dao.IRepository;
using Azure_API.Dao;

namespace AzureAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
               builder.Configuration.GetConnectionString("Entity")
            ));
            builder.Services.AddSingleton<IConnectionMultiplexer>(_ =>
            {
                var rediturl = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(rediturl);
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage);

                    var errorResponse = new ValidateInputErrorResponse(400)
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);

                };
            });

            builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            //declare service for dependency injection
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IBasketRepository, BasketRepository>();


            var app = builder.Build();

            app.UseMiddleware<SeverErrorExceptionMiddle>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("MyCors");

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            AppDbInitializer.Seed(app);

            app.MapControllers();

            app.Run();
        }
    }
}