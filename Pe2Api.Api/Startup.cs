using Pe2Api.Extensions;
using Pe2Api.Domain.Notifications;
using Pe2Api.Api.Controllers.Responses;
using Pe2Api.Domain.Pagination;
using System.Reflection;

namespace Pe2Api.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddSwaggerGen(x =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                x.IncludeXmlComments(xmlPath);
            });
            var allowedOrigins = Configuration.GetSection("AllowedOrigins").Value;
            services.AddCors(options =>
            {
                options.AddPolicy("ClientPermission", policy =>
                {
                    policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(allowedOrigins.Split(";"))
                    .AllowCredentials();
                });
            });

            services.AddMongoDb(Configuration);
            services.AddControllers();
            services.AddRepositories();
            services.AddMediator();

         

            services.AddScoped<NotificationContext>();
            services.AddScoped<IResponseFactory, ResponseFactory>();
            services.AddScoped(typeof(IPaginationResponse<>), typeof(PaginationResponse<>));
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("ClientPermission");
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("ClientPermission");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
