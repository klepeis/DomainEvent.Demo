using DomainEvent.Domain.Events;
using DomainEvent.Domain.Handlers;
using DomainEvent.Infrastructure;
using DomainEvent.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DomainEvent.Api
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

            // Register event and handler for event.
            //TODO: Use "When" Syntax for handlers. ie -> ValidateWidgetWhenReceived

            //Register multiple handlers for the same domain event.
            services.AddScoped<IHandles<WidgetDidSomethingDomainEvent>, WidgetDidSomethingDomainEventHandler>();
            services.AddScoped<IHandles<WidgetDidSomethingDomainEvent>, WidgetDidSomethingDomainSecondEventHandler>();

            //Register single handler for a domain event.
            services.AddScoped<IHandles<WidgetDidSomethingElseDomainEvent>, WidgetDidSomethingElseDomainEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            DomainEvents.Configure(app);

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
