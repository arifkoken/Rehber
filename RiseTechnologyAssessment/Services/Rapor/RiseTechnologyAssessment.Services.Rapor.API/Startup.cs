using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract;
using RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract.ServiceAdapter;
using RiseTechnologyAssessment.Services.Rapor.API.Business.Concrete;
using RiseTechnologyAssessment.Services.Rapor.API.MassTransit.Cosumers;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Db;

namespace RiseTechnologyAssessment.Services.Rapor.API
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

         
            services.AddControllers();


            services.AddScoped<IRehberServiceAdapter, FakeRehberServiceAdapter>();
            services.AddScoped<IRaporService, RaporService>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });


            services.AddDbContext<RaporContext>(
                options => options.UseSqlServer(Configuration["ConnectionStrings"])
            );


     
            services.AddMassTransit(x =>
            {
                x.AddConsumer<RaporConsumer>().Endpoint(e => { e.Name = "rapor-kuyruk"; });

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration["RabbitMQ_HostName"], Configuration["RabbitMQ_VirtualHost"], h =>
                    {
                        h.Username(Configuration["RabbitMQ_UserName"]);
                        h.Password(Configuration["RabbitMQ_Password"]);

                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddMassTransitHostedService();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          

     
            app.UseCors("AllowOrigin");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
