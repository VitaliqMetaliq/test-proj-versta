using FluentValidation;
using Mapster;
using Microsoft.OpenApi.Models;
using Orders.Api.Application.Abstractions;
using Orders.Api.Application.Services;
using Orders.Api.Infrastructure.Extensions;
using Orders.Api.Main.Middleware;
using Orders.Api.Main.Models;
using Orders.Api.Main.Validators;
using Serilog;

namespace Orders.Api.Main
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);

            services.AddSerilog((s, config) =>
            {
                config.ReadFrom.Configuration(Configuration)
                    .ReadFrom.Services(s)
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("Application", "Orders.Api");
            });

            services.AddEndpointsApiExplorer();
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Orders.Api.Main v1",
                    Version = "v1",
                });
            });

            services.AddControllers();
            services.AddMapster();

            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IValidator<CreateOrderRequest>, CreateOrderRequestValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.DocumentTitle = "Orders.Api.Main";
                    options.SwaggerEndpoint("v1/swagger.json", "Orders.Api.Main");
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
